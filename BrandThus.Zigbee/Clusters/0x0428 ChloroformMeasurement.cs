namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0 to 1000 PPB. Typical value example: 8.0 PPB
/// <summary>
[Cluster(0x0428, "Chloroform measurement")]
public static class ZclChloroformMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclChloroformMeasurement));

    #region Chloroform Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
