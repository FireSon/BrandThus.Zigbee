namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The server cluster provides an interface to illuminance measurement functionality, including configuration and
/// provision of notifications of illuminance measurements.
/// <summary>
[Cluster(0x0400, "Illuminance measurement")]
public static class ZclIlluminanceMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIlluminanceMeasurement));

    #region Illuminance Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadUInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadUInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    public static ReportAttribute LightSensorType { get; } = zcl.Report(0x0004, "Light Sensor Type", r => r.ReadByte());
    #endregion 


}
