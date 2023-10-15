namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0412, "Nitric Oxide (NO) measurement")]
public static class ZclNitricOxideNOMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclNitricOxideNOMeasurement));

    #region Nitric Oxide Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
