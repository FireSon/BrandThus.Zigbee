namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: Not Detected to 20 PPB. Ttypical value example: 14 PPB
/// <summary>
[Cluster(0x041D, "Haloacetic Acids measurement")]
public static class ZclHaloaceticAcidsMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHaloaceticAcidsMeasurement));

    #region Haloacetic Acids Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
