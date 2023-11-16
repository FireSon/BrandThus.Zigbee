namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster specifies an interface to control the speed of a fan as part of a heating / cooling system.
/// <summary>
[Cluster(0x0202, "Fan Control")]
public static class ZclFanControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclFanControl));

    public enum FanModeEnum
    {
        Off = 0x00,
        Low = 0x01,
        Medium = 0x02,
        High = 0x03,
        On = 0x04,
        Auto = 0x05,
        Smart = 0x06,
    }

    public static ReportAttribute FanMode { get; } = zcl.Report(0x0000, "Fan Mode", ZigbeeType.Enum8, r => (FanModeEnum)r.ReadByte());
    public enum FanModeSequenceEnum
    {
        LowMedHigh = 0x00,
        LowHigh = 0x01,
        LowMedHighAuto = 0x02,
        LowHighAuto = 0x03,
        OnAuto = 0x04,
    }

    public static ReportAttribute FanModeSequence { get; } = zcl.Report(0x0001, "Fan Mode Sequence", ZigbeeType.Enum8, r => (FanModeSequenceEnum)r.ReadByte());
}
