namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Percent of positive samples. Typical range example: 0 to 100%. Typical value example: 1.33%
/// <summary>
[Cluster(0x041F, "Total Coliform Bacteria measurement")]
public static class ZclTotalColiformBacteriaMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTotalColiformBacteriaMeasurement));

    #region Total Coliform Bacteria Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
