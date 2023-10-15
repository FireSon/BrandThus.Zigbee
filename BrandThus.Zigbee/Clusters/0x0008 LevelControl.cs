namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides an interface for controlling a characteristic of a device that can be set to a level, for
/// example the brightness of a light, the degree of closure of a door, or the power output of a heater.
/// <summary>
[Cluster(0x0008, "Level Control")]
public static class ZclLevelControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLevelControl));

    public static ReportAttribute CurrentLevel { get; } = zcl.Report(0x0000, "Current Level", r => r.ReadByte());
    public static ReportAttribute RemainingTime { get; } = zcl.Report(0x0001, "Remaining Time", r => r.ReadUInt16());
    public static ReportAttribute HueMinDimLevel { get; } = zcl.Report(0x0003, "Hue Min Dim Level", r => r.ReadUInt16());
    public static ReportAttribute Options { get; } = zcl.Report(0x000f, "Options", r => r.ReadByte());
    public static ReportAttribute OnOffTransistionTime { get; } = zcl.Report(0x0010, "OnOff Transistion Time", r => r.ReadUInt16());
    public static ReportAttribute OnLevel { get; } = zcl.Report(0x0011, "On Level", r => r.ReadByte());
    public static ReportAttribute OnTransitionTime { get; } = zcl.Report(0x0012, "On Transition Time", r => r.ReadUInt16());
    public static ReportAttribute OffTransitionTime { get; } = zcl.Report(0x0013, "Off Transition Time", r => r.ReadUInt16());
    public static ReportAttribute DefaultMoveRate { get; } = zcl.Report(0x0014, "Default Move Rate", r => r.ReadByte());
    public static ReportAttribute StartUpCurrentLevel { get; } = zcl.Report(0x4000, "StartUp Current Level", r => r.ReadByte());
    public static Task MoveToLevel => Task.CompletedTask;
    public static Task Move => Task.CompletedTask;
    public static Task Step => Task.CompletedTask;
    public static Task Stop => Task.CompletedTask;
    public static Task MoveToLevelwithOnOff => Task.CompletedTask;
    public static Task MovewithOnOff => Task.CompletedTask;
    public static Task StepwithOnOff => Task.CompletedTask;
    public static Task StopwithOnOff => Task.CompletedTask;

}
