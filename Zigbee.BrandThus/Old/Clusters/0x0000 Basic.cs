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
    public static ReportAttribute ZCLVersion { get; } = zcl.Report(0x0000, "ZCL Version", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ApplicationVersion { get; } = zcl.Report(0x0001, "Application Version", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute StackVersion { get; } = zcl.Report(0x0002, "Stack Version", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute HWVersion { get; } = zcl.Report(0x0003, "HW Version", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ManufacturerName { get; } = zcl.Report(0x0004, "Manufacturer Name", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute ModelIdentifier { get; } = zcl.Report(0x0005, "Model Identifier", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute DateCode { get; } = zcl.Report(0x0006, "Date Code", ZigbeeType.Cstring, r => r.ReadString());
    public enum PowerSourceEnum
    {
        Unknown = 0,
        MainssinglePhase = 1,
        Mains3Phase = 2,
        Battery = 3,
        DCSource = 4,
        EmergencyMainsConstantlyPowered = 5,
        EmergencyMainsAndTransferSwitch = 6,
        UnknownWithBatteryBackup = 0x80,
        MainssinglePhaseWithBatteryBackup = 0x81,
        Mains3PhaseWithBatteryBackup = 0x82,
        BatteryWithBatteryBackup = 0x83,
        DCSourceWithBatteryBackup = 0x84,
        EmergencyMainsConstantlyPoweredWithBatteryBackup = 0x85,
        EmergencyMainsAndTransferSwitchWithBatteryBackup = 0x86,
    }

    public static ReportAttribute PowerSource { get; } = zcl.Report(0x0007, "Power Source", ZigbeeType.Enum8, r => (PowerSourceEnum)r.ReadByte());
    public enum GenericDeviceClassEnum
    {
        Lighting = 0,
        Unspecified = 0xff,
    }

    /// <summary>
    /// IKEA control outlet specific.
    /// <summary>
    public static ReportAttribute GenericDeviceClass { get; } = zcl.Report(0x0008, "Generic Device Class", ZigbeeType.Enum8, r => (GenericDeviceClassEnum)r.ReadByte());
    public enum GenericDeviceTypeEnum
    {
        Incandescent = 0,
        SpotlightHalogen = 1,
        HalogenBulb = 2,
        CFL = 3,
        LinearFluorencent = 4,
        LEDBulb = 5,
        SpotlightLED = 6,
        LEDStrip = 7,
        LEDTube = 8,
        IndoorLuminaire = 9,
        OutdoorLuminaire = 0x0a,
        PendantLuminaire = 0x0b,
        FloorStandingLuminaire = 0x0c,
        Controller = 0xe0,
        WallSwitch = 0xe1,
        PortableRemoteController = 0xe2,
        MotionOrLightSensor = 0xe3,
        Actuator = 0xf0,
        WallSocket = 0xf1,
        GatewayOrBridge = 0xf2,
        PlugInUnit = 0xf3,
        RetrofitActuator = 0xf4,
        Unspecified = 0xff,
    }

    /// <summary>
    /// IKEA control outlet specific.
    /// <summary>
    public static ReportAttribute GenericDeviceType { get; } = zcl.Report(0x0009, "Generic Device Type", ZigbeeType.Enum8, r => (GenericDeviceTypeEnum)r.ReadByte());
    /// <summary>
    /// As printed on the product.
    /// <summary>
    public static ReportAttribute ProductCode { get; } = zcl.Report(0x000a, "Product code", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute ProductURL { get; } = zcl.Report(0x000b, "Product URL", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute ManufacturerVersionDetails { get; } = zcl.Report(0x000c, "Manufacturer Version Details", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SerialNumber { get; } = zcl.Report(0x000d, "Serial Number", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute ProductLabel { get; } = zcl.Report(0x000e, "Product Label", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SWBuildID { get; } = zcl.Report(0x4000, "SW Build ID", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute XiaomiSensitivity { get; } = zcl.Report(0xff0d, "Xiaomi Sensitivity", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Set to 0x12 (0xFE) to connect (disconnect) the left button to (from) the relay.
    /// <summary>
    public static ReportAttribute XiaomiDisconnect1 { get; } = zcl.Report(0xff22, "Xiaomi Disconnect 1", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Set to 0x22 (0xFE) to connect (disconnect) the left button to (from) the relay.
    /// <summary>
    public static ReportAttribute XiaomiDisconnect2 { get; } = zcl.Report(0xff23, "Xiaomi Disconnect 2", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute ClusterRevision { get; } = zcl.Report(0xfffd, "Cluster Revision", ZigbeeType.U16, r => r.ReadUInt16());
    public enum TuyaMagicSpellFinalAttributeEnum
    {
    }

    /// <summary>
    /// Read attributes in this order Manufacturer name,ZCL version,Application version,Model Identifier,Power source
    /// and finally this one"
    /// <summary>
    public static ReportAttribute TuyaMagicSpellFinalAttribute { get; } = zcl.Report(0xfffe, "Tuya magic spell final attribute", ZigbeeType.Enum8, r => (TuyaMagicSpellFinalAttributeEnum)r.ReadByte());
    #endregion 

    #region Basic Device Settings
    public static ReportAttribute LocationDescription { get; } = zcl.Report(0x0010, "Location Description", ZigbeeType.Cstring, r => r.ReadString());
    public enum PhysicalEnvironmentEnum
    {
        UnspecifiedEnvironment = 0x00,
        MirrorZSEProfile = 0x01,
        AtriumnonZSEProfile = 0x01,
        Bar = 0x02,
        Courtyard = 0x03,
        Bathroom = 0x04,
        Bedroom = 0x05,
        BilliardRoom = 0x06,
        UtilityRoom = 0x07,
        Cellar = 0x08,
        StorageCloset = 0x09,
        Theater = 0x0a,
        Office = 0x0b,
        Deck = 0x0c,
        Den = 0x0d,
        DiningRoom = 0x0e,
        ElectricalRoom = 0x0f,
        Elevator = 0x10,
        Entry = 0x11,
        FamilyRoom = 0x12,
        MainFloor = 0x13,
        Upstairs = 0x14,
        Downstairs = 0x15,
        BasementLowerLevel = 0x16,
        Gallery = 0x17,
        GameRoom = 0x18,
        Garage = 0x19,
        Gym = 0x1a,
        Hallway = 0x1b,
        House = 0x1c,
        Kitchen = 0x1d,
        LaundryRoom = 0x1e,
        Library = 0x1f,
        MasterBedroom = 0x20,
        MudRoomsmallRoomForCoatsAndBoots = 0x21,
        Nursery = 0x22,
        Pantry = 0x23,
        Office2 = 0x24,
        Outside = 0x25,
        Pool = 0x26,
        Porch = 0x27,
        SewingRoom = 0x28,
        SittingRoom = 0x29,
        Stairway = 0x2a,
        Yard = 0x2b,
        Attic = 0x2c,
        HotTub = 0x2d,
        LivingRoom = 0x2e,
        Sauna = 0x2f,
        ShopWorkshop = 0x30,
        GuestBedroom = 0x31,
        GuestBath = 0x32,
        PowderRoom12Bath = 0x33,
        BackYard = 0x34,
        FrontYard = 0x35,
        Patio = 0x36,
        Driveway = 0x37,
        SunRoom = 0x38,
        LivingRoom2 = 0x39,
        Spa = 0x3a,
        Whirlpool = 0x3b,
        Shed = 0x3c,
        EquipmentStorage = 0x3d,
        HobbyCraftRoom = 0x3e,
        Fountain = 0x3f,
        Pond = 0x40,
        ReceptionRoom = 0x41,
        BreakfastRoom = 0x42,
        Nook = 0x43,
        Garden = 0x44,
        Balcony = 0x45,
        PanicRoom = 0x46,
        Terrace = 0x47,
        Roof = 0x48,
        Toilet = 0x49,
        ToiletMain = 0x4a,
        OutsideToilet = 0x4b,
        ShowerRoom = 0x4c,
        Study = 0x4d,
        FrontGarden = 0x4e,
        BackGarden = 0x4f,
        Kettle = 0x50,
        Television = 0x51,
        Stove = 0x52,
        Microwave = 0x53,
        Toaster = 0x54,
        Vacuum = 0x55,
        Appliance = 0x56,
        FrontDoor = 0x57,
        BackDoor = 0x58,
        FridgeDoor = 0x59,
        MedicationCabinetDoor = 0x60,
        WardrobeDoor = 0x61,
        FrontCupboardDoor = 0x62,
        OtherDoor = 0x63,
        WaitingRoom = 0x64,
        TriageRoom = 0x65,
        DoctorsOffice = 0x66,
        PatientsPrivateRoom = 0x67,
        ConsultationRoom = 0x68,
        NurseStation = 0x69,
        Ward = 0x6a,
        Corridor = 0x6b,
        OperatingTheatre = 0x6c,
        DentalSurgeryRoom = 0x6d,
        MedicalImagingRoom = 0x6e,
        DecontaminationRoom = 0x6f,
        Atrium = 0x70,
        Mirror = 0x71,
        UnknownEnvironment = 0xff,
    }

    public static ReportAttribute PhysicalEnvironment { get; } = zcl.Report(0x0011, "Physical Environment", ZigbeeType.Enum8, r => (PhysicalEnvironmentEnum)r.ReadByte());
    public static ReportAttribute DeviceEnabled { get; } = zcl.Report(0x0012, "Device Enabled", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x0013, "Alarm Mask", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute DisableLocalConfig { get; } = zcl.Report(0x0014, "Disable Local Config", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Hue Specific
    public enum SensitivityEnum
    {
        Default = 0,
        High = 1,
        Max = 2,
    }

    public static ReportAttribute Sensitivity { get; } = zcl.Report(0x0030, "Sensitivity", ZigbeeType.Enum8, r => (SensitivityEnum)r.ReadByte());
    public static ReportAttribute Configuration { get; } = zcl.Report(0x0031, "Configuration", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute Usertest { get; } = zcl.Report(0x0032, "Usertest", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute LEDIndication { get; } = zcl.Report(0x0033, "LED Indication", ZigbeeType.Bool, r => r.ReadBool());
    public enum DeviceModeEnum
    {
        SingleRocker = 0,
        SinglePushButton = 1,
        DualRocker = 2,
        DualPushButton = 3,
    }

    public static ReportAttribute DeviceMode { get; } = zcl.Report(0x0034, "Device Mode", ZigbeeType.Enum8, r => (DeviceModeEnum)r.ReadByte());
    public static ReportAttribute ProductIdentifier { get; } = zcl.Report(0x0040, "Product Identifier", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SoftwareConfigIdentifier { get; } = zcl.Report(0x0041, "Software Config Identifier", ZigbeeType.U32, r => r.ReadUInt32());
    #endregion 

    #region Manufacturer specific
    public static ReportAttribute Manufacturer_128BitSecurityKey { get; } = zcl.Report(0x4001, "128-Bit security key", ZigbeeType.Seckey, r => r.ReadString());
    public static ReportAttribute ManufacturerIEEEAddress { get; } = zcl.Report(0x4002, "IEEE address", ZigbeeType.Uid, r => r.ReadInt64());
    #endregion 

    #region Manufacturer specific
    #endregion 

    #region Müller Licht specific
    public static ReportAttribute MullerLichtScene { get; } = zcl.Report(0x4005, "Scene", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region ID Lock specific
    public static ReportAttribute IDLockLockFw { get; } = zcl.Report(0x5000, "Lock fw", ZigbeeType.Cstring, r => r.ReadString());
    #endregion 

    #region Develco specific
    public static ReportAttribute DevelcoPrimarySWVersion { get; } = zcl.Report(0x8000, "Primary SW Version", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryBootloaderSWVersion { get; } = zcl.Report(0x8010, "Primary Bootloader SW Version", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryHWVersion { get; } = zcl.Report(0x8020, "Primary HW Version", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute DevelcoPrimaryHWName { get; } = zcl.Report(0x8030, "Primary HW name", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute DevelcoPrimarySWVersion3rdParty { get; } = zcl.Report(0x8050, "Primary SW Version 3rd Party", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute DevelcoLEDControl { get; } = zcl.Report(0x8100, "LED Control", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Schneider specific
    public static ReportAttribute SchneiderApplicationFWVersion { get; } = zcl.Report(0xe001, "Application FW Version", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SchneiderApplicationHWVersion { get; } = zcl.Report(0xe002, "Application HW Version", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SchneiderSerialNumber { get; } = zcl.Report(0xe004, "Serial Number", ZigbeeType.Cstring, r => r.ReadString());
    public enum SchneiderProductIndentifierEnum
    {
    }

    public static ReportAttribute SchneiderProductIndentifier { get; } = zcl.Report(0xe007, "Product Indentifier", ZigbeeType.Enum16, r => (SchneiderProductIndentifierEnum)r.ReadInt16());
    public static ReportAttribute SchneiderProductRange { get; } = zcl.Report(0xe008, "Product Range", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SchneiderProductModel { get; } = zcl.Report(0xe009, "Product Model", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SchneiderProductFamily { get; } = zcl.Report(0xe00a, "Product Family", ZigbeeType.Cstring, r => r.ReadString());
    public static ReportAttribute SchneiderVendorURL { get; } = zcl.Report(0xe00b, "Vendor URL", ZigbeeType.Cstring, r => r.ReadString());
    #endregion 

    #region Xiaomi specific
    public static ReportAttribute XiaomiXiaomiSensitivity { get; } = zcl.Report(0xFF0D, "Xiaomi Sensitivity", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Set to 0x12 (0xFE) to connect (disconnect) the left button to (from) the relay.
    /// <summary>
    public static ReportAttribute XiaomiXiaomiDisconnect1 { get; } = zcl.Report(0xFF22, "Xiaomi Disconnect 1", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Set to 0x22 (0xFE) to connect (disconnect) the left button to (from) the relay.
    /// <summary>
    public static ReportAttribute XiaomiXiaomiDisconnect2 { get; } = zcl.Report(0xFF23, "Xiaomi Disconnect 2", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Xiaomi specific
    #endregion 

    #region Tuya specific
    public static ReportAttribute TuyaReporting1 { get; } = zcl.Report(0xffde, "Reporting1", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    public static Task ResetToFactoryDefaults(this ZigbeeNode node) => node.Zcl(zcl, 00);
    public static Task HueCapabilities(this ZigbeeNode node, byte _0x00, uint offset, byte maxPacketSize) => node.Zcl(zcl, 0xc0, w => w+ _0x00+ offset+ maxPacketSize);

    public static Task HueCapabilitiesResponse(this ZigbeeNode node, ushort status, uint offset, uint totalPayloadLength, string payload) => node.Zcl(zcl, 0xc1, w => w+ status+ offset+ totalPayloadLength+ payload);
}
