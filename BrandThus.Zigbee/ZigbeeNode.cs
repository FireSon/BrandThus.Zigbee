using BrandThus.Zigbee.Zcl;
using BrandThus.Zigbee.Zdo;

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

    internal ZigbeeManager Manager = manager;
    #endregion

    #region Descriptors
    public ZdoRequest NodeDescriptor() => Zdo(2, w => w + Addr16);
    public ZdoRequest PowerDescriptor() => Zdo(3, w => w + Addr16);
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
}
