using BrandThus.Zigbee.Descriptors;
using BrandThus.Zigbee.Zcl;
using BrandThus.Zigbee.Zdo;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace BrandThus.Zigbee;

public class ZigbeeNode(ZigbeeManager manager)
{
    #region Properties
    public Action<ZigbeeAttribute, byte, object>? OnUpdate { get; set; }
    public Action? OnPoll { get; set; }
    public ushort Addr16 { get; internal set; }
    public ulong Addr64 { get; internal set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public NodeDescriptor? Descriptor { get; set; }
    public PowerDescriptor? Power { get; set; }
    public SimpleDescriptor? Simple { get; set; }
    public ComplexDescriptor? Complex { get; set; }

    internal ZigbeeManager Manager = manager;
    private const byte MASK_MANUFACTURER_SPECIFIC = 4;
    private static Dictionary<int, Type> clusterTypes = new();
    #endregion

    #region Descriptors
    public Task NodeDescriptor() => Manager.SendAsync(Zdo(2, w => w + Addr16));
    public Task PowerDescriptor() => Manager.SendAsync(Zdo(3, w => w + Addr16));
    public ZdoRequest SimpleDescriptor() => Zdo(4, w => w + Addr16 + (byte)1);
    public ZdoRequest EndPoints() => Zdo(5, w => w + Addr16);
    public ZdoRequest ComplexDescriptor() => Zdo(16, w => w + Addr16);
    #endregion

    #region Zdo
    internal ZdoRequest Zdo(ushort clusterId, Func<ZigbeeWriter, ZigbeeWriter> write) => new(write)
    {
        ProfileId = 0,
        ClusterId = clusterId,
        Dst = this,
        DstEndPoint = 0,
        Src = Manager.Coordinator,
        SrcEndPoint = 0
    };
    #endregion

    #region ZdoResponse
    internal void ZdoResponse(ushort clusterId, byte endPoint, ZigbeeReader r)
    {
        r.ReadByte();
        ZdoStatus num = r.ReadStatus();
        ushort NwkAddr = r.ReadUInt16();
        if (num == ZdoStatus.SUCCESS && NwkAddr == Addr16)
        {
            switch (clusterId)
            {
                case 32770:
                    Descriptor = new (r.ReadByte(), r.ReadByte(), r.ReadByte(), r.ReadUInt16(), r.ReadByte(), r.ReadUInt16(), r.ReadUInt16(), r.ReadUInt16(), r.ReadByte());
                    Logger.Info($"Descriptor: {Addr16} - {Descriptor}");
                    break;
                //case 32771:
                //    Power = new PowerDescriptor(r.ReadUInt16());
                //    Logger.Info($"{Addr16} - {Power}");
                //    break;
                //case 32772:
                //    Simple = new SimpleDescriptor(r.ReadByte(), r.ReadUInt16(), r.ReadByte(), r.ReadList<ushort>(), r.ReadList<ushort>());
                //    Logger.Info($"{node2.Addr16} - {node2.Simple}");
                //    break;
                //case 32773:
                //    Endpoints = r.ReadList<byte>();
                //    Logger.Info($"{node2.Addr16} - {new Func<ZdoRequest>(EndPoints)}");
                //    break;
                //case 32784:
                //    Complex = new ComplexDescriptor(r.ReadByte(), r.ReadString(), r.ReadString(), r.ReadString());
                //    break;
                default:
                    break;
            }
        }
    }
    #endregion

    #region Zcl
    internal Task Zcl(ZigbeeCluster cluster, byte command, Func<ZigbeeWriter, ZigbeeWriter>? write = null, ZclFrameType frameType = ZclFrameType.CLUSTER_SPECIFIC_COMMAND) => Manager.SendAsync(new ZclRequest(write)
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
    });
    #endregion

    #region ZclResponse
    internal void ZclResponse(ushort clusterId, byte endPoint, ZigbeeReader r)
    {
        if ((r.ReadByte() & MASK_MANUFACTURER_SPECIFIC) != 0)
        {
            ushort ManufacturerCode = r.ReadUInt16();
            Logger.Info("ManufacturerCode: " + ManufacturerCode);
        }
        byte seq = r.ReadByte();
        ZclCommand cmd = (ZclCommand)r.ReadByte();
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
        void Read(bool noStatus = true)
        {
            while (!r.IsReady)
            {
                int key = ((int)clusterId << 16) + (int)r.ReadUInt16();
                if (!ZigbeeAttribute.Attributes.TryGetValue(key, out var zigbeeAttribute))
                {
                    if(clusterTypes.Count == 0)
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
                        Logger.Info("Req:" + seq.ToString() + " Node: " + Addr16.ToString() + "=> Unknown attribute");
                        break;
                    }
                    else
                        Console.WriteLine(clusterType.Name);
                }
                var zclStatus = noStatus ? ZclStatus.SUCCESS : (ZclStatus)r.ReadByte();
                if (zclStatus == ZclStatus.SUCCESS)
                    try
                    {
                        int num2 = (int)r.ReadByte();
                        object obj = zigbeeAttribute.Read(r);
                        Logger.Info($"{Addr16} {endPoint}; Attr: {zigbeeAttribute.Cluster.Name} {zigbeeAttribute.AttrId:X4} {zigbeeAttribute.Name}: {obj}");
                        OnUpdate?.Invoke(zigbeeAttribute, endPoint, obj);
                    }
                    catch (Exception ex)
                    {
                        ex.Trace();
                    }
                else
                    Logger.Info($"{Addr16} {endPoint}; Attr: {zigbeeAttribute.Cluster.Name} {zigbeeAttribute.AttrId:X4} {zigbeeAttribute.Name}: {zclStatus}");
            }
        }
    }
    #endregion
}
