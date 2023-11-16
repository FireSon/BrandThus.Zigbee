namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0413, "Nitrogen Dioxide (NO2) measurement")]
public static class ZclNitrogenDioxideNO2Measurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclNitrogenDioxideNO2Measurement));

    #region Nitrogen Dioxide Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.Float, r => r.ReadSingle());
    #endregion 

}
