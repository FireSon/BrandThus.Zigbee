namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Additional features implemented in Leviton’s DG6HD.
/// <summary>
[Cluster(0x8007, "Leviton Specific Load Cluster")]
public static class ZclLevitonSpecificLoadCluster
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLevitonSpecificLoadCluster));

    /// <summary>
    /// Minimum Level represents the minimum level the dimmer can be set to. This must be lower than Maximum Level.
    /// <summary>
    public static ReportAttribute MinDimLevel { get; } = zcl.Report(0x0001, "Min Dim Level", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Maximum Level represents the maximum level the dimmer can be set to. This must be greater than Minimum Level.
    /// <summary>
    public static ReportAttribute MaxDimLevel { get; } = zcl.Report(0x0002, "Max Dim Level", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Represents how the Locator LED functions. This can be set to ALWAYS ON (0x00), ALWAYS OFF (0X01), or a timed delay
    /// (0x02 to 0xFF). The Timed delay is always seconds -1. When using timed delay, the led will come on when a button
    /// is pressed.
    /// <summary>
    public static ReportAttribute LocatorLED { get; } = zcl.Report(0x0003, "Locator LED", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Represents how the Dimming LED functions. This can be set to ALWAYS ON (0x00), ALWAYS OFF (0X01), or a timed delay
    /// (0x02 to 0xFF). The Timed delay is always seconds -1. When using timed delay, the led will come on when a button
    /// is pressed.
    /// <summary>
    public static ReportAttribute DimmingLED { get; } = zcl.Report(0x0004, "Dimming LED", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Initial On Level represents the desired level to be applied to a dimmer when an “On” button is pressed. 0x00 :
    /// Go to the last level set. 0x01-0xFF : Go to a specific level
    /// <summary>
    public static ReportAttribute InitialOnLevel { get; } = zcl.Report(0x0007, "Initial On Level", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Power Restore represents the option to turn the switch/dimmer back to its previous level when powered up, or remain
    /// off.
    /// <summary>
    public static ReportAttribute PowerRestore { get; } = zcl.Report(0x0008, "Power Restore", ZigbeeType.Bool, r => r.ReadBool());
    /// <summary>
    /// Represents the ramp time when pressing and holding the dim/brighten button on a dimmer. This value represents
    /// the amount of time needed to go from 0% to 100%. This time value is in 0.1s increments
    /// <summary>
    public static ReportAttribute PressAndHoldTime { get; } = zcl.Report(0x0009, "Press and Hold Time", ZigbeeType.U8, r => r.ReadByte());
}
