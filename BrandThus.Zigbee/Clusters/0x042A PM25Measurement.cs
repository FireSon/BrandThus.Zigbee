namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Particulate Matter 2.5 microns or less
/// <summary>
[Cluster(0x042A, "PM2.5 Measurement")]
public static class ZclPM25Measurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPM25Measurement));

    #region PM 2.5 Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
