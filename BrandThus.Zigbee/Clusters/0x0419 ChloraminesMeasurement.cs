namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0.9 to 3.8 PPM. typical value example: 2.87 PPM
/// <summary>
[Cluster(0x0419, "Chloramines measurement")]
public static class ZclChloraminesMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclChloraminesMeasurement));

    #region Chloramines Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
