namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The server cluster provides an interface to air pressure measurement functionality, including configuration and
/// provision of notifications of air pressure measurements.
/// <summary>
[Cluster(0x0403, "Pressure measurement")]
public static class ZclPressureMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPressureMeasurement));

    #region Pressure Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

    #region Extended Pressure Measurement Information
    public static ReportAttribute ScaledValue { get; } = zcl.Report(0x0010, "Scaled Value", r => r.ReadInt16());
    public static ReportAttribute MinScaledValue { get; } = zcl.Report(0x0011, "Min Scaled Value", r => r.ReadUInt16());
    public static ReportAttribute MaxScaledValue { get; } = zcl.Report(0x0012, "Max Scaled Value", r => r.ReadUInt16());
    public static ReportAttribute ScaledTolerance { get; } = zcl.Report(0x0013, "Scaled Tolerance", r => r.ReadUInt16());
    public static ReportAttribute Scale { get; } = zcl.Report(0x0014, "Scale", r => r.ReadByte());
    #endregion 

}
