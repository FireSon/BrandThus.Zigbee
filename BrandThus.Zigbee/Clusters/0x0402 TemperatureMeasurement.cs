namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The server cluster provides an interface to temperature measurement functionality, including configuration and
/// provision of notifications of temperature measurements.
/// <summary>
[Cluster(0x0402, "Temperature measurement")]
public static class ZclTemperatureMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclTemperatureMeasurement));

    #region Temperature Measurement Information
    public static ReportAttribute MeasuredValue { get; } = zcl.Report(0x0000, "Measured Value", r => r.ReadInt16());
    public static ReportAttribute MinMeasuredValue { get; } = zcl.Report(0x0001, "Min Measured Value", r => r.ReadInt16());
    public static ReportAttribute MaxMeasuredValue { get; } = zcl.Report(0x0002, "Max Measured Value", r => r.ReadInt16());
    public static ReportAttribute Tolerance { get; } = zcl.Report(0x0003, "Tolerance", r => r.ReadUInt16());
    #endregion 

}
