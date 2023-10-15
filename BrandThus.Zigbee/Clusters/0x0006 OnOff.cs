namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for switching devices between 'On' and 'Off' states.
/// <summary>
[Cluster(0x0006, "On/Off")]
public static class ZclOnOff
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOnOff));

    #region OnOff state
    public static ReportAttribute OnOff { get; } = zcl.Report(0000, "OnOff", r => r.ReadBool());
    public static ReportAttribute GlobalSceneControl { get; } = zcl.Report(0x4000, "GlobalSceneControl", r => r.ReadBool());
    public static ReportAttribute OnTime { get; } = zcl.Report(0x4001, "OnTime", r => r.ReadUInt16());
    public static ReportAttribute OffWaitTime { get; } = zcl.Report(0x4002, "OffWaitTime", r => r.ReadUInt16());
    public static ReportAttribute StartUpOnOff { get; } = zcl.Report(0x4003, "StartUp OnOff", r => r.ReadByte());
    #endregion 

    #region Xiaomi
    public static ReportAttribute ButtonPress { get; } = zcl.Report(0x8000, "Button Press", r => r.ReadByte());
    #endregion 

    #region Tuya special
    public static ReportAttribute BackLightMode { get; } = zcl.Report(0x8001, "Back Light mode", r => r.ReadByte());
    public static ReportAttribute PowerOnState { get; } = zcl.Report(0x8002, "Power on state", r => r.ReadByte());
    public static ReportAttribute OverCurrentAlarm { get; } = zcl.Report(0x8003, "Over current alarm", r => r.ReadBool());
    public static ReportAttribute SwitchOperationMode { get; } = zcl.Report(0x8004, "Switch operation mode", r => r.ReadByte());
    #endregion 

    #region Schneider specific
    public static ReportAttribute SchneiderOnTimeReload { get; } = zcl.Report(0xe001, "On Time Reload", r => r.ReadUInt32());
    #endregion 

    public static Task Off => Task.CompletedTask;
    public static Task On => Task.CompletedTask;
    public static Task Toggle => Task.CompletedTask;
    public static Task OffWithEffect => Task.CompletedTask;
    public static Task OnWithRecallGlobalScene => Task.CompletedTask;
    public static Task OnWithTimedOff => Task.CompletedTask;
}
