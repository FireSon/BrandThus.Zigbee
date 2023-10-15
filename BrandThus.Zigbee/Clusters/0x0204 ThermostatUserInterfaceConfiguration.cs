namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides an interface to allow configuration of the user interface for a thermostat, or a thermostat
/// controller device, that supports a keypad and LCD screen.
/// <summary>
[Cluster(0x0204, "Thermostat User Interface Configuration")]
public static class ZclThermostatUserInterfaceConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclThermostatUserInterfaceConfiguration));

    public static ReportAttribute TemperatureDisplayMode { get; } = zcl.Report(0x0000, "Temperature Display Mode", r => r.ReadByte());
    public static ReportAttribute KeypadLockout { get; } = zcl.Report(0x0001, "Keypad Lockout", r => r.ReadByte());
    public static ReportAttribute ScheduleProgrammingVisibility { get; } = zcl.Report(0x0002, "Schedule Programming Visibility", r => r.ReadByte());
    public static ReportAttribute ViewingDirection { get; } = zcl.Report(0x4000, "Viewing Direction", r => r.ReadByte());
    #region Bosch specific
    public static ReportAttribute BoschDisplayOrientation { get; } = zcl.Report(0x400B, "Display Orientation", r => r.ReadByte());
    public static ReportAttribute BoschDisplayedTemperature { get; } = zcl.Report(0x4039, "Displayed Temperature", r => r.ReadByte());
    public static ReportAttribute BoschDisplayOntime { get; } = zcl.Report(0x403a, "Display On-time", r => r.ReadByte());
    public static ReportAttribute BoschDisplayBrightness { get; } = zcl.Report(0x403b, "Display Brightness", r => r.ReadByte());
    #endregion 

}
