namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Hue-specific cluster for Hue Secure Contact Sensor.
/// <summary>
[Cluster(0xfc06, "Hue Secure")]
public static class ZclHueSecure
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclHueSecure));

    public enum ContactEnum
    {
        Close = 0,
        Open = 1,
    }

    public static ReportAttribute Contact { get; } = zcl.Report(0x0100, "Contact", ZigbeeType.Enum8, r => (ContactEnum)r.ReadByte());
    /// <summary>
    /// The time in 0.1s since last change to the Contact state.
    /// <summary>
    public static ReportAttribute LastContactChange { get; } = zcl.Report(0x0101, "Last Contact Change", ZigbeeType.U32, r => r.ReadUInt32());
    public enum TamperEnum
    {
        BatteryDoorClosed = 0,
        BatteryDoorOpen = 1,
    }

    public static ReportAttribute Tamper { get; } = zcl.Report(0x0102, "Tamper", ZigbeeType.Enum8, r => (TamperEnum)r.ReadByte());
    /// <summary>
    /// The time in 0.1s since last change to the Tamper state.
    /// <summary>
    public static ReportAttribute LastTamperChange { get; } = zcl.Report(0x0103, "Last Tamper Change", ZigbeeType.U32, r => r.ReadUInt32());
}
