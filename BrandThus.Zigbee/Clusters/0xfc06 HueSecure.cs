namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Hue-specific cluster for Hue Secure Contact Sensor.
/// <summary>
[Cluster(0xfc06, "Hue Secure")]
public static class ZclHueSecure
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHueSecure));

    public static ReportAttribute Contact { get; } = zcl.Report(0x0100, "Contact", r => r.ReadByte());
    public static ReportAttribute LastContactChange { get; } = zcl.Report(0x0101, "Last Contact Change", r => r.ReadUInt32());
    public static ReportAttribute Tamper { get; } = zcl.Report(0x0102, "Tamper", r => r.ReadByte());
    public static ReportAttribute LastTamperChange { get; } = zcl.Report(0x0103, "Last Tamper Change", r => r.ReadUInt32());
}
