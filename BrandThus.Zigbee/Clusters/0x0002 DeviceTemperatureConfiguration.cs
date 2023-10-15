namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes for determining information about a device’s internal temperature, and for configuring under/over temperature
/// alarms.
/// <summary>
[Cluster(0x0002, "Device Temperature Configuration")]
public static class ZclDeviceTemperatureConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDeviceTemperatureConfiguration));

    #region Device Temperature Information
    public static ReportAttribute CurrentTemperature { get; } = zcl.Report(0x0000, "Current Temperature", r => r.ReadInt16());
    public static ReportAttribute MinTempExperienced { get; } = zcl.Report(0x0001, "Min Temp Experienced", r => r.ReadInt16());
    public static ReportAttribute MaxTempExperienced { get; } = zcl.Report(0x0002, "Max Temp Experienced", r => r.ReadInt16());
    public static ReportAttribute OverTempTotalDwell { get; } = zcl.Report(0x0003, "Over Temp Total Dwell", r => r.ReadUInt16());
    #endregion 

    #region Device Temperature Settings
    public static ReportAttribute DeviceTempAlarmMask { get; } = zcl.Report(0x0010, "Device Temp Alarm Mask", r => r.ReadByte());
    public static ReportAttribute LowTempThreshold { get; } = zcl.Report(0x0011, "Low Temp Threshold", r => r.ReadInt16());
    public static ReportAttribute HighTempThreshold { get; } = zcl.Report(0x0012, "High Temp Threshold", r => r.ReadInt16());
    public static ReportAttribute LowTempDwellTripPoint { get; } = zcl.Report(0x0013, "Low Temp Dwell Trip Point", r => r.ReadUInt24());
    public static ReportAttribute HighTempDwellTripPoint { get; } = zcl.Report(0x0014, "High Temp Dwell Trip Point", r => r.ReadUInt24());
    #endregion 

}
