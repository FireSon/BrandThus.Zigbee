namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// PM1 concentration measurement
/// <summary>
[Cluster(0x042C, "PM1 Measurement")]
public static class ZclPM1Measurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPM1Measurement));

    #region PM1 Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
