namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0406, "Occupancy sensing")]
public static class ZclOccupancySensing
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOccupancySensing));

    #region Occupancy sensor information
    public static ReportAttribute Occupancy { get; } = zcl.Report(0x0000, "Occupancy", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum OccupancySensorTypeEnum
    {
        PIR = 0x00,
        Ultrasonic = 0x01,
        PIRAndUltrasonic = 0x02,
        PhysicalContact = 0x03,
    }

    public static ReportAttribute OccupancySensorType { get; } = zcl.Report(0x0001, "Occupancy Sensor Type", ZigbeeType.Enum8, r => (OccupancySensorTypeEnum)r.ReadByte());
    public static ReportAttribute OccupancySensorTypeBitmap { get; } = zcl.Report(0x0002, "Occupancy Sensor Type Bitmap", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region PIR configuration
    /// <summary>
    /// The PIROccupiedToUnoccupiedDelay attribute is 16-bits in length and specifies the time delay, in seconds, before
    /// the PIR sensor changes to its occupied state when the sensed area becomes unoccupied. This attribute, along with
    /// PIRUnoccupiedToOccupiedTime, may be used to reduce sensor 'chatter' when used in an area where occupation changes
    /// frequently.
    /// <summary>
    public static ReportAttribute PIROccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0010, "PIR Occupied To Unoccupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The PIRUnoccupiedToOccupiedDelay attribute is 16-bits in length and specifies the time delay, in seconds, before
    /// the PIR sensor changes to its unoccupied state when the sensed area becomes occupied.
    /// <summary>
    public static ReportAttribute PIRUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0011, "PIR Unoccupied To Occupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The PIRUnoccupiedToOccupiedThreshold attribute is 8 bits in length and specifies the number of movement detection
    /// events that must occur in the period PIRUnoccupiedToOccupiedDelay, before the PIR sensor changes to its occupied
    /// state.
    /// <summary>
    public static ReportAttribute PIRUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0012, "PIR Unoccupied To Occupied Threshold", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Ultrasonic configuration
    /// <summary>
    /// The UltraSonicOccupiedToUnoccupiedDelay attribute specifies the time delay, in seconds, before the ultrasonic
    /// sensor changes to its occupied state when the sensed area becomes unoccupied. This attribute, along with UltraSonicUnoccupiedToOccupiedTime,
    /// may be used to reduce sensor 'chatter' when used in an area where occupation changes frequently.
    /// <summary>
    public static ReportAttribute UltrasonicOccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0020, "Ultrasonic Occupied To Unoccupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The UltraSonicUnoccupiedToOccupiedDelay attribute specifies the time delay, in seconds, before the ultrasonic
    /// sensor changes to its unoccupied state when the sensed area becomes occupied.
    /// <summary>
    public static ReportAttribute UltrasonicUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0021, "Ultrasonic Unoccupied To Occupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The UltrasonicUnoccupiedToOccupiedThreshold attribute is 8 bits in length and specifies the number of movement
    /// detection events that must occur in the period PIRUnoccupiedToOccupiedDelay, before the PIR sensor changes to
    /// its occupied state.
    /// <summary>
    public static ReportAttribute UltrasonicUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0022, "Ultrasonic Unoccupied To Occupied Threshold", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Physical Contact configuration
    /// <summary>
    /// The PhysicalContactOccupiedToUnoccupiedDelay attribute specifies the time delay, in seconds, before the Physical
    /// Contact sensor changes to its occupied state when the sensed area becomes unoccupied. This attribute, along with
    /// UltraSonicUnoccupiedToOccupiedTime, may be used to reduce sensor 'chatter' when used in an area where occupation
    /// changes frequently.
    /// <summary>
    public static ReportAttribute PhysicalContactOccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0030, "Physical Contact Occupied To Unoccupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The PhysicalContactUnoccupiedToOccupiedDelay attribute specifies the time delay, in seconds, before the Physical
    /// Contact sensor changes to its unoccupied state when the sensed area becomes occupied.
    /// <summary>
    public static ReportAttribute PhysicalContactUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0031, "Physical Contact Unoccupied To Occupied Delay", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The PhysicalContactUnoccupiedToOccupiedThreshold attribute is 8 bits in length and specifies the number of movement
    /// detection events that must occur in the period PIRUnoccupiedToOccupiedDelay, before the PIR sensor changes to
    /// its occupied state.
    /// <summary>
    public static ReportAttribute PhysicalContactUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0032, "Physical Contact Unoccupied To Occupied Threshold", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Philips Specific
    #endregion 

    #region Develco Specific
    public static ReportAttribute ArmThreshold_MinTemperature { get; } = zcl.Report(0xfc00, "ArmThreshold_MinTemperature", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ArmThreshold_MaxTemperature { get; } = zcl.Report(0xfc01, "ArmThreshold_MaxTemperature", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute TargetLevel { get; } = zcl.Report(0xfc02, "Target Level", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

}
