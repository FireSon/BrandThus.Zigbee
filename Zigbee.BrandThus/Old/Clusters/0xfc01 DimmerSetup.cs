namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands.
/// <summary>
[Cluster(0xfc01, "Dimmer Setup")]
public static class ZclDimmerSetup
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDimmerSetup));

    public static ReportAttribute Capabilities { get; } = zcl.Report(0x0000, "Capabilities", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute Status { get; } = zcl.Report(0x0001, "Status", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute Mode { get; } = zcl.Report(0x0002, "Mode", ZigbeeType.Bmp8, r => r.ReadByte());
}
