namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// This cluster provides an interface for controlling a characteristic of a device that can be set to a level, for
/// example the brightness of a light, the degree of closure of a door, or the power output of a heater.
/// <summary>
[Cluster(0x0008, "Level Control")]
public static class ZclLevelControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLevelControl));

    /// <summary>
    /// The CurrentLevel attribute represents the current level of this device. meaning of 'level' is device dependent.
    /// <summary>
    public static ReportAttribute CurrentLevel { get; } = zcl.Report(0x0000, "Current Level", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// The RemainingTime attribute represents the time remaining until the current command is complete - it is specified
    /// in 1/10ths of a second.
    /// <summary>
    public static ReportAttribute RemainingTime { get; } = zcl.Report(0x0001, "Remaining Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Percentage of the maximum lumen the device outputs on minimum brightness (in 0.001%).
    /// <summary>
    public static ReportAttribute HueMinDimLevel { get; } = zcl.Report(0x0003, "Hue Min Dim Level", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Options { get; } = zcl.Report(0x000f, "Options", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// The OnOffTransitionTime attribute represents the time taken to move to or from the target level when On of Off
    /// commands are received by an On/Off cluster on the same endpoint. It is specified in 1/10ths of a second. The actual
    /// time taken should be as close to OnOffTransitionTime as the device is able.
    /// <summary>
    public static ReportAttribute OnOffTransistionTime { get; } = zcl.Report(0x0010, "OnOff Transistion Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The OnLevel attribute determines the value that the CurrentLevel attribute is set to when the OnOff attribute
    /// of an On/Off cluster on the same endpoint is set to On. If the OnLevel attribute is not implemented, or is set
    /// to 0xff, it has no effect.
    /// <summary>
    public static ReportAttribute OnLevel { get; } = zcl.Report(0x0011, "On Level", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// The OnTransitionTime attribute represents the time taken to move the current level from the minimum level to the
    /// maximum level when an On command is received by an On/Off cluster on the same endpoint. It is specified in 10ths
    /// of a second. If this command is not implemented, or contains a value of 0xffff, the On/OffTransitionTime will
    /// be used instead.
    /// <summary>
    public static ReportAttribute OnTransitionTime { get; } = zcl.Report(0x0012, "On Transition Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The OffTransitionTime attribute represents the time taken to move the current level from the maximum level to
    /// the minimum level when an Off command is received by an On/Off cluster on the same endpoint. It is specified in
    /// 10ths of a second. If this command is not implemented, or contains a value of 0xffff, the On/OffTransitionTime
    /// will be used instead.
    /// <summary>
    public static ReportAttribute OffTransitionTime { get; } = zcl.Report(0x0013, "Off Transition Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The DefaultMoveRate attribute determines the movement rate, in units per second, when a Move command is received
    /// with a Rate parameter of 0xFF.
    /// <summary>
    public static ReportAttribute DefaultMoveRate { get; } = zcl.Report(0x0014, "Default Move Rate", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute StartUpCurrentLevel { get; } = zcl.Report(0x4000, "StartUp Current Level", ZigbeeType.U8, r => r.ReadByte());
    public static Task MoveToLevel(this ZigbeeNode node, byte level, ushort transistionTime) => node.Zcl(zcl, 0x00, w => w+ level+ transistionTime);
    public static Task Move(this ZigbeeNode node, byte moveMode, byte rate) => node.Zcl(zcl, 0x01, w => w+ moveMode+ rate);
    public static Task Step(this ZigbeeNode node, byte stepMode, byte stepSize, ushort transitionTime) => node.Zcl(zcl, 0x02, w => w+ stepMode+ stepSize+ transitionTime);
    public static Task Stop(this ZigbeeNode node) => node.Zcl(zcl, 0x03);
    public static Task MoveToLevelwithOnOff(this ZigbeeNode node, byte level, ushort transistionTime) => node.Zcl(zcl, 0x04, w => w+ level+ transistionTime);
    public static Task MovewithOnOff(this ZigbeeNode node, byte moveMode, byte rate) => node.Zcl(zcl, 0x05, w => w+ moveMode+ rate);
    public static Task StepwithOnOff(this ZigbeeNode node, byte stepMode, byte stepSize, ushort transitionTime) => node.Zcl(zcl, 0x06, w => w+ stepMode+ stepSize+ transitionTime);
    public static Task StopwithOnOff(this ZigbeeNode node) => node.Zcl(zcl, 0x07);

}
