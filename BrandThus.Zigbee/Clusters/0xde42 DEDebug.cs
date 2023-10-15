namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for debugging purposes.
/// <summary>
[Cluster(0xde42, "DE Debug")]
public static class ZclDEDebug
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDEDebug));

    public static ReportAttribute DebugEnabled { get; } = zcl.Report(0x0000, "Debug enabled", r => r.ReadBool());
    public static ReportAttribute DebugDestination { get; } = zcl.Report(0x0001, "Debug destination", r => r.ReadUInt16());

}
