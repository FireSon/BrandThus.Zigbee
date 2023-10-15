namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0410, "Hydrogen (H) measurement")]
public static class ZclHydrogenHMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHydrogenHMeasurement));

    #region Hydrogen Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
