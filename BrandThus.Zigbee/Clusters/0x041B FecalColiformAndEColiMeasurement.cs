namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Percent of positive samples. Typical value example: 0
/// <summary>
[Cluster(0x041B, "Fecal coliform and E Coli measurement")]
public static class ZclFecalColiformAndEColiMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclFecalColiformAndEColiMeasurement));

    #region Fecal coliform and E Coli Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadSingle());
    #endregion 

}
