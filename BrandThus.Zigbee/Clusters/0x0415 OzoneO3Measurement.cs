namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0415, "Ozone (O3) measurement")]
public static class ZclOzoneO3Measurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOzoneO3Measurement));

    #region Ozone Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
