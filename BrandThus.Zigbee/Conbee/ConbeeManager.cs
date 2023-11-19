using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrandThus.Zigbee.Conbee
{
    public class ConbeeManager : ZigbeeManager
    {
        #region Constructor
        public ConbeeManager(IConfiguration configuration, CancellationToken stoppingToken)
        {
            //Open the SerialPort
            portName = configuration["Zigbee:Port"] ?? "";
            portThread = new Thread(() => HandlePort(stoppingToken)) { Priority = ThreadPriority.AboveNormal, IsBackground = true, Name = "Conbee" };
            portThread.Start();

            //Check logLevel
            if (configuration["Zigbee:Logging"] is string l)
                Logger.LogLevel = Enum.Parse<LogType>(l);
        }
        #endregion

        #region Properties
        private readonly string portName;
        private DateTime portCheck;
        private SerialPort? port;
        private readonly Thread portThread;
        private DateTime allowJoin;
        private readonly ConcurrentQueue<(ConbeeCommand command, object? parameter)> commands = new ConcurrentQueue<(ConbeeCommand command, object? parameter)>();
        private byte conbeeAPSDE;
        private bool readEscape;
        private readonly ConbeeParameters parameters = new ConbeeParameters();
        private readonly ConbeeReader reader = new ConbeeReader();
        private readonly ZigbeeRequest?[] requests = new ZigbeeRequest[256];
        private readonly ConbeeWriter writer = new ConbeeWriter();
        private byte writeRequestId;
        private byte writeSequence;

        public override bool IsOpen => throw new NotImplementedException();
        #endregion

        #region HandlePort
        private void HandlePort(CancellationToken stoppingToken)
        {
            Thread.Sleep(4000);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    if (port == null || !port.IsOpen)
                    {
                        TimeSpan msec = portCheck - DateTime.Now;
                        if (msec.TotalMilliseconds > 0)
                            Thread.Sleep(msec);
                        port?.Dispose();
                        port = new SerialPort(portName)
                        {
                            WriteTimeout = 300,
                            BaudRate = 115200,
                            ReceivedBytesThreshold = 1,
                            StopBits = StopBits.One,
                            DataBits = 8,
                            Parity = Parity.None,
                            NewLine = "\n",
                            Encoding = Encoding.ASCII,
                            WriteBufferSize = 4096
                        };
                        port.Open();
                        Logger.Info("Serial port: " + portName + " opened");

                        Coordinator = CreateNode(0);
                        foreach (ZigbeeNode i in Nodes.Values)
                            if (i?.Addr16 > 0)
                                OnNodeCreate?.Invoke(i);

                        //Get the parameters & firmware
                        commands.Clear();
                        commands.Enqueue((ConbeeCommand.DEVICE_STATE, null));
                        foreach (var p in Enum.GetValues(typeof(ConbeeParameter)))
                            commands.Enqueue((ConbeeCommand.READ_PARAMETER, p));
                        commands.Enqueue((ConbeeCommand.VERSION, null));

                        //Allow joining for 4 minutes
                        allowJoin = DateTime.Now.AddMinutes(4);
                        PermitJoin(true);
                        OnLine?.Invoke();
                    }
                    else if (allowJoin != DateTime.MinValue && DateTime.Now > allowJoin)
                    {
                        allowJoin = DateTime.MinValue;
                        PermitJoin(false);
                    }
                    else
                    {
                        if (port.BytesToRead > 0)
                            ReadPort();
                        else if (!commands.IsEmpty && (conbeeAPSDE == 0 || (conbeeAPSDE & 0x7F) != 0) && portCheck < DateTime.Now)
                            WriteCommand(ConbeeCommand.DEVICE_STATE);
                    }
                    Thread.Sleep(1);
                }
                catch (FileNotFoundException)
                {
                    port?.Dispose();
                    port = null;
                    portCheck = DateTime.Now.AddSeconds(5);
                }
                catch (Exception ex)
                {
                    ex.Trace();
                }
            }
        }
        #endregion

        #region ReadPort
        internal void ReadPort()
        {
            while (true)
            {
                if (port == null || port.BytesToRead <= 0)
                    break;

                byte val = (byte)port.ReadByte();
                if (!readEscape)
                {
                    switch (val)
                    {
                        case 0xC0:
                            if (reader.Offset <= 0)
                                break;
                            try
                            {
                                if (reader.Offset < 7)
                                    Logger.Error("Packet too small");
                                else if (!CheckCrc(reader.Offset - 2))
                                    Logger.Error("Wrong CRC");
                                else
                                {
                                    reader.Length = reader.Offset;
                                    reader.Offset = 5;
                                    ReadCommand();
                                }
                                reader.Clear();
                            }
                            catch (Exception ex)
                            {
                                ex.Trace();
                            }
                            break;
                        case 0xDB:
                            readEscape = true;
                            break;
                        default:
                            reader.Add(val);
                            readEscape = false;
                            break;
                    }
                }
                else
                {
                    switch (val)
                    {
                        case 0xDC: reader.Add(0xC0); break;
                        case 0xDD: reader.Add(0xDB); break;
                        default: reader.Clear(); break;
                    }
                    readEscape = false;
                }
            }
            bool CheckCrc(int len)
            {
                ushort crc = 0;
                for (int i = 0; i < len; i++)
                    crc += reader[i];

                crc = (ushort)(~crc + 1);
                if (reader[len] == (byte)crc)
                    return reader[len + 1] == (byte)(crc >> 8);
                return false;
            }
        }
        #endregion

        #region ReadCommand
        internal void ReadCommand()
        {
            Logger.Trace($"Read: {reader.Command}; Sequence: {reader[1]}; status: {reader.Status}; length: {reader.Length}");

            ZigbeeNode? n = null;
            switch (reader.Command)
            {
                case ConbeeCommand.VERSION:
                    {
                        Firmware = reader[6] switch
                        {
                            5 => $"Conbee or RaspBee (Major:{reader[8]} Minor:{reader[7]})",
                            7 => $"Conbee II (Major:{reader[8]} Minor:{reader[7]})",
                            _ => $"Unknown  (Major:{reader[8]} Minor:{reader[7]})",
                        };
                        Logger.Info(Firmware);
                        break;
                    }
                case ConbeeCommand.READ_PARAMETER:
                    Logger.Trace(ReadParameter());
                    break;
                case ConbeeCommand.DEVICE_STATE:
                    HandleApsFrame(reader[5], true);
                    break;
                case ConbeeCommand.DEVICE_STATE_CHANGED:
                    HandleApsFrame(reader[5], false);
                    break;
                case ConbeeCommand.APS_DATA_INDICATION:
                    if (reader.Status == ConbeeStatus.SUCCESS)
                    {
                        ReadNode(8);
                        reader.ReadByte();
                        n = ReadNode(reader.Offset);
                        var endPoint = reader.ReadByte();
                        ushort profileId = reader.ReadUInt16();
                        ushort clusterId = reader.ReadUInt16();
                        reader.Payload = reader.Offset + reader.ReadUInt16();
                        var seq = profileId switch
                        {
                            0 => n.ZdoResponse(clusterId, endPoint, reader),
                            260 => n.ZclResponse(clusterId, endPoint, reader), 
                            _ => 0
                        };
                        if (requests[seq] is ZigbeeRequest rq)
                        {
                            rq.TaskSource?.SetResult(true);
                            requests[seq] = null;
                        }
                    }
                    HandleApsFrame(reader[7], true);
                    break;
                case ConbeeCommand.MAC_POLL_INDICATION:
                    n = ReadNode(7);
                    if (n != null)
                    {
                        n.Poll();
                        n.Requests.ForEach(r => commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, r)));
                        n.Requests.Clear();
                    }
                    break;
                case ConbeeCommand.APS_DATA_REQUEST:
                    HandleApsFrame(reader[7], true);
                    break;
                case ConbeeCommand.APS_DATA_CONFIRM:
                    ZigbeeRequest? drq = requests[reader[8]];
                    int cfStatus = -1;
                    if (drq != null && drq != null)
                    {
                        Logger.Info($"Request: {reader[8]}");
                        if (reader.Status == ConbeeStatus.SUCCESS)
                        {
                            n = ReadNode(9);
                            reader.ReadByte();
                            var res = reader.ReadByte();
                            cfStatus = reader.ReadByte();
                            if (cfStatus != 0 && drq.Retry-- > 0)
                            {
                                commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, drq));
                                return;
                            }
                        }
                        if (drq.ProfileId == 0)
                            Logger.Trace($"Zdo Node: 0x{n?.Addr16:x4} {drq.ProfileId:X4}:{drq.ClusterId:X4} Remove: {reader[8]} Status:{cfStatus:X2} aspe:{reader[7]:X4}");
                        else
                            Logger.Trace($"Zcl Node: 0x{n?.Addr16:x4} {drq.ProfileId:X4}:{drq.ClusterId:X4} Remove: {reader[8]} Status:{cfStatus:X2} aspe:{reader[7]:X4}");
                    }
                    HandleApsFrame(reader[7], true);
                    break;
            }

            void HandleApsFrame(byte apsde, bool allowCommand)
            {
                conbeeAPSDE = apsde;
                if (reader.Command != ConbeeCommand.APS_DATA_INDICATION && (apsde & 0x08) != 0)
                    WriteCommand(ConbeeCommand.APS_DATA_INDICATION);
                else if ((apsde & 0x04) != 0)
                    WriteCommand(ConbeeCommand.APS_DATA_CONFIRM);
                else if (allowCommand && ((apsde & 0x20) != 0) && commands.TryDequeue(out var cmd))
                    WriteCommand(cmd.command, cmd.parameter);
            }
        }
        #endregion

        #region ReadNode
        internal ZigbeeNode ReadNode(int offset)
        {
            reader.Offset = offset;
            byte mode = reader.ReadByte();
            return mode switch
            {
                1 => CreateNode(reader.ReadUInt16()),
                2 => CreateNode(reader.ReadUInt16()),
                3 => throw new Exception("Unsupported address mode"),
                4 => throw new Exception("Unsupported address mode"),
                _ => throw new Exception("Unsupported address mode"),
            };
        }
        #endregion

        #region ReadParameter
        private string ReadParameter()
        {
            reader.Offset = 5;
            short size = reader.ReadInt16();
            return (ConbeeParameter)reader.ReadByte() switch
            {
                ConbeeParameter.MacAddress => $"MacAddress: {parameters.MacAddress = reader.ReadUInt64()}",
                ConbeeParameter.NwkPanId => $"NwkPanId: {parameters.NwkPanId = reader.ReadUInt16()}",
                ConbeeParameter.NwkAddress => $"NwkAddress: {parameters.NwkAddress = reader.ReadUInt16()}",
                ConbeeParameter.NwkExtendedPanId => $"NwkExtendedPanId: {parameters.NwkExtendedPanId = reader.ReadUInt64()}",
                ConbeeParameter.ApsDesignedCoordinator => $"ApsDesignedCoordinator: {parameters.ApsDesignedCoordinator = reader.ReadByte()}",
                ConbeeParameter.ChannelMask => $"ChannelMask: {parameters.ChannelMask = reader.ReadUInt16()}",
                ConbeeParameter.ApsExtendedPanId => $"ApsExtendedPanId: {parameters.ApsExtendedPanId = reader.ReadUInt64()}",
                ConbeeParameter.TrustCenterAddress => $"TrustCenterAddress: {parameters.TrustCenterAddress = reader.ReadUInt64()}",
                ConbeeParameter.SecurityMode => $"SecurityMode: {parameters.SecurityMode = reader.ReadByte()}",
                ConbeeParameter.NetworkKey => "NetworkKey: " + (parameters.NetworkKey = reader.ReadString(size - 1)),
                ConbeeParameter.CurrentChannel => $"CurrentChannel: {parameters.CurrentChannel = reader.ReadByte()}",
                ConbeeParameter.ProtocolVersion => $"ProtocolVersion: {parameters.ProtocolVersion = reader.ReadUInt16()}",
                ConbeeParameter.NwkUpdateId => $"NwkUpdateId: {parameters.NwkUpdateId = reader.ReadByte()}",
                ConbeeParameter.WatchdogTTL => $"WatchdogTTL: {parameters.WatchdogTTL = reader.ReadUInt16()}",
                _ => "Invalid parameter",
            };
        }
        #endregion

        #region WriteCommand
        private void WriteCommand(ConbeeCommand command, object? parameter = null)
        {
            //Thread.Sleep(0);
            //if (port?.IsOpen != true)
            //    return;

            //int msec = (int)(portcheck - DateTime.Now).TotalMilliseconds;
            //if (msec > 0)
            //    Thread.Sleep(msec);

            writer.Length = 0;
            ushort crc = 0;
            port.BaseStream.WriteByte(192);
            write((byte)command);
            write(++writeSequence);
            write(0);
            switch (command)
            {
                default:
                    return;
                case ConbeeCommand.VERSION:
                    writer.Write(0, 0, 0, 0);
                    break;
                case ConbeeCommand.DEVICE_STATE:
                    writer.Write(0, 0, 0);
                    break;
                case ConbeeCommand.READ_PARAMETER:
                    if (parameter is ConbeeParameter cp)
                        writer.Write(1, 0, (byte)cp);
                    break;
                case ConbeeCommand.APS_DATA_CONFIRM:
                    writer.Write(0, 0);
                    break;
                case ConbeeCommand.APS_DATA_INDICATION:
                    writer.Write(0, 0);
                    break;
                case ConbeeCommand.APS_DATA_REQUEST:
                    if (parameter is ZigbeeRequest rq)
                    {
                        requests[rq.TransactionId = ++writeRequestId] = rq;
                        rq.WriteRequest(writer);
                    }
                    break;
            }
            if (command == ConbeeCommand.APS_DATA_REQUEST)
            {
                ushort len2 = (ushort)(7 + writer.Length);
                write((byte)len2);
                write((byte)(len2 >> 8));
                write((byte)writer.Length);
                write((byte)(writer.Length >> 8));
                //Logger.Trace($"Send {command}; apsde: {conbeeAPSDE:X2}; sequence: {writeSequence}; request: {writeRequestId}");
            }
            else
            {
                ushort len = (ushort)(5 + writer.Length);
                write((byte)len);
                write((byte)(len >> 8));
                //if (command == ConbeeCommand.APS_DATA_INDICATION)
                //    Logger.Trace($"Send {command}; apsde: {conbeeAPSDE:X2}; sequence: {writeSequence}");
            }
            writer.WritePayload(write);
            crc = (ushort)(~crc + 1);
            port.BaseStream.WriteByte((byte)crc);
            port.BaseStream.WriteByte((byte)(crc >> 8));
            port.BaseStream.WriteByte(192);
            portCheck = DateTime.Now.AddMilliseconds(50);
            void write(byte b)
            {
                crc += b;
                switch (b)
                {
                    case 0xC0:
                        port.BaseStream.WriteByte(0xDB);
                        port.BaseStream.WriteByte(0xDC);
                        break;
                    case 0xDB:
                        port.BaseStream.WriteByte(0xDB);
                        port.BaseStream.WriteByte(0xDD);
                        break;
                    default:
                        port.BaseStream.WriteByte(b);
                        break;
                }
            }
        }
        #endregion

        #region SendAsync
        public override async Task SendAsync(ZigbeeRequest request)
        {
            try
            {
                request.TaskSource = new TaskCompletionSource<bool>();
                var ct = new CancellationTokenSource(3000);
                ct.Token.Register(() => request.TaskSource.TrySetCanceled(), useSynchronizationContext: false);

                commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, request));
                await request.TaskSource.Task;
            }
            catch 
            {
            }
        }
        #endregion
    }
}