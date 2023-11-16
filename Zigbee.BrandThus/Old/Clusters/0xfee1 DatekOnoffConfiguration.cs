namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Datek on/off configuration attributes.
/// <summary>
[Cluster(0xfee1, "Datek on/off configuration")]
public static class ZclDatekOnoffConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDatekOnoffConfiguration));

    public static ReportAttribute OffIfOffline { get; } = zcl.Report(0x0000, "Off if offline", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute FrostGuardTemperature { get; } = zcl.Report(0x0001, "Frost guard temperature", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute FrostGuardTemperatureHysteresis { get; } = zcl.Report(0x0002, "Frost guard temperature hysteresis", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute FrostGuardMinsBetweenChange { get; } = zcl.Report(0x0003, "Frost guard mins between change", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute OnTime { get; } = zcl.Report(0x0004, "On time", ZigbeeType.U16, r => r.ReadUInt16());
    public enum OnoffConfigurationModeEnum
    {
        Off = 0x00,
        On = 0x01,
    }

    public static ReportAttribute OnoffConfigurationMode { get; } = zcl.Report(0x0010, "On/off configuration mode", ZigbeeType.Enum8, r => (OnoffConfigurationModeEnum)r.ReadByte());
    public static ReportAttribute ClusterRevision { get; } = zcl.Report(0xFFFD, "Cluster revision", ZigbeeType.U16, r => r.ReadUInt16());
}
