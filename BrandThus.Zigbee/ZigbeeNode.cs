using BrandThus.Zigbee.Zcl;
using BrandThus.Zigbee.Zdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrandThus.Zigbee
{
    public class ZigbeeNode
    {
        #region Constructor
        public ZigbeeNode(ZigbeeManager manager, ushort addr16)
        {
            Manager = manager;
            Addr16 = addr16;
        }
        #endregion

        #region Properties
        public Action? OnPoll { get; set; }
        public ushort Addr16 { get; internal set; }
        public ulong Addr64 { get; internal set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public NodeDescriptor? Descriptor { get; set; }
        public PowerDescriptor? Power { get; set; }
        public SimpleDescriptor? Simple { get; set; }
        public ComplexDescriptor? Complex { get; set; }
        public List<ZigbeeRequest> Requests { get; } = new List<ZigbeeRequest>();
        public object? Device { get; set; }

        internal ZigbeeManager Manager;
        internal Dictionary<int, object> Values = new Dictionary<int, object>();

        private const byte MASK_MANUFACTURER_SPECIFIC = 4;
        private static Dictionary<int, Type> clusterTypes = new Dictionary<int, Type>();
        #endregion

        #region Poll
        internal void Poll()
        {
            if (Addr64 == 0)
                Requests.Add(IEEEDescriptor());
            if (Descriptor == null)
                Requests.Add(NodeDescriptor());
            if (Power == null)
                Requests.Add(NodeDescriptor());

        }
        #endregion

        #region Zdo
        internal ZdoRequest Zdo(ushort clusterId, Func<ZigbeeWriter, ZigbeeWriter> write) => new ZdoRequest(write)
        {
            ProfileId = 0,
            ClusterId = clusterId,
            Dst = this,
            DstEndPoint = 0,
            Src = Manager.Coordinator,
            SrcEndPoint = 0,
            Radius = 0,
        };
        #endregion

        #region Zdo Descriptors
        public ZdoRequest IEEEDescriptor() => Zdo(1, w => w + Addr16 + (byte)0 + (byte)0);
        public ZdoRequest NodeDescriptor() => Zdo(2, w => w + Addr16);
        public ZdoRequest PowerDescriptor() => Zdo(3, w => w + Addr16);
        public ZdoRequest SimpleDescriptor(byte endpoint = 1) => Zdo(4, w => w + Addr16 + endpoint);
        public ZdoRequest EndPoints() => Zdo(5, w => w + Addr16);
        public ZdoRequest ComplexDescriptor() => Zdo(16, w => w + Addr16);
        #endregion

        #region ZdoResponse
        internal byte ZdoResponse(ushort clusterId, byte endPoint, ZigbeeReader r)
        {
            Logger.Info($"Addr:0x{Addr16:X4} - {endPoint}");
            var seq = r.ReadByte();
            var status = (ZdoStatus)r.ReadByte();
            if (status == ZdoStatus.SUCCESS)
                switch (clusterId)
                {
                    case 0x8001://IEEE response
                        Addr64 = r.ReadUInt64();
                        ushort NwkAddr = r.ReadUInt16();
                        Logger.Info($"0x{Addr16:X4} - IEEE Address");
                        break;
                    case 0x8002://NodeDescriptor response
                        NwkAddr = r.ReadUInt16();
                        Descriptor = new NodeDescriptor(r);
                        Logger.Info($"0x{Addr16:X4} NodeDescriptor -> : {Addr16:X4} - {Descriptor}");
                        break;
                    case 0x8003:
                        NwkAddr = r.ReadUInt16();
                        Power = new PowerDescriptor(r);
                        Logger.Info($"0x{Addr16:X4} PowerDescriptor -> Addr: {Addr16:X4} - Power: {Power}");
                        break;
                    case 0x8004:
                        NwkAddr = r.ReadUInt16();
                        Simple = new SimpleDescriptor(r);
                        Logger.Info($"{Addr16:X4} - {Simple}");
                        break;
                    case 0x8005:
                        //NwkAddr = r.ReadUInt16();
                        ////Endpoints = r.ReadList<byte>();
                        //Logger.Info($"0x{Addr16:X4} - {new Func<ZdoRequest>(EndPoints)}");
                        break;
                    case 0x8010:
                        //Complex = new ComplexDescriptor(r.ReadByte(), r.ReadString(), r.ReadString(), r.ReadString());
                        break;
                    default:
                        break;
                }
            return seq;
        }
        #endregion

        #region Zcl
        internal ZclRequest ZclRequest(ZigbeeCluster cluster, byte command, Func<ZigbeeWriter, ZigbeeWriter>? write = null, ZclFrameType frameType = ZclFrameType.CLUSTER_SPECIFIC_COMMAND) => new ZclRequest(write)
        {
            ClusterId = cluster.Id,
            ProfileId = 260,
            Dst = this,
            DstEndPoint = 1,
            Src = Manager.Coordinator,
            SrcEndPoint = 1,
            Radius = 31,
            Direction = ZclCommandDirection.CLIENT_TO_SERVER,
            FrameType = frameType,
            CommandId = command
        };
        internal void Zcl(ZigbeeCluster cluster, byte command, Func<ZigbeeWriter, ZigbeeWriter>? write = null, ZclFrameType frameType = ZclFrameType.CLUSTER_SPECIFIC_COMMAND) =>
            Requests.Add(ZclRequest(cluster, command, write, frameType));
        #endregion

        #region ZclResponse
        internal byte ZclResponse(ushort clusterId, byte endPoint, ZigbeeReader r)
        {
            if ((r.ReadByte() & MASK_MANUFACTURER_SPECIFIC) != 0)
            {
                ushort ManufacturerCode = r.ReadUInt16();
                Logger.Info($"0x{Addr16:X4} ManufacturerCode: " + ManufacturerCode);
            }
            byte seq = r.ReadByte();
            Logger.Info($"RequestId {seq}");
            var cmd = (ZclCommand)r.ReadByte();
            switch (cmd)
            {
                case ZclCommand.ReadAttributesResponse:
                    if (cmd == ZclCommand.ReadAttributesResponse)
                        Read(noStatus: false);
                    break;
                case ZclCommand.ReadAttributes:
                case ZclCommand.ReportAttributes:
                    Read();
                    break;
                case ZclCommand.DefaultResponse:
                    r.ReadByte();
                    break;
            }
            return seq;

            void Read(bool noStatus = true)
            {
                while (!r.IsReady)
                {
                    int key = (clusterId << 16) + r.ReadUInt16();
                    if (!ZigbeeAttribute.Attributes.TryGetValue(key, out var zigbeeAttribute))
                    {
                        if (clusterTypes.Count == 0)
                            foreach (Type item in from t in GetType().Assembly.GetTypes()
                                                  where t.DeclaringType == null && (t.FullName?.StartsWith("BrandThus.Zigbee.Clusters.") ?? false)
                                                  select t)
                            {
                                var c = item.GetCustomAttribute<ClusterAttribute>();
                                if (c != null)
                                    clusterTypes[c.ClusterId] = item;
                            }

                        if (clusterTypes.TryGetValue(clusterId, out var clusterType))
                            RuntimeHelpers.RunClassConstructor(clusterType.TypeHandle);

                        if (clusterType == null || !ZigbeeAttribute.Attributes.TryGetValue(key, out zigbeeAttribute))
                        {
                            Logger.Info("Req:" + seq.ToString() + " Node: " + Addr16.ToString("X4") + "=> Unknown attribute");
                            break;
                        }
                    }
                    var zclStatus = noStatus ? ZclStatus.SUCCESS : (ZclStatus)r.ReadByte();
                    if (zclStatus == ZclStatus.SUCCESS)
                        try
                        {
                            int num2 = (int)r.ReadByte();
                            object obj = zigbeeAttribute.Read(r);
                            Values[key] = obj;
                            Logger.Info($"Addr 0x{Addr16:X4} Ep:{endPoint}; Attr: {zigbeeAttribute.Cluster.Name} {zigbeeAttribute.AttrId:X4} {zigbeeAttribute.Name}: {obj}");
                            Manager.OnUpdate?.Invoke(this, zigbeeAttribute, endPoint, obj);
                        }
                        catch (Exception ex)
                        {
                            ex.Trace();
                        }
                    else
                        Logger.Info($"{Addr16:X4} {endPoint}; Attr: {zigbeeAttribute.Cluster.Name} {zigbeeAttribute.AttrId:X4} {zigbeeAttribute.Name}: {zclStatus}");
                }
            }
        }
        #endregion

        #region Read
        internal void Read(params IReadable[] attributes) => Manager.SendAsync(ZclRequest(attributes[0].Cluster, 0, w =>
        {
            foreach (var a in attributes)
                w.WriteUInt16(a.AttrId);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));
        #endregion

        #region ReadAsync
        internal async Task<T> ReadAsync<T>(ZigbeeAttribute<T> attr)
        {
            var r = ZclRequest(attr.Cluster, 0, w => w + attr.AttrId, ZclFrameType.ENTIRE_PROFILE_COMMAND);
            await Manager.SendAsync(r);
            if (Values.TryGetValue((attr.Cluster.Id << 16) + attr.AttrId, out var value)) 
                return (T)value; 
            return default!;
        }
        #endregion

        #region Report
        internal void Report<T>(ZigbeeAttribute<T> attr, ushort minTime, ushort maxTime, T t) => Requests.Add(ZclRequest(attr.Cluster, 6, w =>
        {
            w.WriteByte(0);
            w.WriteUInt16(attr.AttrId);
            w.WriteByte((byte)attr.Type);
            w.WriteUInt16(minTime);
            w.WriteUInt16(maxTime);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));

        internal void Report<T>(ZigbeeAttribute<T> attr, ushort minTime, ushort maxTime) => Requests.Add(ZclRequest(attr.Cluster, 6, w =>
        {
            w.WriteByte(0);
            w.WriteUInt16(attr.AttrId);
            w.WriteByte((byte)attr.Type);
            w.WriteUInt16(minTime);
            w.WriteUInt16(maxTime);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));

        internal Task ReportAsync<T>(ZigbeeAttribute<T> attr, ushort minTime, ushort maxTime) => Manager.SendAsync(ZclRequest(attr.Cluster, 6, w =>
        {
            w.WriteByte(0);
            w.WriteUInt16(attr.AttrId);
            w.WriteByte((byte)attr.Type);
            w.WriteUInt16(minTime);
            w.WriteUInt16(maxTime);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));

        internal Task ReportAsync<T>(Analog<T> attr, ushort minTime, ushort maxTime, T t) => Manager.SendAsync(ZclRequest(attr.Cluster, 6, w =>
        {
            w.WriteByte(0);
            w.WriteUInt16(attr.AttrId);
            w.WriteByte((byte)attr.Type);
            w.WriteUInt16(minTime);
            w.WriteUInt16(maxTime);
            attr.Write(w, t);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));
        #endregion

        #region Write
        internal void Write<T>(ZigbeeAttribute<T> attr, T t) => Requests.Add(ZclRequest(attr.Cluster, 6, w =>
        {
            w.WriteByte(0);
            w.WriteUInt16(attr.AttrId);
            w.WriteByte((byte)attr.Type);
            return w;
        }, ZclFrameType.ENTIRE_PROFILE_COMMAND));
        #endregion
    }
}
