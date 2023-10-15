namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes for determining basic information about a device, setting user device information such as description
/// of location, and enabling a device.
/// <summary>
[Cluster(0x0000, "Basic")]
public static class ZclBasic
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclBasic));

    #region Basic Device Information
    public static ReportAttribute ZCLVersion { get; } = zcl.Report(0x0000, "ZCL Version", r => r.ReadByte());
    public static ReportAttribute ApplicationVersion { get; } = zcl.Report(0x0001, "Application Version", r => r.ReadByte());
    public static ReportAttribute StackVersion { get; } = zcl.Report(0x0002, "Stack Version", r => r.ReadByte());
    public static ReportAttribute HWVersion { get; } = zcl.Report(0x0003, "HW Version", r => r.ReadByte());
    public static ReportAttribute ManufacturerName { get; } = zcl.Report(0x0004, "Manufacturer Name", r => r.ReadString());
    public static ReportAttribute ModelIdentifier { get; } = zcl.Report(0x0005, "Model Identifier", r => r.ReadString());
    public static ReportAttribute DateCode { get; } = zcl.Report(0x0006, "Date Code", r => r.ReadString());
    public static ReportAttribute PowerSource { get; } = zcl.Report(0x0007, "Power Source", r => r.ReadByte());
    public static ReportAttribute GenericDeviceClass { get; } = zcl.Report(0x0008, "Generic Device Class", r => r.ReadByte());
    public static ReportAttribute GenericDeviceType { get; } = zcl.Report(0x0009, "Generic Device Type", r => r.ReadByte());
    public static ReportAttribute ProductCode { get; } = zcl.Report(0x000a, "Product code", r => r.ReadString());
    public static ReportAttribute ProductURL { get; } = zcl.Report(0x000b, "Product URL", r => r.ReadString());
    public static ReportAttribute ManufacturerVersionDetails { get; } = zcl.Report(0x000c, "Manufacturer Version Details", r => r.ReadString());
    public static ReportAttribute SerialNumber { get; } = zcl.Report(0x000d, "Serial Number", r => r.ReadString());
    public static ReportAttribute ProductLabel { get; } = zcl.Report(0x000e, "Product Label", r => r.ReadString());
    public static ReportAttribute SWBuildID { get; } = zcl.Report(0x4000, "SW Build ID", r => r.ReadString());
    public static ReportAttribute XiaomiSensitivity { get; } = zcl.Report(0xff0d, "Xiaomi Sensitivity", r => r.ReadByte());
    public static ReportAttribute XiaomiDisconnect1 { get; } = zcl.Report(0xff22, "Xiaomi Disconnect 1", r => r.ReadByte());
    public static ReportAttribute XiaomiDisconnect2 { get; } = zcl.Report(0xff23, "Xiaomi Disconnect 2", r => r.ReadByte());
    public static ReportAttribute ClusterRevision { get; } = zcl.Report(0xfffd, "Cluster Revision", r => r.ReadUInt16());
    public static ReportAttribute TuyaMagicSpellFinalAttribute { get; } = zcl.Report(0xfffe, "Tuya magic spell final attribute", r => r.ReadByte());
    #endregion 

    #region Basic Device Settings
    public static ReportAttribute LocationDescription { get; } = zcl.Report(0x0010, "Location Description", r => r.ReadString());
    public static ReportAttribute PhysicalEnvironment { get; } = zcl.Report(0x0011, "Physical Environment", r => r.ReadByte());
    public static ReportAttribute DeviceEnabled { get; } = zcl.Report(0x0012, "Device Enabled", r => r.ReadBool());
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x0013, "Alarm Mask", r => r.ReadByte());
    public static ReportAttribute DisableLocalConfig { get; } = zcl.Report(0x0014, "Disable Local Config", r => r.ReadByte());
    #endregion 

    #region Hue Specific
    public static ReportAttribute Sensitivity { get; } = zcl.Report(0x0030, "Sensitivity", r => r.ReadByte());
    public static ReportAttribute Configuration { get; } = zcl.Report(0x0031, "Configuration", r => r.ReadInt16());
    public static ReportAttribute Usertest { get; } = zcl.Report(0x0032, "Usertest", r => r.ReadBool());
    public static ReportAttribute LEDIndication { get; } = zcl.Report(0x0033, "LED Indication", r => r.ReadBool());
    public static ReportAttribute DeviceMode { get; } = zcl.Report(0x0034, "Device Mode", r => r.ReadByte());
    public static ReportAttribute ProductIdentifier { get; } = zcl.Report(0x0040, "Product Identifier", r => r.ReadString());
    public static ReportAttribute SoftwareConfigIdentifier { get; } = zcl.Report(0x0041, "Software Config Identifier", r => r.ReadUInt32());
    #endregion 

    #region Manufacturer specific
    public static ReportAttribute Manufacturer_128BitSecurityKey { get; } = zcl.Report(0x4001, "128-Bit security key", r => r.ReadString());
    public static ReportAttribute ManufacturerIEEEAddress { get; } = zcl.Report(0x4002, "IEEE address", r => r.ReadInt64());
    #endregion 

    #region Manufacturer specific
    #endregion 

    #region Müller Licht specific
    public static ReportAttribute MullerLichtScene { get; } = zcl.Report(0x4005, "Scene", r => r.ReadByte());
    #endregion 

    #region ID Lock specific
    public static ReportAttribute IDLockLockFw { get; } = zcl.Report(0x5000, "Lock fw", r => r.ReadString());
    #endregion 

    #region Develco specific
    public static ReportAttribute DevelcoPrimarySWVersion { get; } = zcl.Report(0x8000, "Primary SW Version", r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryBootloaderSWVersion { get; } = zcl.Report(0x8010, "Primary Bootloader SW Version", r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryHWVersion { get; } = zcl.Report(0x8020, "Primary HW Version", r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryHWName { get; } = zcl.Report(0x8030, "Primary HW name", r => r.ReadString());
    public static ReportAttribute DevelcoPrimarySWVersion3rdParty { get; } = zcl.Report(0x8050, "Primary SW Version 3rd Party", r => r.ReadString());
    public static ReportAttribute DevelcoLEDControl { get; } = zcl.Report(0x8100, "LED Control", r => r.ReadByte());
    #endregion 

    #region Schneider specific
    public static ReportAttribute SchneiderApplicationFWVersion { get; } = zcl.Report(0xe001, "Application FW Version", r => r.ReadString());
    public static ReportAttribute SchneiderApplicationHWVersion { get; } = zcl.Report(0xe002, "Application HW Version", r => r.ReadString());
    public static ReportAttribute SchneiderSerialNumber { get; } = zcl.Report(0xe004, "Serial Number", r => r.ReadString());
    public static ReportAttribute SchneiderProductIndentifier { get; } = zcl.Report(0xe007, "Product Indentifier", r => r.ReadInt16());
    public static ReportAttribute SchneiderProductRange { get; } = zcl.Report(0xe008, "Product Range", r => r.ReadString());
    public static ReportAttribute SchneiderProductModel { get; } = zcl.Report(0xe009, "Product Model", r => r.ReadString());
    public static ReportAttribute SchneiderProductFamily { get; } = zcl.Report(0xe00a, "Product Family", r => r.ReadString());
    public static ReportAttribute SchneiderVendorURL { get; } = zcl.Report(0xe00b, "Vendor URL", r => r.ReadString());
    #endregion 

    #region Xiaomi specific
    public static ReportAttribute XiaomiXiaomiSensitivity { get; } = zcl.Report(0xFF0D, "Xiaomi Sensitivity", r => r.ReadByte());
    public static ReportAttribute XiaomiXiaomiDisconnect1 { get; } = zcl.Report(0xFF22, "Xiaomi Disconnect 1", r => r.ReadByte());
    public static ReportAttribute XiaomiXiaomiDisconnect2 { get; } = zcl.Report(0xFF23, "Xiaomi Disconnect 2", r => r.ReadByte());
    #endregion 

    #region Xiaomi specific
    #endregion 

    #region Tuya specific
    public static ReportAttribute TuyaReporting1 { get; } = zcl.Report(0xffde, "Reporting1", r => r.ReadByte());
    #endregion 

    public static Task ResetToFactoryDefaults => Task.CompletedTask;
    public static Task HueCapabilities => Task.CompletedTask;

    public static Task HueCapabilitiesResponse => Task.CompletedTask;
}
