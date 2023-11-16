namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Typical range example: 0 to 100 PPM.Typical value example: 0.72 PPM
/// <summary>
[Cluster(0x041C, "Fluoride measurement")]
public static class ZclFluorideMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclFluorideMeasurement));

    #region Fluoride Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", ZigbeeType.Float, r => r.ReadSingle());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", ZigbeeType.Float, r => r.ReadSingle());
    #endregion 

}
