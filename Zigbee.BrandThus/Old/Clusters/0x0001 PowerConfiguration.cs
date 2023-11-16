namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes for determining more detailed information about a device’s power source(s), and for configuring under/over
/// voltage alarms.
/// <summary>
[Cluster(0x0001, "Power Configuration")]
public static class ZclPowerConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPowerConfiguration));

    #region Mains Information
    public static ReportAttribute MainsVoltage { get; } = zcl.Report(0x0000, "Mains Voltage", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MainsFrequency { get; } = zcl.Report(0x0001, "Mains Frequency", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Mains Settings
    public static ReportAttribute MainsAlarmMask { get; } = zcl.Report(0x0010, "Mains Alarm Mask", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute MainsVoltageMinThreshold { get; } = zcl.Report(0x0011, "Mains Voltage Min Threshold", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MainsVoltageMaxThreshold { get; } = zcl.Report(0x0012, "Mains Voltage Max Threshold", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MainsVoltageDwellTripPoint { get; } = zcl.Report(0x0013, "Mains Voltage Dwell Trip Point", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Battery Information
    public static ReportAttribute BatteryVoltage { get; } = zcl.Report(0x0020, "Battery Voltage", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BatteryPercentageRemaining { get; } = zcl.Report(0x0021, "Battery Percentage Remaining", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Battery Settings
    public static ReportAttribute BatteryManufacturer { get; } = zcl.Report(0x0030, "Battery Manufacturer", ZigbeeType.Cstring, r => r.ReadString());
    public enum BatterySizeEnum
    {
        NoBattery = 0,
        BuiltIn = 1,
        Other = 2,
        AA = 3,
        AAA = 4,
        C = 5,
        D = 6,
        CR2 = 7,
        CR123A = 8,
        Unknown = 0xff,
    }

    public static ReportAttribute BatterySize { get; } = zcl.Report(0x0031, "Battery Size", ZigbeeType.Enum8, r => (BatterySizeEnum)r.ReadByte());
    public static ReportAttribute BatteryAHrRating { get; } = zcl.Report(0x0032, "Battery AHr Rating", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute BatteryQuantity { get; } = zcl.Report(0x0033, "Battery Quantity", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BatteryRatedVoltage { get; } = zcl.Report(0x0034, "Battery Rated Voltage", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BatteryAlarmMask { get; } = zcl.Report(0x0035, "Battery Alarm Mask", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute BatteryVoltageMinThreshold { get; } = zcl.Report(0x0036, "Battery Voltage Min Threshold", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BatteryAlarmState { get; } = zcl.Report(0x003e, "Battery Alarm State", ZigbeeType.Bmp32, r => r.ReadInt32());
    #endregion 

}
