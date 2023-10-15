namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands to configure a ballast.
/// <summary>
[Cluster(0x0301, "Ballast Configuration")]
public static class ZclBallastConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBallastConfiguration));

    #region Ballast Information
    public static ReportAttribute PhysicalMinLevel { get; } = zcl.Report(0x0000, "Physical Min Level", r => r.ReadByte());
    public static ReportAttribute PhysicalMaxLevel { get; } = zcl.Report(0x0001, "Physical Max Level", r => r.ReadByte());
    public static ReportAttribute BallastStatus { get; } = zcl.Report(0x0002, "Ballast Status", r => r.ReadByte());
    #endregion 

    #region Ballast Settings
    public static ReportAttribute MinLevel { get; } = zcl.Report(0x0010, "Min Level", r => r.ReadByte());
    public static ReportAttribute MaxLevel { get; } = zcl.Report(0x0011, "Max Level", r => r.ReadByte());
    public static ReportAttribute PowerOnLevel { get; } = zcl.Report(0x0012, "Power On Level", r => r.ReadByte());
    public static ReportAttribute PowerOnFadeTime { get; } = zcl.Report(0x0013, "Power On Fade Time", r => r.ReadUInt16());
    public static ReportAttribute IntrinsicBallastFactor { get; } = zcl.Report(0x0014, "Intrinsic Ballast Factor", r => r.ReadByte());
    public static ReportAttribute BallastFactorAdjustment { get; } = zcl.Report(0x0015, "Ballast Factor Adjustment", r => r.ReadByte());
    #endregion 

    #region Lamp Information
    public static ReportAttribute LampQuantity { get; } = zcl.Report(0x0020, "Lamp Quantity", r => r.ReadByte());
    #endregion 

    #region Lamp Settings
    public static ReportAttribute LampType { get; } = zcl.Report(0x0030, "Lamp Type", r => r.ReadString());
    public static ReportAttribute LampManufacturer { get; } = zcl.Report(0x0031, "Lamp Manufacturer", r => r.ReadString());
    public static ReportAttribute LampRatedHours { get; } = zcl.Report(0x0032, "Lamp Rated Hours", r => r.ReadUInt24());
    public static ReportAttribute LampBurnHours { get; } = zcl.Report(0x0033, "Lamp Burn Hours", r => r.ReadUInt24());
    public static ReportAttribute LampAlarmMode { get; } = zcl.Report(0x0034, "Lamp Alarm Mode", r => r.ReadByte());
    public static ReportAttribute LampBurnHoursTripPoint { get; } = zcl.Report(0x0035, "Lamp Burn Hours Trip Point", r => r.ReadUInt24());
    #endregion 

}
