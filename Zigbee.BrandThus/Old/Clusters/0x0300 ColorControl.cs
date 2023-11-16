namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for controlling the color properties of a color-capable light.
/// <summary>
[Cluster(0x0300, "Color Control")]
public static class ZclColorControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclColorControl));

    #region Color Information
    public static ReportAttribute CurrentHue { get; } = zcl.Report(0x0000, "Current Hue", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentSaturation { get; } = zcl.Report(0x0001, "Current Saturation", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute RemainingTime { get; } = zcl.Report(0x0002, "Remaining Time", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CurrentX { get; } = zcl.Report(0x0003, "Current X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CurrentY { get; } = zcl.Report(0x0004, "Current Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorTemperatureMireds { get; } = zcl.Report(0x0007, "Color Temperature Mireds", ZigbeeType.U16, r => r.ReadUInt16());
    public enum ColorModeEnum
    {
        CurrentHueAndCurrentSaturation = 0x00,
        CurrentXAndCurrentY = 0x01,
        ColorTemperature = 0x02,
    }

    public static ReportAttribute ColorMode { get; } = zcl.Report(0x0008, "Color Mode", ZigbeeType.Enum8, r => (ColorModeEnum)r.ReadByte());
    public static ReportAttribute Options { get; } = zcl.Report(0x000f, "Options", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute EnhancedCurrentHue { get; } = zcl.Report(0x4000, "Enhanced Current Hue", ZigbeeType.U16, r => r.ReadUInt16());
    public enum EnhancedColorModeEnum
    {
        CurrentHueAndCurrentSaturation = 0x00,
        CurrentXAndCurrentY = 0x01,
        ColorTemperature = 0x02,
        EnhancedCurrentHueAndCurrentSaturation = 0x03,
    }

    public static ReportAttribute EnhancedColorMode { get; } = zcl.Report(0x4001, "Enhanced Color Mode", ZigbeeType.Enum8, r => (EnhancedColorModeEnum)r.ReadByte());
    public static ReportAttribute ColorLoopActive { get; } = zcl.Report(0x4002, "Color Loop Active", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ColorLoopDirection { get; } = zcl.Report(0x4003, "Color Loop Direction", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ColorLoopTime { get; } = zcl.Report(0x4004, "Color Loop Time", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorLoopStartEnhancedHue { get; } = zcl.Report(0x4005, "Color Loop Start Enhanced Hue", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorLoopStoredEnhancedHue { get; } = zcl.Report(0x4006, "Color Loop Stored Enhanced Hue", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorCapabilities { get; } = zcl.Report(0x400a, "Color Capabilities", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute ColorTemperatureMinMireds { get; } = zcl.Report(0x400b, "Color Temperature Min Mireds", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorTemperatureMaxMireds { get; } = zcl.Report(0x400c, "Color Temperature Max Mireds", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute StartUpColorTemperatureMireds { get; } = zcl.Report(0x4010, "StartUp Color Temperature Mireds", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Defined Primaries Information
    public static ReportAttribute NumberOfPrimaries { get; } = zcl.Report(0x0010, "Number of Primaries", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Primary1X { get; } = zcl.Report(0x0011, "Primary1 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary1Y { get; } = zcl.Report(0x0012, "Primary1 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary1Intensity { get; } = zcl.Report(0x0013, "Primary1 Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Primary2X { get; } = zcl.Report(0x0015, "Primary2 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary2Y { get; } = zcl.Report(0x0016, "Primary2 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary2Intensity { get; } = zcl.Report(0x0017, "Primary2 Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Primary3X { get; } = zcl.Report(0x0019, "Primary3 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary3Y { get; } = zcl.Report(0x001a, "Primary3 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary3Intensity { get; } = zcl.Report(0x001b, "Primary3 Intensity", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Additional Defined Primaries Information
    public static ReportAttribute Primary4X { get; } = zcl.Report(0x0020, "Primary4 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary4Y { get; } = zcl.Report(0x0021, "Primary4 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary4Intensity { get; } = zcl.Report(0x0022, "Primary4 Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Primary5X { get; } = zcl.Report(0x0024, "Primary5 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary5Y { get; } = zcl.Report(0x0025, "Primary5 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary5Intensity { get; } = zcl.Report(0x0026, "Primary5 Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Primary6X { get; } = zcl.Report(0x0028, "Primary6 X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary6Y { get; } = zcl.Report(0x0029, "Primary6 Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Primary6Intensity { get; } = zcl.Report(0x002a, "Primary6 Intensity", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Defined Color Points Settings
    public static ReportAttribute WhitePointX { get; } = zcl.Report(0x0030, "WhitePoint X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute WhitePointY { get; } = zcl.Report(0x0031, "WhitePoint Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointRX { get; } = zcl.Report(0x0032, "ColorPoint R X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointRY { get; } = zcl.Report(0x0033, "ColorPoint R Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointRIntensity { get; } = zcl.Report(0x0034, "ColorPoint R Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ColorPointGX { get; } = zcl.Report(0x0036, "ColorPoint G X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointGY { get; } = zcl.Report(0x0037, "ColorPoint G Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointGIntensity { get; } = zcl.Report(0x0038, "ColorPoint G Intensity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ColorPointBX { get; } = zcl.Report(0x003a, "ColorPoint B X", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointBY { get; } = zcl.Report(0x003b, "ColorPoint B Y", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ColorPointBIntensity { get; } = zcl.Report(0x003c, "ColorPoint B Intensity", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region FLS extensions
    public static ReportAttribute ActiveChannels { get; } = zcl.Report(0xde01, "Active channels", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    public static Task MoveToHue(this ZigbeeNode node, byte hue, byte direction, ushort transitionTime) => node.Zcl(zcl, 0x00, w => w+ hue+ direction+ transitionTime);
    public static Task MoveHue(this ZigbeeNode node, byte moveMode, byte rate) => node.Zcl(zcl, 0x01, w => w+ moveMode+ rate);
    public static Task StepHue(this ZigbeeNode node, byte stepMode, byte stepSize, byte transitionTime) => node.Zcl(zcl, 0x02, w => w+ stepMode+ stepSize+ transitionTime);
    public static Task MoveToSaturation(this ZigbeeNode node, byte saturation, ushort transitionTime) => node.Zcl(zcl, 0x03, w => w+ saturation+ transitionTime);
    public static Task MoveSaturation(this ZigbeeNode node, byte moveMode, byte rate) => node.Zcl(zcl, 0x04, w => w+ moveMode+ rate);
    public static Task StepSaturation(this ZigbeeNode node, byte stepMode, byte stepSize, byte transitionTime) => node.Zcl(zcl, 0x05, w => w+ stepMode+ stepSize+ transitionTime);
    public static Task MoveToHueAndSaturation(this ZigbeeNode node, byte hue, byte saturation, ushort transitionTime) => node.Zcl(zcl, 0x06, w => w+ hue+ saturation+ transitionTime);
    public static Task MoveToColor(this ZigbeeNode node, ushort colorX, ushort colorY, ushort transitionTime) => node.Zcl(zcl, 0x07, w => w+ colorX+ colorY+ transitionTime);
    public static Task MoveColor(this ZigbeeNode node, short rateX, short rateY) => node.Zcl(zcl, 0x08, w => w+ rateX+ rateY);
    public static Task StepColor(this ZigbeeNode node, short stepX, short stepY, ushort transitionTime) => node.Zcl(zcl, 0x09, w => w+ stepX+ stepY+ transitionTime);
    public static Task MoveToColorTemperature(this ZigbeeNode node, ushort colorTemperatureMireds, ushort transitionTime) => node.Zcl(zcl, 0x0a, w => w+ colorTemperatureMireds+ transitionTime);
    public static Task EnhancedMoveToHue(this ZigbeeNode node, ushort enhancedHue, byte direction, ushort transitionTime) => node.Zcl(zcl, 0x40, w => w+ enhancedHue+ direction+ transitionTime);
    public static Task EnhancedMoveHue(this ZigbeeNode node, byte moveMode, ushort rate) => node.Zcl(zcl, 0x41, w => w+ moveMode+ rate);
    public static Task EnhancedStepHue(this ZigbeeNode node, byte stepMode, ushort stepSize, ushort transitionTime) => node.Zcl(zcl, 0x42, w => w+ stepMode+ stepSize+ transitionTime);
    public static Task EnhancedMoveToHueAndSaturation(this ZigbeeNode node, ushort enhancedHue, byte saturation, ushort transitionTime) => node.Zcl(zcl, 0x43, w => w+ enhancedHue+ saturation+ transitionTime);
    public static Task ColorLoopSet(this ZigbeeNode node, byte updateFlags, byte action, byte direction, ushort time, ushort startEnhancedHue) => node.Zcl(zcl, 0x44, w => w+ updateFlags+ action+ direction+ time+ startEnhancedHue);
    /// <summary>
    /// Stops move to and step commands. It has no effect on a active color loop.
    /// <summary>
    public static Task StopMoveStep(this ZigbeeNode node) => node.Zcl(zcl, 0x47);
    public static Task MoveColorTemperature(this ZigbeeNode node, byte moveMode, ushort rate, ushort colorTemperatureMinMireds, ushort colorTemperatureMaxMireds) => node.Zcl(zcl, 0x4b, w => w+ moveMode+ rate+ colorTemperatureMinMireds+ colorTemperatureMaxMireds);
    public static Task StepColorTemperature(this ZigbeeNode node, byte stepMode, ushort stepSize, ushort transitionTime, ushort colorTemperatureMinMireds, ushort colorTemperatureMaxMireds) => node.Zcl(zcl, 0x4c, w => w+ stepMode+ stepSize+ transitionTime+ colorTemperatureMinMireds+ colorTemperatureMaxMireds);
    public static Task SetActiveChannels(this ZigbeeNode node, byte channels) => node.Zcl(zcl, 0xd0, w => w+ channels);
}
