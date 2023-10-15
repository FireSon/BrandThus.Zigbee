namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides a basic interface to a real-time clock.
/// <summary>
[Cluster(0x000a, "Time")]
public static class ZclTime
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTime));

    public static ReportAttribute Time { get; } = zcl.Report(0000, "Time", r => r.ReadDateTime());
    public static ReportAttribute TimeStatus { get; } = zcl.Report(0001, "Time Status", r => r.ReadByte());
    public static ReportAttribute TimeZone { get; } = zcl.Report(0002, "Time Zone", r => r.ReadInt32());
    public static ReportAttribute DstStart { get; } = zcl.Report(0003, "Dst Start", r => r.ReadUInt32());
    public static ReportAttribute DstEnd { get; } = zcl.Report(0004, "Dst End", r => r.ReadUInt32());
    public static ReportAttribute DstShift { get; } = zcl.Report(0005, "Dst Shift", r => r.ReadInt32());
    public static ReportAttribute StandardTime { get; } = zcl.Report(0006, "Standard Time", r => r.ReadUInt32());
    public static ReportAttribute LocalTime { get; } = zcl.Report(0007, "Local Time", r => r.ReadUInt32());
    public static ReportAttribute LastSetTime { get; } = zcl.Report(0008, "Last Set Time", r => r.ReadDateTime());
    public static ReportAttribute ValidUntilTime { get; } = zcl.Report(0009, "Valid Until Time", r => r.ReadDateTime());
}
