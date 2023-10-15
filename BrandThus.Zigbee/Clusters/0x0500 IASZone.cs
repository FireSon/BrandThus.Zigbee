namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The IAS Zone cluster defines an interface to the functionality of an IAS security zone device. IAS Zone supports
/// up to two alarm types per zone, low battery reports and supervision of the IAS network.
/// <summary>
[Cluster(0x0500, "IAS Zone")]
public static class ZclIASZone
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIASZone));

    #region Zone information
    public static ReportAttribute ZoneState { get; } = zcl.Report(0x0000, "Zone State", r => r.ReadByte());
    public static ReportAttribute ZoneType { get; } = zcl.Report(0x0001, "Zone Type", r => r.ReadInt16());
    public static ReportAttribute ZoneStatus { get; } = zcl.Report(0x0002, "Zone Status", r => r.ReadInt16());
    #endregion 

    #region Zone settings
    public static ReportAttribute IAS_CIE_Address { get; } = zcl.Report(0x0010, "IAS_CIE_Address", r => r.ReadInt64());
    public static ReportAttribute ZoneID { get; } = zcl.Report(0x0011, "Zone ID", r => r.ReadByte());
    public static ReportAttribute NumberOfZoneSensitivityLevelsSupported { get; } = zcl.Report(0x0012, "Number Of ZoneSensitivity Levels Supported", r => r.ReadByte());
    public static ReportAttribute CurrentZoneSensitivityLevel { get; } = zcl.Report(0x0013, "Current Zone SensitivityLevel", r => r.ReadByte());
    #endregion 

    #region Develco specific
    public static ReportAttribute DevelcoZoneStatusInterval { get; } = zcl.Report(0x8000, "Zone Status Interval", r => r.ReadUInt16());
    public static ReportAttribute DevelcoAlarmOffDelay { get; } = zcl.Report(0x8001, "Alarm Off Delay", r => r.ReadUInt16());
    #endregion 

    #region Xiaomi specific
    public static ReportAttribute XiaomiDeviceConfig { get; } = zcl.Report(0xfff0, "Device config", r => r.ReadByte());
    #endregion 

    public static Task ZoneEnrollResponse => Task.CompletedTask;
    public static Task InitiateNormalOperationMode => Task.CompletedTask;
    public static Task ZoneStatusChangeNotification => Task.CompletedTask;
    public static Task ZoneEnrollRequest => Task.CompletedTask;
}
