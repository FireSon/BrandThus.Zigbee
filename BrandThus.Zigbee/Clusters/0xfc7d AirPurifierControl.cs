namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Cluster to control the IKEA Starkvind Air Purifier.
/// <summary>
[Cluster(0xfc7d, "Air Purifier Control")]
public static class ZclAirPurifierControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclAirPurifierControl));

    public static ReportAttribute FilterRunTime { get; } = zcl.Report(0x0000, "Filter Run Time", r => r.ReadUInt32());
    public static ReportAttribute ReplaceFilter { get; } = zcl.Report(0x0001, "Replace Filter", r => r.ReadByte());
    public static ReportAttribute FilterLifeTime { get; } = zcl.Report(0x0002, "Filter Life Time", r => r.ReadUInt32());
    public static ReportAttribute DisableLEDs { get; } = zcl.Report(0x0003, "Disable LEDs", r => r.ReadBool());
    public static ReportAttribute AirQuality { get; } = zcl.Report(0x0004, "Air Quality", r => r.ReadUInt16());
    public static ReportAttribute LockControls { get; } = zcl.Report(0x0005, "Lock Controls", r => r.ReadBool());
    public static ReportAttribute TargetMode { get; } = zcl.Report(0x0006, "Target Mode", r => r.ReadByte());
    public static ReportAttribute CurrentMode { get; } = zcl.Report(0x0007, "Current Mode", r => r.ReadByte());
    public static ReportAttribute DeviceRunTime { get; } = zcl.Report(0x0008, "Device Run Time", r => r.ReadUInt32());
}
