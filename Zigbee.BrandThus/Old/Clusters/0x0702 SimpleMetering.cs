namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Simple Metering Cluster provides a mechanism to retrieve usage information from Electric, Gas, Water, and
/// potentially Thermal metering devices. These devices can operate on either battery or mains power, and can have
/// a wide variety of sophistication.
/// <summary>
[Cluster(0x0702, "Simple Metering")]
public static class ZclSimpleMetering
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclSimpleMetering));

    #region Reading Information Set
    public static ReportAttribute CurrentSummationDelivered { get; } = zcl.Report(0x0000, "Current Summation Delivered", ZigbeeType.U48, r => r.ReadUInt48());
    public static ReportAttribute CurrentSummationReceived { get; } = zcl.Report(0x0001, "Current Summation Received", ZigbeeType.U48, r => r.ReadUInt48());
    #endregion 

    #region TOU Information Set
    public static ReportAttribute IndexHCHCEJPHNBBRHCJBCurrentSummationDelivered1 { get; } = zcl.Report(0x0100, "Index HCHC/EJPHN/BBRHCJB, Current Summation Delivered (1)", ZigbeeType.U48, r => r.ReadUInt48());
    public static ReportAttribute IndexHCHPEJPHPMBBRHPJBCurrentSummationDelivered2 { get; } = zcl.Report(0x0102, "Index HCHP/EJPHPM/BBRHPJB, Current Summation Delivered(2)", ZigbeeType.U48, r => r.ReadUInt48());
    #endregion 

    #region Meter Status
    public static ReportAttribute Status { get; } = zcl.Report(0x0200, "Status", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Formatting
    public enum UnitOfMeasureEnum
    {
        KWKWhBinary = 0,
        MMhBinary = 1,
        FtFthBinary = 2,
        CcfCcfhBinary = 3,
        USGlUsGlhBinary = 4,
        IMPGlIMPGlhBinary = 5,
        BTUsBTUhBinary = 6,
        LitersLhBinary = 7,
        KPAgaugeBinary = 8,
        KPAabsoluteBinary = 9,
        KWKWhBCD = 80,
        MMhBCD = 81,
        FtFthBCD = 82,
        CcfCcfhBCD = 83,
        USGlUsGlhBCD = 84,
        IMPGlIMPGlhBCD = 85,
        BTUsBTUhBCD = 86,
        LitersLhBCD = 87,
        KPAgaugeBCD = 88,
        KPAabsoluteBCD = 89,
    }

    public static ReportAttribute UnitOfMeasure { get; } = zcl.Report(0x0300, "Unit of Measure", ZigbeeType.Enum8, r => (UnitOfMeasureEnum)r.ReadByte());
    public static ReportAttribute Multiplier { get; } = zcl.Report(0x0301, "Multiplier", ZigbeeType.U24, r => r.ReadUInt24());
    public static ReportAttribute Divisor { get; } = zcl.Report(0x0302, "Divisor", ZigbeeType.U24, r => r.ReadUInt24());
    public static ReportAttribute SummationFormatting { get; } = zcl.Report(0x0303, "Summation Formatting", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute DemandFormatting { get; } = zcl.Report(0x0304, "Demand Formatting", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum MeteringDeviceTypeEnum
    {
        ElectricMetering = 0,
        GasMetering = 1,
        WaterMetering = 2,
        ThermalMetering = 3,
        PressureMetering = 4,
        HeatMetering = 5,
        CoolingMetering = 6,
        MirroredGasMetering = 128,
        MirroredWaterMetering = 129,
        MirroredThermalMetering = 130,
        MirroredPressureMetering = 131,
        MirroredHeatMetering = 132,
        MirroredCoolingMetering = 133,
    }

    public static ReportAttribute MeteringDeviceType { get; } = zcl.Report(0x0306, "Metering Device Type", ZigbeeType.Enum8, r => (MeteringDeviceTypeEnum)r.ReadByte());
    public static ReportAttribute MeterSerialNumber { get; } = zcl.Report(0x0308, "Meter Serial Number", ZigbeeType.Ostring, r => r.ReadString());
    #endregion 

    #region Develco specific
    #endregion 

    #region ESP Historical Consumption
    public static ReportAttribute InstantaneousDemand { get; } = zcl.Report(0x0400, "Instantaneous Demand", ZigbeeType.S24, r => r.ReadInt24());
    #endregion 

    #region Load Profile Configuration
    #endregion 

    #region Supply Limit
    #endregion 

    public static Task GetProfile(this ZigbeeNode node, byte intervalChannel, DateTime endTime, byte numberOfPeriods) => node.Zcl(zcl, 00, w => w+ intervalChannel+ endTime+ numberOfPeriods);
    public static Task RequestMirrorResponse(this ZigbeeNode node, ushort endPointID) => node.Zcl(zcl, 01, w => w+ endPointID);
    public static Task MirrorRemoved(this ZigbeeNode node, ushort removedEndPointID) => node.Zcl(zcl, 02, w => w+ removedEndPointID);

}
