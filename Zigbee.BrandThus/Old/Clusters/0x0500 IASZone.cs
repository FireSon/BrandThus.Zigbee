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
    public enum ZoneStateEnum
    {
        NotEnrolled = 0x00,
        Enrolled = 0x01,
    }

    public static ReportAttribute ZoneState { get; } = zcl.Report(0x0000, "Zone State", ZigbeeType.Enum8, r => (ZoneStateEnum)r.ReadByte());
    public enum ZoneTypeEnum
    {
        StandardCIE = 0x0000,
        MotionSensor = 0x000d,
        ContactSwitch = 0x0015,
        FireSensor = 0x0028,
        WaterSensor = 0x002a,
        CarbonMonoxideCOSensor = 0x002b,
        PersonalEmergencyDevice = 0x002c,
        VibrationMovementSensor = 0x002d,
        RemoteControl = 0x010f,
        KeyFob = 0x0115,
        Keypad = 0x021d,
        StandardWarningDevice = 0x0225,
        GlassBreakSensor = 0x0226,
        SecurityRepeater = 0x0229,
        ManufacturerSpecific = 0x8000,
        InvalidZoneType = 0xffff,
    }

    public static ReportAttribute ZoneType { get; } = zcl.Report(0x0001, "Zone Type", ZigbeeType.Enum16, r => (ZoneTypeEnum)r.ReadInt16());
    public static ReportAttribute ZoneStatus { get; } = zcl.Report(0x0002, "Zone Status", ZigbeeType.Bmp16, r => r.ReadInt16());
    #endregion 

    #region Zone settings
    public static ReportAttribute IAS_CIE_Address { get; } = zcl.Report(0x0010, "IAS_CIE_Address", ZigbeeType.Uid, r => r.ReadInt64());
    public static ReportAttribute ZoneID { get; } = zcl.Report(0x0011, "Zone ID", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute NumberOfZoneSensitivityLevelsSupported { get; } = zcl.Report(0x0012, "Number Of ZoneSensitivity Levels Supported", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentZoneSensitivityLevel { get; } = zcl.Report(0x0013, "Current Zone SensitivityLevel", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Develco specific
    public static ReportAttribute DevelcoZoneStatusInterval { get; } = zcl.Report(0x8000, "Zone Status Interval", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DevelcoAlarmOffDelay { get; } = zcl.Report(0x8001, "Alarm Off Delay", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Xiaomi specific
    public static ReportAttribute XiaomiDeviceConfig { get; } = zcl.Report(0xfff0, "Device config", ZigbeeType.U64, r => r.ReadUInt64());
    #endregion 

    public static Task ZoneEnrollResponse(this ZigbeeNode node, byte enrollResponseCode, byte zoneID) => node.Zcl(zcl, 0x00, w => w+ enrollResponseCode+ zoneID);
    public static Task InitiateNormalOperationMode(this ZigbeeNode node) => node.Zcl(zcl, 0x01);
    public static Task ZoneStatusChangeNotification(this ZigbeeNode node, Int16 zoneStatus, byte extendedStatus, byte zoneID, ushort delay) => node.Zcl(zcl, 0x00, w => w+ zoneStatus+ extendedStatus+ zoneID+ delay);
    public static Task ZoneEnrollRequest(this ZigbeeNode node, Int16 zoneStatus, ushort manufacturerCode) => node.Zcl(zcl, 0x01, w => w+ zoneStatus+ manufacturerCode);
}
