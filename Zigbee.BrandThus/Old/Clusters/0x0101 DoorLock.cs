namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The door lock cluster provides an interface to a generic way to secure a door.
/// <summary>
[Cluster(0x0101, "Door Lock")]
public static class ZclDoorLock
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDoorLock));

    #region Basic Information Attribute Set
    public enum LockStateEnum
    {
        NotFullyLocked = 0x00,
        Locked = 0x01,
        Unlocked = 0x02,
        Undefined = 0xff,
    }

    public static ReportAttribute LockState { get; } = zcl.Report(0x0000, "Lock State", ZigbeeType.Enum8, r => (LockStateEnum)r.ReadByte());
    public enum LockTypeEnum
    {
        DeadBolt = 0x00,
        Magnetic = 0x01,
        Other = 0x02,
        Mortise = 0x03,
        Rim = 0x04,
        LatchBolt = 0x05,
        CylindricalLock = 0x06,
        TubularLock = 0x07,
        InterconnectedLock = 0x08,
        DeadLatch = 0x09,
        DoorFurniture = 0x0A,
    }

    public static ReportAttribute LockType { get; } = zcl.Report(0x0001, "Lock Type", ZigbeeType.Enum8, r => (LockTypeEnum)r.ReadByte());
    public static ReportAttribute ActuatorEnabled { get; } = zcl.Report(0x0002, "Actuator enabled", ZigbeeType.Bool, r => r.ReadBool());
    public enum DoorStateEnum
    {
        Open = 0x00,
        Closed = 0x01,
        ErrorJammed = 0x02,
        ErrorForcedOpen = 0x03,
        ErrorUnspecified = 0x04,
        Undefined = 0xff,
    }

    public static ReportAttribute DoorState { get; } = zcl.Report(0x0003, "Door state", ZigbeeType.Enum8, r => (DoorStateEnum)r.ReadByte());
    #endregion 

    #region User, PIN, Schedule Information Attribute Set
    public static ReportAttribute NumberOfLogRecordsSupported { get; } = zcl.Report(0x0010, "Number Of Log Records Supported", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfTotalUsersSupported { get; } = zcl.Report(0x0011, "Number Of Total Users Supported", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfPINUsersSupported { get; } = zcl.Report(0x0012, "Number Of PIN Users Supported", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfRFIDUsersSupported { get; } = zcl.Report(0x0013, "Number Of RFID Users Supported", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfWeekDaySchedulesSupportedPerUser { get; } = zcl.Report(0x0014, "Number Of WeekDay Schedules Supported Per User", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute NumberOfYearDaySchedulesSupportedPerUser { get; } = zcl.Report(0x0015, "Number Of Year Day Schedules Supported Per User", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute NumberOfHolidaySchedulesSupported { get; } = zcl.Report(0x0016, "Number Of Holiday Schedules Supported", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute MaxPINLength { get; } = zcl.Report(0x0017, "Max PIN length", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute MinPINLength { get; } = zcl.Report(0x0018, "Min PIN length", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Operational Settings Attribute Set
    public static ReportAttribute EnableLogging { get; } = zcl.Report(0x0020, "Enable Logging", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute Language { get; } = zcl.Report(0x0021, "Language", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute LedSetting { get; } = zcl.Report(0x0022, "Led Setting", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute AutoRelockTime { get; } = zcl.Report(0x0023, "Auto Relock Time", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute SoundVolume { get; } = zcl.Report(0x0024, "Sound Volume", ZigbeeType.U8, r => r.ReadByte());
    public enum OperatingModeEnum
    {
        Normal = 0x00,
        Vacation = 0x01,
        Privacy = 0x02,
        NoRFLockUnlock = 0x03,
        Passage = 0x04,
    }

    public static ReportAttribute OperatingMode { get; } = zcl.Report(0x0025, "Operating mode", ZigbeeType.Enum8, r => (OperatingModeEnum)r.ReadByte());
    public static ReportAttribute SupportedOperatingMode { get; } = zcl.Report(0x0026, "Supported operating mode", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute DefaultConfigurationRegister { get; } = zcl.Report(0x0027, "Default Configuration Register", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute EnableLocalProgramming { get; } = zcl.Report(0x0028, "Enable Local Programming", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute EnableOneTouchLocking { get; } = zcl.Report(0x0029, "Enable One TouchLocking", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute EnableInsideStatusLED { get; } = zcl.Report(0x002A, "Enable Inside Status LED", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute EnablePrivacyModeButton { get; } = zcl.Report(0x002B, "Enable Privacy ModeButton", ZigbeeType.Bool, r => r.ReadBool());
    #endregion 

    #region Security Settings Attribute Set
    public static ReportAttribute WrongCodeEntryLimit { get; } = zcl.Report(0x0030, "Wrong Code Entry Limit", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute UserCodeTemporaryDisableTime { get; } = zcl.Report(0x0031, "User Code Temporary Disable Time", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute SendPINOverTheAir { get; } = zcl.Report(0x0032, "Send PIN Over The Air", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute RequirePINForRFOperation { get; } = zcl.Report(0x0033, "Require PIN for RF Operation", ZigbeeType.Bool, r => r.ReadBool());
    public enum ZigbeeSecurityLevelEnum
    {
        NetworkSecurity = 0x00,
        APSSecurity = 0x01,
    }

    public static ReportAttribute ZigbeeSecurityLevel { get; } = zcl.Report(0x0034, "Zigbee Security Level", ZigbeeType.Enum8, r => (ZigbeeSecurityLevelEnum)r.ReadByte());
    #endregion 

    #region Alarm and Event Masks Attribute Set
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x0040, "Alarm Mask", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute RFOperationEventMask { get; } = zcl.Report(0x0042, "RF Operation Event Mask", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute ManualOperationEventMask { get; } = zcl.Report(0x0043, "Manual Operation Event Mask", ZigbeeType.Bmp16, r => r.ReadInt16());
    #endregion 

    #region Xiaomi Special
    public static ReportAttribute EventType { get; } = zcl.Report(0x0055, "Event Type", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute TiltAngle { get; } = zcl.Report(0x0503, "Tilt Angle", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute VibrationStrength { get; } = zcl.Report(0x0505, "Vibration Strength", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute Orientation { get; } = zcl.Report(0x0508, "Orientation", ZigbeeType.U48, r => r.ReadUInt48());
    #endregion 

    #region ID Lock special
    public static ReportAttribute MasterPINMode { get; } = zcl.Report(0x4000, "Master PIN mode", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute RFIDEnabled { get; } = zcl.Report(0x4001, "RFID Enabled", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute HingeMode { get; } = zcl.Report(0x4002, "Hinge mode", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ServicePINMode { get; } = zcl.Report(0x4003, "Service PIN mode", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute LockMode { get; } = zcl.Report(0x4004, "Lock mode", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute RelockEnabled { get; } = zcl.Report(0x4005, "Relock enabled", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute AudioVolume { get; } = zcl.Report(0x4006, "Audio volume", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    /// <summary>
    /// This command causes the lock device to lock the door.
    /// <summary>
    public static Task LockDoor(this ZigbeeNode node) => node.Zcl(zcl, 0x00);
    /// <summary>
    /// This command causes the lock device to unlock the door.
    /// <summary>
    public static Task UnlockDoor(this ZigbeeNode node) => node.Zcl(zcl, 0x01);
    /// <summary>
    /// This command toggle the lock device.
    /// <summary>
    public static Task ToggleDoor(this ZigbeeNode node) => node.Zcl(zcl, 0x02);
    /// <summary>
    /// This command Unlock the lock device but with a timer.
    /// <summary>
    public static Task UnlockWithTimer(this ZigbeeNode node, ushort timeout) => node.Zcl(zcl, 0x03, w => w+ timeout);
    /// <summary>
    /// Request a log record.
    /// <summary>
    public static Task GetLogRecord(this ZigbeeNode node, ushort logIndex) => node.Zcl(zcl, 0x04, w => w+ logIndex);
    /// <summary>
    /// Returns the specified log record.
    /// <summary>
    public static Task GetLogRecordResponse(this ZigbeeNode node, ushort logEntryID, uint timestamp, byte eventType, byte source, byte eventIDAlarmCode, ushort userID, string pIN) => node.Zcl(zcl, 0x04, w => w+ logEntryID+ timestamp+ eventType+ source+ eventIDAlarmCode+ userID+ pIN);
    /// <summary>
    /// Set PIN-code for user. User ID is between 0 and [# of PIN Users Supported Attribute]
    /// <summary>
    public static Task SetPINCode(this ZigbeeNode node, ushort userID, byte userStatus, byte userType, string code) => node.Zcl(zcl, 0x05, w => w+ userID+ userStatus+ userType+ code);
    /// <summary>
    /// Status
    /// <summary>
    public static Task SetPINCodeResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 0x05, w => w+ status);
    /// <summary>
    /// Get PIN code for user. User ID is between 0 and [# of PIN Users Supported Attribute]
    /// <summary>
    public static Task GetPINCode(this ZigbeeNode node, ushort userID) => node.Zcl(zcl, 0x06, w => w+ userID);
    /// <summary>
    /// Returns PIN-code for user.
    /// <summary>
    public static Task GetPINCodeResponse(this ZigbeeNode node, ushort userID, byte userStatus, byte userType, string code) => node.Zcl(zcl, 0x06, w => w+ userID+ userStatus+ userType+ code);
    /// <summary>
    /// Clear PIN code for user. User ID is between 0 and [# of PIN Users Supported Attribute]
    /// <summary>
    public static Task ClearPINCode(this ZigbeeNode node, ushort userID) => node.Zcl(zcl, 0x07, w => w+ userID);
    /// <summary>
    /// Status
    /// <summary>
    public static Task ClearPINCodeResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 0x07, w => w+ status);
    /// <summary>
    /// Clear all registred PIN codes.
    /// <summary>
    public static Task ClearAllPINCodes(this ZigbeeNode node) => node.Zcl(zcl, 0x08);
    /// <summary>
    /// Status
    /// <summary>
    public static Task ClearAllPINCodesResponse(this ZigbeeNode node, byte status) => node.Zcl(zcl, 0x08, w => w+ status);
    /// <summary>
    /// The door lock server sends out operation event notification when the event is triggered by the various event sources.
    /// <summary>
    public static Task OperationgEventNotification(this ZigbeeNode node, byte operationEventSource, byte operationEventCode, ushort userID, byte pIN, uint zigBeeLocalTime, string data) => node.Zcl(zcl, 0x20, w => w+ operationEventSource+ operationEventCode+ userID+ pIN+ zigBeeLocalTime+ data);
}
