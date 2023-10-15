namespace BrandThus.Zigbee.Clusters;

/// <summary>
///   				The Simple Metering Cluster provides a mechanism to retrieve usage information from Electric, Gas, Water,
/// and potentially Thermal metering devices.  				These devices can operate on either battery or mains power, and
/// can have a wide variety of sophistication.  			
/// <summary>
[Cluster(0x0702, "Simple Metering")]
public static class ZclSimpleMetering
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSimpleMetering));

    #region Reading Information Set
    public static ReportAttribute CurrentSummationDelivered { get; } = zcl.Report(0x0000, "Current Summation Delivered", r => r.ReadUInt48());
    public static ReportAttribute CurrentSummationReceived { get; } = zcl.Report(0x0001, "Current Summation Received", r => r.ReadUInt48());
    #endregion 

    #region TOU Information Set
    public static ReportAttribute IndexHCHCEJPHNBBRHCJBCurrentSummationDelivered1 { get; } = zcl.Report(0x0100, "Index HCHC/EJPHN/BBRHCJB, Current Summation Delivered (1)", r => r.ReadUInt48());
    public static ReportAttribute IndexHCHPEJPHPMBBRHPJBCurrentSummationDelivered2 { get; } = zcl.Report(0x0102, "Index HCHP/EJPHPM/BBRHPJB, Current Summation Delivered(2)", r => r.ReadUInt48());
    #endregion 

    #region Meter Status
    public static ReportAttribute Status { get; } = zcl.Report(0x0200, "Status", r => r.ReadByte());
    #endregion 

    #region Formatting
    public static ReportAttribute UnitOfMeasure { get; } = zcl.Report(0x0300, "Unit of Measure", r => r.ReadByte());
    public static ReportAttribute Multiplier { get; } = zcl.Report(0x0301, "Multiplier", r => r.ReadUInt24());
    public static ReportAttribute Divisor { get; } = zcl.Report(0x0302, "Divisor", r => r.ReadUInt24());
    public static ReportAttribute SummationFormatting { get; } = zcl.Report(0x0303, "Summation Formatting", r => r.ReadByte());
    public static ReportAttribute DemandFormatting { get; } = zcl.Report(0x0304, "Demand Formatting", r => r.ReadByte());
    public static ReportAttribute MeteringDeviceType { get; } = zcl.Report(0x0306, "Metering Device Type", r => r.ReadByte());
    public static ReportAttribute MeterSerialNumber { get; } = zcl.Report(0x0308, "Meter Serial Number", r => r.ReadString());
    #endregion 

    #region Develco specific
    #endregion 

    #region ESP Historical Consumption
    public static ReportAttribute InstantaneousDemand { get; } = zcl.Report(0x0400, "Instantaneous Demand", r => r.ReadByte());
    #endregion 

    #region Load Profile Configuration
    #endregion 

    #region Supply Limit
    #endregion 

    public static Task GetProfile => Task.CompletedTask;
    public static Task RequestMirrorResponse => Task.CompletedTask;
    public static Task MirrorRemoved => Task.CompletedTask;

}
