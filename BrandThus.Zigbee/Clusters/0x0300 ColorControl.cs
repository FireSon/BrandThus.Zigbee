namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for controlling the color properties of a color-capable light.
/// <summary>
[Cluster(0x0300, "Color Control")]
public static class ZclColorControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclColorControl));

    #region Color Information
    public static ReportAttribute CurrentHue { get; } = zcl.Report(0x0000, "Current Hue", r => r.ReadByte());
    public static ReportAttribute CurrentSaturation { get; } = zcl.Report(0x0001, "Current Saturation", r => r.ReadByte());
    public static ReportAttribute RemainingTime { get; } = zcl.Report(0x0002, "Remaining Time", r => r.ReadUInt16());
    public static ReportAttribute CurrentX { get; } = zcl.Report(0x0003, "Current X", r => r.ReadUInt16());
    public static ReportAttribute CurrentY { get; } = zcl.Report(0x0004, "Current Y", r => r.ReadUInt16());
    public static ReportAttribute ColorTemperatureMireds { get; } = zcl.Report(0x0007, "Color Temperature Mireds", r => r.ReadUInt16());
    public static ReportAttribute ColorMode { get; } = zcl.Report(0x0008, "Color Mode", r => r.ReadByte());
    public static ReportAttribute Options { get; } = zcl.Report(0x000f, "Options", r => r.ReadByte());
    public static ReportAttribute EnhancedCurrentHue { get; } = zcl.Report(0x4000, "Enhanced Current Hue", r => r.ReadUInt16());
    public static ReportAttribute EnhancedColorMode { get; } = zcl.Report(0x4001, "Enhanced Color Mode", r => r.ReadByte());
    public static ReportAttribute ColorLoopActive { get; } = zcl.Report(0x4002, "Color Loop Active", r => r.ReadByte());
    public static ReportAttribute ColorLoopDirection { get; } = zcl.Report(0x4003, "Color Loop Direction", r => r.ReadByte());
    public static ReportAttribute ColorLoopTime { get; } = zcl.Report(0x4004, "Color Loop Time", r => r.ReadUInt16());
    public static ReportAttribute ColorLoopStartEnhancedHue { get; } = zcl.Report(0x4005, "Color Loop Start Enhanced Hue", r => r.ReadUInt16());
    public static ReportAttribute ColorLoopStoredEnhancedHue { get; } = zcl.Report(0x4006, "Color Loop Stored Enhanced Hue", r => r.ReadUInt16());
    public static ReportAttribute ColorCapabilities { get; } = zcl.Report(0x400a, "Color Capabilities", r => r.ReadInt16());
    public static ReportAttribute ColorTemperatureMinMireds { get; } = zcl.Report(0x400b, "Color Temperature Min Mireds", r => r.ReadUInt16());
    public static ReportAttribute ColorTemperatureMaxMireds { get; } = zcl.Report(0x400c, "Color Temperature Max Mireds", r => r.ReadUInt16());
    public static ReportAttribute StartUpColorTemperatureMireds { get; } = zcl.Report(0x4010, "StartUp Color Temperature Mireds", r => r.ReadUInt16());
    #endregion 

    #region Defined Primaries Information
    public static ReportAttribute NumberOfPrimaries { get; } = zcl.Report(0x0010, "Number of Primaries", r => r.ReadByte());
    public static ReportAttribute Primary1X { get; } = zcl.Report(0x0011, "Primary1 X", r => r.ReadUInt16());
    public static ReportAttribute Primary1Y { get; } = zcl.Report(0x0012, "Primary1 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary1Intensity { get; } = zcl.Report(0x0013, "Primary1 Intensity", r => r.ReadByte());
    public static ReportAttribute Primary2X { get; } = zcl.Report(0x0015, "Primary2 X", r => r.ReadUInt16());
    public static ReportAttribute Primary2Y { get; } = zcl.Report(0x0016, "Primary2 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary2Intensity { get; } = zcl.Report(0x0017, "Primary2 Intensity", r => r.ReadByte());
    public static ReportAttribute Primary3X { get; } = zcl.Report(0x0019, "Primary3 X", r => r.ReadUInt16());
    public static ReportAttribute Primary3Y { get; } = zcl.Report(0x001a, "Primary3 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary3Intensity { get; } = zcl.Report(0x001b, "Primary3 Intensity", r => r.ReadByte());
    #endregion 

    #region Additional Defined Primaries Information
    public static ReportAttribute Primary4X { get; } = zcl.Report(0x0020, "Primary4 X", r => r.ReadUInt16());
    public static ReportAttribute Primary4Y { get; } = zcl.Report(0x0021, "Primary4 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary4Intensity { get; } = zcl.Report(0x0022, "Primary4 Intensity", r => r.ReadByte());
    public static ReportAttribute Primary5X { get; } = zcl.Report(0x0024, "Primary5 X", r => r.ReadUInt16());
    public static ReportAttribute Primary5Y { get; } = zcl.Report(0x0025, "Primary5 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary5Intensity { get; } = zcl.Report(0x0026, "Primary5 Intensity", r => r.ReadByte());
    public static ReportAttribute Primary6X { get; } = zcl.Report(0x0028, "Primary6 X", r => r.ReadUInt16());
    public static ReportAttribute Primary6Y { get; } = zcl.Report(0x0029, "Primary6 Y", r => r.ReadUInt16());
    public static ReportAttribute Primary6Intensity { get; } = zcl.Report(0x002a, "Primary6 Intensity", r => r.ReadByte());
    #endregion 

    #region Defined Color Points Settings
    public static ReportAttribute WhitePointX { get; } = zcl.Report(0x0030, "WhitePoint X", r => r.ReadUInt16());
    public static ReportAttribute WhitePointY { get; } = zcl.Report(0x0031, "WhitePoint Y", r => r.ReadUInt16());
    public static ReportAttribute ColorPointRX { get; } = zcl.Report(0x0032, "ColorPoint R X", r => r.ReadUInt16());
    public static ReportAttribute ColorPointRY { get; } = zcl.Report(0x0033, "ColorPoint R Y", r => r.ReadUInt16());
    public static ReportAttribute ColorPointRIntensity { get; } = zcl.Report(0x0034, "ColorPoint R Intensity", r => r.ReadByte());
    public static ReportAttribute ColorPointGX { get; } = zcl.Report(0x0036, "ColorPoint G X", r => r.ReadUInt16());
    public static ReportAttribute ColorPointGY { get; } = zcl.Report(0x0037, "ColorPoint G Y", r => r.ReadUInt16());
    public static ReportAttribute ColorPointGIntensity { get; } = zcl.Report(0x0038, "ColorPoint G Intensity", r => r.ReadByte());
    public static ReportAttribute ColorPointBX { get; } = zcl.Report(0x003a, "ColorPoint B X", r => r.ReadUInt16());
    public static ReportAttribute ColorPointBY { get; } = zcl.Report(0x003b, "ColorPoint B Y", r => r.ReadUInt16());
    public static ReportAttribute ColorPointBIntensity { get; } = zcl.Report(0x003c, "ColorPoint B Intensity", r => r.ReadByte());
    #endregion 

    #region FLS extensions
    public static ReportAttribute ActiveChannels { get; } = zcl.Report(0xde01, "Active channels", r => r.ReadByte());
    #endregion 

    public static Task MoveToHue => Task.CompletedTask;
    public static Task MoveHue => Task.CompletedTask;
    public static Task StepHue => Task.CompletedTask;
    public static Task MoveToSaturation => Task.CompletedTask;
    public static Task MoveSaturation => Task.CompletedTask;
    public static Task StepSaturation => Task.CompletedTask;
    public static Task MoveToHueAndSaturation => Task.CompletedTask;
    public static Task MoveToColor => Task.CompletedTask;
    public static Task MoveColor => Task.CompletedTask;
    public static Task StepColor => Task.CompletedTask;
    public static Task MoveToColorTemperature => Task.CompletedTask;
    public static Task EnhancedMoveToHue => Task.CompletedTask;
    public static Task EnhancedMoveHue => Task.CompletedTask;
    public static Task EnhancedStepHue => Task.CompletedTask;
    public static Task EnhancedMoveToHueAndSaturation => Task.CompletedTask;
    public static Task ColorLoopSet => Task.CompletedTask;
    public static Task StopMoveStep => Task.CompletedTask;
    public static Task MoveColorTemperature => Task.CompletedTask;
    public static Task StepColorTemperature => Task.CompletedTask;
    public static Task SetActiveChannels => Task.CompletedTask;
}
