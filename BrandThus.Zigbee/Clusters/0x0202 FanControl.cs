namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster specifies an interface to control the speed of a fan as part of a heating / cooling system.
/// <summary>
[Cluster(0x0202, "Fan Control")]
public static class ZclFanControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclFanControl));

    public static ReportAttribute FanMode { get; } = zcl.Report(0x0000, "Fan Mode", r => r.ReadByte());
    public static ReportAttribute FanModeSequence { get; } = zcl.Report(0x0001, "Fan Mode Sequence", r => r.ReadByte());
}
