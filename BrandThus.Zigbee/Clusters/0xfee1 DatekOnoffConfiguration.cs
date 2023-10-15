namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Datek on/off configuration attributes.
/// <summary>
[Cluster(0xfee1, "Datek on/off configuration")]
public static class ZclDatekOnoffConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDatekOnoffConfiguration));

    public static ReportAttribute OffIfOffline { get; } = zcl.Report(0x0000, "Off if offline", r => r.ReadByte());
    public static ReportAttribute FrostGuardTemperature { get; } = zcl.Report(0x0001, "Frost guard temperature", r => r.ReadByte());
    public static ReportAttribute FrostGuardTemperatureHysteresis { get; } = zcl.Report(0x0002, "Frost guard temperature hysteresis", r => r.ReadByte());
    public static ReportAttribute FrostGuardMinsBetweenChange { get; } = zcl.Report(0x0003, "Frost guard mins between change", r => r.ReadByte());
    public static ReportAttribute OnTime { get; } = zcl.Report(0x0004, "On time", r => r.ReadUInt16());
    public static ReportAttribute OnoffConfigurationMode { get; } = zcl.Report(0x0010, "On/off configuration mode", r => r.ReadByte());
    public static ReportAttribute ClusterRevision { get; } = zcl.Report(0xFFFD, "Cluster revision", r => r.ReadUInt16());
}
