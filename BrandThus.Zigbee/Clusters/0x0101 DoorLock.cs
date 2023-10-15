namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The door lock cluster provides an interface to a generic way to secure a door.
/// <summary>
[Cluster(0x0101, "Door Lock")]
public static class ZclDoorLock
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDoorLock));

    #region Basic Information Attribute Set
    public static ReportAttribute LockState { get; } = zcl.Report(0x0000, "Lock State", r => r.ReadByte());
    public static ReportAttribute LockType { get; } = zcl.Report(0x0001, "Lock Type", r => r.ReadByte());
    public static ReportAttribute ActuatorEnabled { get; } = zcl.Report(0x0002, "Actuator enabled", r => r.ReadBool());
    public static ReportAttribute DoorState { get; } = zcl.Report(0x0003, "Door state", r => r.ReadByte());
    #endregion 

    #region User, PIN, Schedule Information Attribute Set
    public static ReportAttribute NumberOfLogRecordsSupported { get; } = zcl.Report(0x0010, "Number Of Log Records Supported", r => r.ReadUInt16());
    public static ReportAttribute NumberOfTotalUsersSupported { get; } = zcl.Report(0x0011, "Number Of Total Users Supported", r => r.ReadUInt16());
    public static ReportAttribute NumberOfPINUsersSupported { get; } = zcl.Report(0x0012, "Number Of PIN Users Supported", r => r.ReadUInt16());
    public static ReportAttribute NumberOfRFIDUsersSupported { get; } = zcl.Report(0x0013, "Number Of RFID Users Supported", r => r.ReadUInt16());
    public static ReportAttribute NumberOfWeekDaySchedulesSupportedPerUser { get; } = zcl.Report(0x0014, "Number Of WeekDay Schedules Supported Per User", r => r.ReadByte());
    public static ReportAttribute NumberOfYearDaySchedulesSupportedPerUser { get; } = zcl.Report(0x0015, "Number Of Year Day Schedules Supported Per User", r => r.ReadByte());
    public static ReportAttribute NumberOfHolidaySchedulesSupported { get; } = zcl.Report(0x0016, "Number Of Holiday Schedules Supported", r => r.ReadByte());
    public static ReportAttribute MaxPINLength { get; } = zcl.Report(0x0017, "Max PIN length", r => r.ReadByte());
    public static ReportAttribute MinPINLength { get; } = zcl.Report(0x0018, "Min PIN length", r => r.ReadByte());
    #endregion 

    #region Operational Settings Attribute Set
    public static ReportAttribute EnableLogging { get; } = zcl.Report(0x0020, "Enable Logging", r => r.ReadBool());
    public static ReportAttribute Language { get; } = zcl.Report(0x0021, "Language", r => r.ReadString());
    public static ReportAttribute LedSetting { get; } = zcl.Report(0x0022, "Led Setting", r => r.ReadByte());
    public static ReportAttribute AutoRelockTime { get; } = zcl.Report(0x0023, "Auto Relock Time", r => r.ReadUInt32());
    public static ReportAttribute SoundVolume { get; } = zcl.Report(0x0024, "Sound Volume", r => r.ReadByte());
    public static ReportAttribute OperatingMode { get; } = zcl.Report(0x0025, "Operating mode", r => r.ReadByte());
    public static ReportAttribute SupportedOperatingMode { get; } = zcl.Report(0x0026, "Supported operating mode", r => r.ReadInt16());
    public static ReportAttribute DefaultConfigurationRegister { get; } = zcl.Report(0x0027, "Default Configuration Register", r => r.ReadInt16());
    public static ReportAttribute EnableLocalProgramming { get; } = zcl.Report(0x0028, "Enable Local Programming", r => r.ReadBool());
    public static ReportAttribute EnableOneTouchLocking { get; } = zcl.Report(0x0029, "Enable One TouchLocking", r => r.ReadBool());
    public static ReportAttribute EnableInsideStatusLED { get; } = zcl.Report(0x002A, "Enable Inside Status LED", r => r.ReadBool());
    public static ReportAttribute EnablePrivacyModeButton { get; } = zcl.Report(0x002B, "Enable Privacy ModeButton", r => r.ReadBool());
    #endregion 

    #region Security Settings Attribute Set
    public static ReportAttribute WrongCodeEntryLimit { get; } = zcl.Report(0x0030, "Wrong Code Entry Limit", r => r.ReadByte());
    public static ReportAttribute UserCodeTemporaryDisableTime { get; } = zcl.Report(0x0031, "User Code Temporary Disable Time", r => r.ReadByte());
    public static ReportAttribute SendPINOverTheAir { get; } = zcl.Report(0x0032, "Send PIN Over The Air", r => r.ReadBool());
    public static ReportAttribute RequirePINForRFOperation { get; } = zcl.Report(0x0033, "Require PIN for RF Operation", r => r.ReadBool());
    public static ReportAttribute ZigbeeSecurityLevel { get; } = zcl.Report(0x0034, "Zigbee Security Level", r => r.ReadByte());
    #endregion 

    #region Alarm and Event Masks Attribute Set
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x0040, "Alarm Mask", r => r.ReadInt16());
    public static ReportAttribute RFOperationEventMask { get; } = zcl.Report(0x0042, "RF Operation Event Mask", r => r.ReadInt16());
    public static ReportAttribute ManualOperationEventMask { get; } = zcl.Report(0x0043, "Manual Operation Event Mask", r => r.ReadInt16());
    #endregion 

    #region Xiaomi Special
    public static ReportAttribute EventType { get; } = zcl.Report(0x0055, "Event Type", r => r.ReadUInt16());
    public static ReportAttribute TiltAngle { get; } = zcl.Report(0x0503, "Tilt Angle", r => r.ReadUInt16());
    public static ReportAttribute VibrationStrength { get; } = zcl.Report(0x0505, "Vibration Strength", r => r.ReadUInt32());
    public static ReportAttribute Orientation { get; } = zcl.Report(0x0508, "Orientation", r => r.ReadUInt48());
    #endregion 

    #region ID Lock special
    public static ReportAttribute MasterPINMode { get; } = zcl.Report(0x4000, "Master PIN mode", r => r.ReadBool());
    public static ReportAttribute RFIDEnabled { get; } = zcl.Report(0x4001, "RFID Enabled", r => r.ReadBool());
    public static ReportAttribute HingeMode { get; } = zcl.Report(0x4002, "Hinge mode", r => r.ReadBool());
    public static ReportAttribute ServicePINMode { get; } = zcl.Report(0x4003, "Service PIN mode", r => r.ReadByte());
    public static ReportAttribute LockMode { get; } = zcl.Report(0x4004, "Lock mode", r => r.ReadByte());
    public static ReportAttribute RelockEnabled { get; } = zcl.Report(0x4005, "Relock enabled", r => r.ReadBool());
    public static ReportAttribute AudioVolume { get; } = zcl.Report(0x4006, "Audio volume", r => r.ReadByte());
    #endregion 

    public static Task LockDoor => Task.CompletedTask;
    public static Task UnlockDoor => Task.CompletedTask;
    public static Task ToggleDoor => Task.CompletedTask;
    public static Task UnlockWithTimer => Task.CompletedTask;
    public static Task GetLogRecord => Task.CompletedTask;
    public static Task GetLogRecordResponse => Task.CompletedTask;
    public static Task SetPINCode => Task.CompletedTask;
    public static Task SetPINCodeResponse => Task.CompletedTask;
    public static Task GetPINCode => Task.CompletedTask;
    public static Task GetPINCodeResponse => Task.CompletedTask;
    public static Task ClearPINCode => Task.CompletedTask;
    public static Task ClearPINCodeResponse => Task.CompletedTask;
    public static Task ClearAllPINCodes => Task.CompletedTask;
    public static Task ClearAllPINCodesResponse => Task.CompletedTask;
    public static Task OperationgEventNotification => Task.CompletedTask;
}
