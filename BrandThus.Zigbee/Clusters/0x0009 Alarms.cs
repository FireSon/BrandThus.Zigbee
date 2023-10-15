namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Sending alarm notifications and configuring alarm functionality.
/// <summary>
[Cluster(0x0009, "Alarms")]
public static class ZclAlarms
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAlarms));

    #region Alarm Information
    public static ReportAttribute AlarmCount { get; } = zcl.Report(0x0000, "Alarm Count", r => r.ReadUInt16());
    #endregion 

    public static Task Alarm => Task.CompletedTask;
}
