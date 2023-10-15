namespace BrandThus.Zigbee.Clusters;

[Cluster(0x0406, "Occupancy sensing")]
public static class ZclOccupancySensing
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOccupancySensing));

    #region Occupancy sensor information
    public static ReportAttribute Occupancy { get; } = zcl.Report(0x0000, "Occupancy", r => r.ReadByte());
    public static ReportAttribute OccupancySensorType { get; } = zcl.Report(0x0001, "Occupancy Sensor Type", r => r.ReadByte());
    public static ReportAttribute OccupancySensorTypeBitmap { get; } = zcl.Report(0x0002, "Occupancy Sensor Type Bitmap", r => r.ReadByte());
    #endregion 

    #region PIR configuration
    public static ReportAttribute PIROccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0010, "PIR Occupied To Unoccupied Delay", r => r.ReadUInt16());
    public static ReportAttribute PIRUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0011, "PIR Unoccupied To Occupied Delay", r => r.ReadUInt16());
    public static ReportAttribute PIRUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0012, "PIR Unoccupied To Occupied Threshold", r => r.ReadByte());
    #endregion 

    #region Ultrasonic configuration
    public static ReportAttribute UltrasonicOccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0020, "Ultrasonic Occupied To Unoccupied Delay", r => r.ReadUInt16());
    public static ReportAttribute UltrasonicUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0021, "Ultrasonic Unoccupied To Occupied Delay", r => r.ReadUInt16());
    public static ReportAttribute UltrasonicUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0022, "Ultrasonic Unoccupied To Occupied Threshold", r => r.ReadByte());
    #endregion 

    #region Physical Contact configuration
    public static ReportAttribute PhysicalContactOccupiedToUnoccupiedDelay { get; } = zcl.Report(0x0030, "Physical Contact Occupied To Unoccupied Delay", r => r.ReadUInt16());
    public static ReportAttribute PhysicalContactUnoccupiedToOccupiedDelay { get; } = zcl.Report(0x0031, "Physical Contact Unoccupied To Occupied Delay", r => r.ReadUInt16());
    public static ReportAttribute PhysicalContactUnoccupiedToOccupiedThreshold { get; } = zcl.Report(0x0032, "Physical Contact Unoccupied To Occupied Threshold", r => r.ReadByte());
    #endregion 

    #region Philips Specific
    #endregion 

    #region Develco Specific
    public static ReportAttribute ArmThreshold_MinTemperature { get; } = zcl.Report(0xfc00, "ArmThreshold_MinTemperature", r => r.ReadInt16());
    public static ReportAttribute ArmThreshold_MaxTemperature { get; } = zcl.Report(0xfc01, "ArmThreshold_MaxTemperature", r => r.ReadInt16());
    public static ReportAttribute TargetLevel { get; } = zcl.Report(0xfc02, "Target Level", r => r.ReadUInt16());
    #endregion 

}
