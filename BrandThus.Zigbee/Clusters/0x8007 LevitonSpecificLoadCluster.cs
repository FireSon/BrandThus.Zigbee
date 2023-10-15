namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Additional features implemented in Leviton’s DG6HD.
/// <summary>
[Cluster(0x8007, "Leviton Specific Load Cluster")]
public static class ZclLevitonSpecificLoadCluster
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLevitonSpecificLoadCluster));

    public static ReportAttribute MinDimLevel { get; } = zcl.Report(0x0001, "Min Dim Level", r => r.ReadByte());
    public static ReportAttribute MaxDimLevel { get; } = zcl.Report(0x0002, "Max Dim Level", r => r.ReadByte());
    public static ReportAttribute LocatorLED { get; } = zcl.Report(0x0003, "Locator LED", r => r.ReadByte());
    public static ReportAttribute DimmingLED { get; } = zcl.Report(0x0004, "Dimming LED", r => r.ReadByte());
    public static ReportAttribute InitialOnLevel { get; } = zcl.Report(0x0007, "Initial On Level", r => r.ReadByte());
    public static ReportAttribute PowerRestore { get; } = zcl.Report(0x0008, "Power Restore", r => r.ReadBool());
    public static ReportAttribute PressAndHoldTime { get; } = zcl.Report(0x0009, "Press and Hold Time", r => r.ReadByte());
}
