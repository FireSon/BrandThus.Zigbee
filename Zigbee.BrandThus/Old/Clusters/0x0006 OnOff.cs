namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for switching devices between 'On' and 'Off' states.
/// <summary>
[Cluster(0x0006, "On/Off")]
public static class ZclOnOff
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOnOff));

    #region OnOff state
    public static ReportAttribute OnOff { get; } = zcl.Report(0000, "OnOff", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute GlobalSceneControl { get; } = zcl.Report(0x4000, "GlobalSceneControl", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute OnTime { get; } = zcl.Report(0x4001, "OnTime", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute OffWaitTime { get; } = zcl.Report(0x4002, "OffWaitTime", ZigbeeType.U16, r => r.ReadUInt16());
    public enum StartUpOnOffEnum
    {
        Off = 0x00,
        On = 0x01,
        Toggle = 0x02,
        Previous = 0xff,
    }

    public static ReportAttribute StartUpOnOff { get; } = zcl.Report(0x4003, "StartUp OnOff", ZigbeeType.Enum8, r => (StartUpOnOffEnum)r.ReadByte());
    #endregion 

    #region Xiaomi
    public static ReportAttribute ButtonPress { get; } = zcl.Report(0x8000, "Button Press", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Tuya special
    public enum BackLightModeEnum
    {
        Mode1Off = 0,
        Mode2LightWhenOn = 1,
        Mode3LightWhenOff = 2,
        Mode4ActualState = 3,
    }

    public static ReportAttribute BackLightMode { get; } = zcl.Report(0x8001, "Back Light mode", ZigbeeType.Enum8, r => (BackLightModeEnum)r.ReadByte());
    public enum PowerOnStateEnum
    {
        Off = 0,
        On = 1,
        LastState = 2,
    }

    public static ReportAttribute PowerOnState { get; } = zcl.Report(0x8002, "Power on state", ZigbeeType.Enum8, r => (PowerOnStateEnum)r.ReadByte());
    public static ReportAttribute OverCurrentAlarm { get; } = zcl.Report(0x8003, "Over current alarm", ZigbeeType.Bool, r => r.ReadBool());
    public enum SwitchOperationModeEnum
    {
        CommandModeLightOnOffDimmerCommands = 0,
        EventModeTuyaSceneCommands = 1,
    }

    public static ReportAttribute SwitchOperationMode { get; } = zcl.Report(0x8004, "Switch operation mode", ZigbeeType.Enum8, r => (SwitchOperationModeEnum)r.ReadByte());
    #endregion 

    #region Schneider specific
    /// <summary>
    /// Defines number of seconds before the light is switched off automaticaly. Time is in seconds. Value 0 disables
    /// the functionality. When brightness is changed, or ON command is received, timer is always restarted. Check On
    /// Time Reload Options for possible impulse modes (if attribute is implemented).
    /// <summary>
    public static ReportAttribute SchneiderOnTimeReload { get; } = zcl.Report(0xe001, "On Time Reload", ZigbeeType.U32, r => r.ReadUInt32());
    #endregion 

    /// <summary>
    /// On receipt of this command, a device shall enter its 'Off' state. This state is device dependent, but it is recommended
    /// that it is used for power off or similar functions.
    /// <summary>
    public static Task Off(this ZigbeeNode node) => node.Zcl(zcl, 00);
    /// <summary>
    /// On receipt of this command, a device shall enter its 'On' state. This state is device dependent, but it is recommended
    /// that it is used for power on or similar functions.
    /// <summary>
    public static Task On(this ZigbeeNode node) => node.Zcl(zcl, 01);
    /// <summary>
    /// On receipt of this command, if a device is in its ‘Off’ state it shall enter its 'On' state. Otherwise, if it
    /// is in its ‘On’ state it shall enter its 'Off' state.
    /// <summary>
    public static Task Toggle(this ZigbeeNode node) => node.Zcl(zcl, 02);
    public static Task OffWithEffect(this ZigbeeNode node, byte effectIdentifier, byte effectVariant) => node.Zcl(zcl, 40, w => w+ effectIdentifier+ effectVariant);
    /// <summary>
    /// The on with recall global scene command allows the recall of the light settings when the light was turned off.
    /// <summary>
    public static Task OnWithRecallGlobalScene(this ZigbeeNode node) => node.Zcl(zcl, 41);
    /// <summary>
    /// Allows lamps to be turned on for a specific duration with a guarded off duration so that should the lamp be subsequently
    /// switched off, further on with timed off commands, received during this time, are prevented from turning the lamps
    /// back on.
    /// <summary>
    public static Task OnWithTimedOff(this ZigbeeNode node, byte onoffControl, ushort onTime, ushort offWaitTime) => node.Zcl(zcl, 42, w => w+ onoffControl+ onTime+ offWaitTime);
}
