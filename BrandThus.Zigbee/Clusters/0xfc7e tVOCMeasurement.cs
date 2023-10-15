namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Cluster to report tVOC on the IKEA Vindstyrka Air Quality Sensor.
/// <summary>
[Cluster(0xfc7e, "tVOC Measurement")]
public static class ZcltVOCMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZcltVOCMeasurement));

    #region tVOC Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    #endregion 

}
