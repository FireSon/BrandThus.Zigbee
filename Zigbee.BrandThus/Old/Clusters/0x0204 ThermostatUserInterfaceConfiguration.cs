namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides an interface to allow configuration of the user interface for a thermostat, or a thermostat
/// controller device, that supports a keypad and LCD screen.
/// <summary>
[Cluster(0x0204, "Thermostat User Interface Configuration")]
public static class ZclThermostatUserInterfaceConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclThermostatUserInterfaceConfiguration));

    public enum TemperatureDisplayModeEnum
    {
        TemperatureInC = 0x00,
        TemperatureInF = 0x01,
    }

    public static ReportAttribute TemperatureDisplayMode { get; } = zcl.Report(0x0000, "Temperature Display Mode", ZigbeeType.Enum8, r => (TemperatureDisplayModeEnum)r.ReadByte());
    public enum KeypadLockoutEnum
    {
        NoLockout = 0x00,
        Level1Lockout = 0x01,
        Level2Lockout = 0x02,
        Level3Lockout = 0x03,
        Level4Lockout = 0x04,
        Level5Lockout = 0x05,
    }

    public static ReportAttribute KeypadLockout { get; } = zcl.Report(0x0001, "Keypad Lockout", ZigbeeType.Enum8, r => (KeypadLockoutEnum)r.ReadByte());
    public enum ScheduleProgrammingVisibilityEnum
    {
        LocalScheduleProgrammingEnabled = 0x00,
        LocalScheduleProgrammingDisabled = 0x01,
    }

    public static ReportAttribute ScheduleProgrammingVisibility { get; } = zcl.Report(0x0002, "Schedule Programming Visibility", ZigbeeType.Enum8, r => (ScheduleProgrammingVisibilityEnum)r.ReadByte());
    public enum ViewingDirectionEnum
    {
        ViewingDirection1 = 0x00,
        ViewingDirection2 = 0x01,
    }

    public static ReportAttribute ViewingDirection { get; } = zcl.Report(0x4000, "Viewing Direction", ZigbeeType.Enum8, r => (ViewingDirectionEnum)r.ReadByte());
    #region Bosch specific
    public static ReportAttribute BoschDisplayOrientation { get; } = zcl.Report(0x400B, "Display Orientation", ZigbeeType.U8, r => r.ReadByte());
    public enum BoschDisplayedTemperatureEnum
    {
        SetpointTemperature = 0x00,
        MeasuredTemperature = 0x01,
        Unknown = 0x02,
    }

    public static ReportAttribute BoschDisplayedTemperature { get; } = zcl.Report(0x4039, "Displayed Temperature", ZigbeeType.Enum8, r => (BoschDisplayedTemperatureEnum)r.ReadByte());
    public enum BoschDisplayOntimeEnum
    {
        Off = 0x00,
        _1 = 0x01,
        _2 = 0x02,
        _3 = 0x03,
        _4 = 0x04,
        _10 = 0x0A,
        _20 = 0x04,
        _30 = 0x04,
        _40 = 0x04,
    }

    public static ReportAttribute BoschDisplayOntime { get; } = zcl.Report(0x403a, "Display On-time", ZigbeeType.Enum8, r => (BoschDisplayOntimeEnum)r.ReadByte());
    public enum BoschDisplayBrightnessEnum
    {
        Off = 0x00,
        _1 = 0x01,
        _2 = 0x02,
        _3 = 0x03,
        _4 = 0x04,
        _5 = 0x05,
        _6 = 0x06,
        _7 = 0x07,
        _8 = 0x08,
    }

    public static ReportAttribute BoschDisplayBrightness { get; } = zcl.Report(0x403b, "Display Brightness", ZigbeeType.Enum8, r => (BoschDisplayBrightnessEnum)r.ReadByte());
    #endregion 

}
