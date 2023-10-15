namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: not detected to 3.6 PPB. Typical value example:1.79 PPB
/// <summary>
[Cluster(0x0418, "Bromate measurement")]
public static class ZclBromateMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBromateMeasurement));

    #region Bromate Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
