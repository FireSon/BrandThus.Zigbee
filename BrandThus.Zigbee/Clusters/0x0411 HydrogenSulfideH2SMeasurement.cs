namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0411, "Hydrogen Sulfide (H2S) measurement")]
public static class ZclHydrogenSulfideH2SMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHydrogenSulfideH2SMeasurement));

    #region Hydrogen Sulfide Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
