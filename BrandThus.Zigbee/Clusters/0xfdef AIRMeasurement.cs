namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// BOSCH Thermotechnik indoor air quality
/// <summary>
[Cluster(0xfdef, "AIR Measurement")]
public static class ZclAIRMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAIRMeasurement));

    public static ReportAttribute AirPressure { get; } = zcl.Report(0x4001, "Air pressure", r => r.ReadUInt16());
    public static ReportAttribute Temperature { get; } = zcl.Report(0x4002, "Temperature", r => r.ReadInt16());
    public static ReportAttribute Humidity { get; } = zcl.Report(0x4003, "Humidity", r => r.ReadByte());
    public static ReportAttribute AirQuality { get; } = zcl.Report(0x4004, "Air quality", r => r.ReadUInt16());
    public static ReportAttribute Brightness { get; } = zcl.Report(0x4005, "Brightness", r => r.ReadUInt16());
    public static ReportAttribute Loudness { get; } = zcl.Report(0x4006, "Loudness", r => r.ReadByte());
    public static ReportAttribute timestamp { get; } = zcl.Report(0x4008, "timestamp", r => r.ReadUInt32());
    public static ReportAttribute Trigger { get; } = zcl.Report(0x4009, "Trigger", r => r.ReadByte());
    public static ReportAttribute ModeOfOperation { get; } = zcl.Report(0x400B, "ModeOfOperation", r => r.ReadByte());
}
