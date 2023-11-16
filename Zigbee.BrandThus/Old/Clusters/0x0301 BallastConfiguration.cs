namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands to configure a ballast.
/// <summary>
[Cluster(0x0301, "Ballast Configuration")]
public static class ZclBallastConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBallastConfiguration));

    #region Ballast Information
    public static ReportAttribute PhysicalMinLevel { get; } = zcl.Report(0x0000, "Physical Min Level", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute PhysicalMaxLevel { get; } = zcl.Report(0x0001, "Physical Max Level", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BallastStatus { get; } = zcl.Report(0x0002, "Ballast Status", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Ballast Settings
    public static ReportAttribute MinLevel { get; } = zcl.Report(0x0010, "Min Level", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute MaxLevel { get; } = zcl.Report(0x0011, "Max Level", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute PowerOnLevel { get; } = zcl.Report(0x0012, "Power On Level", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute PowerOnFadeTime { get; } = zcl.Report(0x0013, "Power On Fade Time", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute IntrinsicBallastFactor { get; } = zcl.Report(0x0014, "Intrinsic Ballast Factor", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute BallastFactorAdjustment { get; } = zcl.Report(0x0015, "Ballast Factor Adjustment", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Lamp Information
    public static ReportAttribute LampQuantity { get; } = zcl.Report(0x0020, "Lamp Quantity", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Lamp Settings
    public static ReportAttribute LampType { get; } = zcl.Report(0x0030, "Lamp Type", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute LampManufacturer { get; } = zcl.Report(0x0031, "Lamp Manufacturer", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute LampRatedHours { get; } = zcl.Report(0x0032, "Lamp Rated Hours", ZigbeeType.U24, r => r.ReadUInt24());
    public static ReportAttribute LampBurnHours { get; } = zcl.Report(0x0033, "Lamp Burn Hours", ZigbeeType.U24, r => r.ReadUInt24());
    public static ReportAttribute LampAlarmMode { get; } = zcl.Report(0x0034, "Lamp Alarm Mode", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute LampBurnHoursTripPoint { get; } = zcl.Report(0x0035, "Lamp Burn Hours Trip Point", ZigbeeType.U24, r => r.ReadUInt24());
    #endregion 

}
