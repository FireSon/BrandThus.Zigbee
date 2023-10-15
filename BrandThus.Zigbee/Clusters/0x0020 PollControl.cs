namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides a mechanism for the management of an end device’s MAC Data Request rate.
/// <summary>
[Cluster(0x0020, "Poll Control")]
public static class ZclPollControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPollControl));

    public static ReportAttribute CheckinInterval { get; } = zcl.Report(0x0000, "Check-in Interval", r => r.ReadUInt32());
    public static ReportAttribute LongPollInterval { get; } = zcl.Report(0x0001, "Long Poll Interval", r => r.ReadUInt32());
    public static ReportAttribute ShortPollInterval { get; } = zcl.Report(0x0002, "Short Poll Interval", r => r.ReadUInt16());
    public static ReportAttribute FastPollTimeout { get; } = zcl.Report(0x0003, "Fast Poll Timeout", r => r.ReadUInt16());
    public static ReportAttribute CheckinIntervalMin { get; } = zcl.Report(0x0004, "Check-in Interval Min", r => r.ReadUInt32());
    public static ReportAttribute LongPollIntervalMin { get; } = zcl.Report(0x0005, "Long Poll Interval Min", r => r.ReadUInt32());
    public static ReportAttribute FastPollTimeoutMax { get; } = zcl.Report(0x0006, "Fast Poll Timeout Max", r => r.ReadUInt16());
    public static Task Checkin => Task.CompletedTask;
    public static Task Stop => Task.CompletedTask;
    public static Task SetLongPollInterval => Task.CompletedTask;
    public static Task SetShortPollInterval => Task.CompletedTask;
}
