using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrandThus.Zigbee.Conbee;

public class ConbeeManager : ZigbeeManager
{
    #region Constructor
    public ConbeeManager(IConfiguration configuration, CancellationToken stoppingToken)
    {
        ////Load the Nodes
        //var s = configuration.GetSection("Zigbee:Nodes");
        //if (s.Exists())
        //    foreach (var c in s.GetChildren())
        //        if (c.Value is string addr && !string.IsNullOrWhiteSpace(addr))
        //            Nodes.Add(addr, new ZigbeeNode(this));

        //Open the SerialPort
        portName = configuration["Zigbee:Port"] ?? "";
        portThread = new Thread(() => HandlePort(stoppingToken)) { Priority = ThreadPriority.Normal, IsBackground = true, Name = "Conbee" };
        portThread.Start();

        //Check logLevel
        if (configuration["Zigbee:Logging"] is string l)
            Logger.LogLevel = Enum.Parse<LogType>(l);
    }
    #endregion

    #region Properties
    private readonly string portName;
    private DateTime portcheck;
    private SerialPort? port;
    private readonly Thread portThread;
    private DateTime allowJoin;
    private readonly ConcurrentQueue<(ConbeeCommand command, object? parameter)> commands = new();
    private byte conbeeAPSDE;
    private bool readEscape;
    private readonly ConbeeParameters parameters = new();
    private readonly ConbeeReader reader = new();
    private readonly ZigbeeRequest?[] requests = new ZigbeeRequest[256];
    private readonly ConbeeWriter writer = new();
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
                    TimeSpan msec = portcheck - DateTime.Now;
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

                    Nodes[0] = (Coordinator = new ZigbeeNode(this) { Addr16 = 0 });
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
                    if (!commands.IsEmpty && (conbeeAPSDE == 0 || (conbeeAPSDE & 0x7F) != 0) && portcheck < DateTime.Now)
                        WriteCommand(ConbeeCommand.DEVICE_STATE);
                }
                Thread.Sleep(1);
            }
            catch (FileNotFoundException)
            {
                port?.Dispose();
                port = null;
                portcheck = DateTime.Now.AddSeconds(5);
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
                    case 192:
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
                    case 219:
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
                    case 220: reader.Add(192); break;
                    case 221: reader.Add(219); break;
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
                    switch (profileId)
                    {
                        case 0: n.ZdoResponse(clusterId, endPoint, reader); break;
                        case 260: n.ZclResponse(clusterId, endPoint, reader); break;
                    }
                }
                HandleApsFrame(reader[7], true);
                if (n?.Requests.Count > 0)
                {
                    commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, n.NodeDescriptor()));
                }
                break;
            case ConbeeCommand.MAC_POLL_INDICATION:
                n = ReadNode(7);
                if (n.Requests.Count > 0)
                {
                    n.Requests.ForEach(r => commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, r)));
                    n.Requests.Clear();
                }
                //Logger.Info($"Poll Node: {n?.Addr16}");
                //if (n?.Descriptor == null)
                //    commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, n.NodeDescriptor()));
                break;
            case ConbeeCommand.APS_DATA_REQUEST:
                HandleApsFrame(reader[7], true);
                break;
            case ConbeeCommand.APS_DATA_CONFIRM:
                ZigbeeRequest? drq = requests[reader[8]];
                if (drq != null && drq != null)
                {
                    requests[reader[8]] = null;
                    int cfStatus = -1;
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
                    //drq.TaskSource.SetResult(cfStatus == 0);
                    if (drq.ProfileId == 0)
                        Logger.Trace($"Zdo Node: {n?.Addr16} {drq.ProfileId:X4}:{drq.ClusterId:X4} Remove: {reader[8]} Status:{cfStatus}");
                    else
                        Logger.Trace($"Zcl Node: {n?.Addr16} {drq.ProfileId:X4}:{drq.ClusterId:X4} Remove: {reader[8]} Status:{cfStatus}");
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
                    Logger.Info("Write request");
                    requests[rq.TransactionId = ++writeRequestId] = rq;
                    writer.WriteRequest(rq);
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
            if (command == ConbeeCommand.APS_DATA_INDICATION)
                Logger.Trace($"Send {command}; apsde: {conbeeAPSDE:X2}; sequence: {writeSequence}");
        }
        writer.WritePayload(write);
        crc = (ushort)(~crc + 1);
        port.BaseStream.WriteByte((byte)crc);
        port.BaseStream.WriteByte((byte)(crc >> 8));
        port.BaseStream.WriteByte(192);
        portcheck = DateTime.Now.AddMilliseconds(50);
        void write(byte b)
        {
            crc += b;
            switch (b)
            {
                case 192:
                    port.BaseStream.WriteByte(219);
                    port.BaseStream.WriteByte(220);
                    break;
                case 219:
                    port.BaseStream.WriteByte(219);
                    port.BaseStream.WriteByte(221);
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
        commands.Enqueue((ConbeeCommand.APS_DATA_REQUEST, request));
        await request.TaskSource.Task;
    }
    #endregion
}