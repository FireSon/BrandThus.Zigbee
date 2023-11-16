namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Thermostat control cluster attributes and commands.
/// <summary>
[Cluster(0x0201, "Thermostat")]
public static class ZclThermostat
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclThermostat));

    #region Thermostat Information
    public static ReportAttribute LocalTemperature { get; } = zcl.Report(0x0000, "Local Temperature", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute OutdoorTemperature { get; } = zcl.Report(0x0001, "Outdoor Temperature", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Occupancy { get; } = zcl.Report(0x0002, "Occupancy", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute AbsMinHeatSetpointLimit { get; } = zcl.Report(0x0003, "Abs Min Heat Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AbsMaxHeatSetpointLimit { get; } = zcl.Report(0x0004, "Abs Max Heat Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AbsMinCoolSetpointLimit { get; } = zcl.Report(0x0005, "Abs Min Cool Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AbsMaxCoolSetpointLimit { get; } = zcl.Report(0x0006, "Abs Max Cool Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute PICoolingDemand { get; } = zcl.Report(0x0007, "PI Cooling Demand", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute PIHeatingDemand { get; } = zcl.Report(0x0008, "PI Heating Demand", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute HVACSystemTypeConfiguration { get; } = zcl.Report(0x0009, "HVAC System Type Configuration", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Thermostat Settings
    public static ReportAttribute LocalTemperatureCalibration { get; } = zcl.Report(0x0010, "Local Temperature Calibration", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute OccupiedCoolingSetpoint { get; } = zcl.Report(0x0011, "Occupied Cooling Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute OccupiedHeatingSetpoint { get; } = zcl.Report(0x0012, "Occupied Heating Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute UnoccupiedCoolingSetpoint { get; } = zcl.Report(0x0013, "Unoccupied Cooling Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute UnoccupiedHeatingSetpoint { get; } = zcl.Report(0x0014, "Unoccupied Heating Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MinHeatSetpointLimit { get; } = zcl.Report(0x0015, "Min Heat Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MaxHeatSetpointLimit { get; } = zcl.Report(0x0016, "Max Heat Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MinCoolSetpointLimit { get; } = zcl.Report(0x0017, "Min Cool Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MaxCoolSetpointLimit { get; } = zcl.Report(0x0018, "Max Cool Setpoint Limit", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MinSetpointDeadBand { get; } = zcl.Report(0x0019, "Min Setpoint Dead Band", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute RemoteSensing { get; } = zcl.Report(0x001a, "Remote Sensing", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum ControlSequenceOfOperationEnum
    {
        CoolingOnly = 0,
        CoolingWithReheat = 1,
        HeatingOnly = 2,
        HeatingWithReheat = 3,
        CoolingAndHeating4pipes = 4,
        CoolingAndHeating4pipesWithReheat = 5,
    }

    public static ReportAttribute ControlSequenceOfOperation { get; } = zcl.Report(0x001b, "Control Sequence Of Operation", ZigbeeType.Enum8, r => (ControlSequenceOfOperationEnum)r.ReadByte());
    public enum SystemModeEnum
    {
        Off = 0x00,
        Auto = 0x01,
        Cool = 0x03,
        Heat = 0x04,
        EmergencyHeating = 0x05,
        Precooling = 0x06,
        FanOnly = 0x07,
        Dry = 0x08,
        Sleep = 0x09,
    }

    public static ReportAttribute SystemMode { get; } = zcl.Report(0x001c, "System Mode", ZigbeeType.Enum8, r => (SystemModeEnum)r.ReadByte());
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x001d, "Alarm Mask", ZigbeeType.Bmp8, r => r.ReadByte());
    public enum ThermostatRunningModeEnum
    {
        Off = 0,
        Cool = 3,
        Heat = 4,
    }

    public static ReportAttribute ThermostatRunningMode { get; } = zcl.Report(0x001e, "Thermostat Running Mode", ZigbeeType.Enum8, r => (ThermostatRunningModeEnum)r.ReadByte());
    #endregion 

    #region Thermostat Schedule and HVAC Relay
    public enum StartOfWeekEnum
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }

    public static ReportAttribute StartOfWeek { get; } = zcl.Report(0x0020, "Start of Week", ZigbeeType.Enum8, r => (StartOfWeekEnum)r.ReadByte());
    public static ReportAttribute NumberOfWeeklyTransitions { get; } = zcl.Report(0x0021, "Number of Weekly Transitions", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute NumberOfDailyTransitions { get; } = zcl.Report(0x0022, "Number of Daily Transitions", ZigbeeType.U8, r => r.ReadByte());
    public enum TemperatureSetpointHoldEnum
    {
        SetpointHoldOff = 0,
        SetpointHoldOn = 1,
    }

    public static ReportAttribute TemperatureSetpointHold { get; } = zcl.Report(0x0023, "Temperature Setpoint Hold", ZigbeeType.Enum8, r => (TemperatureSetpointHoldEnum)r.ReadByte());
    public static ReportAttribute TemperatureSetpointHoldDuration { get; } = zcl.Report(0x0024, "Temperature Setpoint Hold Duration", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ThermostatProgrammingOperationMode { get; } = zcl.Report(0x0025, "Thermostat Programming Operation Mode", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region HVAC Relay
    public static ReportAttribute ThermostatRunningState { get; } = zcl.Report(0x0029, "Thermostat Running State", ZigbeeType.Bmp16, r => r.ReadInt16());
    #endregion 

    #region Thermostat Setpoint Change Tracking
    public enum SetpointChangeSourceEnum
    {
        Manual = 0,
        Schedule = 1,
        Zigbee = 2,
    }

    public static ReportAttribute SetpointChangeSource { get; } = zcl.Report(0x0030, "Setpoint Change Source", ZigbeeType.Enum8, r => (SetpointChangeSourceEnum)r.ReadByte());
    public static ReportAttribute SetpointChangeAmount { get; } = zcl.Report(0x0031, "Setpoint Change Amount", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute SetpointChangeTimestamp { get; } = zcl.Report(0x0032, "Setpoint Change Timestamp", ZigbeeType.Utc, r => r.ReadDateTime());
    #endregion 

    #region AC Information
    public enum ACTypeEnum
    {
        CoolingAndFixedSpeed = 1,
        HeatPumpAndFixedSpeed = 2,
        CoolingAndInverter = 3,
        HeatPumpAndInverter = 4,
    }

    public static ReportAttribute ACType { get; } = zcl.Report(0x0040, "AC Type", ZigbeeType.Enum8, r => (ACTypeEnum)r.ReadByte());
    public static ReportAttribute ACCapacity { get; } = zcl.Report(0x0041, "AC Capacity", ZigbeeType.U16, r => r.ReadUInt16());
    public enum ACRefrigerantTypeEnum
    {
        R22 = 1,
        R410a = 2,
        R407c = 3,
    }

    public static ReportAttribute ACRefrigerantType { get; } = zcl.Report(0x0042, "AC Refrigerant Type", ZigbeeType.Enum8, r => (ACRefrigerantTypeEnum)r.ReadByte());
    public enum ACCompressorTypeEnum
    {
        T1MaxWorkingAmbient43OC = 1,
        T2MaxWorkingAmbient35OC = 2,
        T3MaxWorkingAmbient52OC = 3,
    }

    public static ReportAttribute ACCompressorType { get; } = zcl.Report(0x0043, "AC Compressor Type", ZigbeeType.Enum8, r => (ACCompressorTypeEnum)r.ReadByte());
    public static ReportAttribute ACErrorCode { get; } = zcl.Report(0x0044, "AC Error Code", ZigbeeType.Bmp32, r => r.ReadInt32());
    public enum ACLouverPositionEnum
    {
        FullyClosed = 1,
        FullyOpen = 2,
        QuarterOpen = 3,
        HalfOpen = 4,
        ThreeQuartersOpen = 5,
    }

    public static ReportAttribute ACLouverPosition { get; } = zcl.Report(0x0045, "AC Louver Position", ZigbeeType.Enum8, r => (ACLouverPositionEnum)r.ReadByte());
    public static ReportAttribute ACCoilTemperature { get; } = zcl.Report(0x0046, "AC Coil Temperature", ZigbeeType.S16, r => r.ReadInt16());
    public enum ACCapacityFormatEnum
    {
        BTUh = 0,
    }

    public static ReportAttribute ACCapacityFormat { get; } = zcl.Report(0x0047, "AC Capacity Format", ZigbeeType.Enum8, r => (ACCapacityFormatEnum)r.ReadByte());
    #endregion 

    #region eCozy
    #endregion 

    #region Sinope specific
    public enum SinopeOccupancyEnum
    {
        Unoccupied = 0x00,
        Occupied = 0x01,
    }

    public static ReportAttribute SinopeOccupancy { get; } = zcl.Report(0x0400, "Occupancy", ZigbeeType.Enum8, r => (SinopeOccupancyEnum)r.ReadByte());
    /// <summary>
    /// Number of second
    /// <summary>
    public static ReportAttribute SinopeMainCycleOutput { get; } = zcl.Report(0x0401, "Main Cycle Output", ZigbeeType.U16, r => r.ReadUInt16());
    public enum SinopeBacklightEnum
    {
        OnDemand = 0x00,
        AlwaysON = 0x01,
    }

    public static ReportAttribute SinopeBacklight { get; } = zcl.Report(0x0402, "Backlight", ZigbeeType.Enum8, r => (SinopeBacklightEnum)r.ReadByte());
    /// <summary>
    /// Number of second
    /// <summary>
    public static ReportAttribute SinopeAuxCycleOutput { get; } = zcl.Report(0x0404, "Aux Cycle Output", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region ELKO specific
    public enum ELKOTemperatureMeasurementEnum
    {
        AirSensor = 0x00,
        FloorSensor = 0x01,
        FloorProtection = 0x03,
    }

    public static ReportAttribute ELKOTemperatureMeasurement { get; } = zcl.Report(0x0403, "Temperature measurement", ZigbeeType.Enum8, r => (ELKOTemperatureMeasurementEnum)r.ReadByte());
    public static ReportAttribute ELKORegulatorMode { get; } = zcl.Report(0x0405, "Regulator mode", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ELKODeviceOn { get; } = zcl.Report(0x0406, "Device on", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ELKOFloorTemperatureSensor { get; } = zcl.Report(0x0409, "Floor temperature sensor", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ELKONightLowering { get; } = zcl.Report(0x0411, "Night lowering", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ELKOChildLock { get; } = zcl.Report(0x0413, "Child lock", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute ELKOHeatingActiveinactive { get; } = zcl.Report(0x0415, "Heating active/inactive", ZigbeeType.Bool, r => r.ReadBool());
    #endregion 

    #region Eurotronic
    public enum TRVModeEnum
    {
        Unknown1 = 0,
        Unknown2 = 1,
        Manual = 2,
    }

    public static ReportAttribute TRVMode { get; } = zcl.Report(0x4000, "TRV Mode", ZigbeeType.Enum8, r => (TRVModeEnum)r.ReadByte());
    public static ReportAttribute SetValvePosition { get; } = zcl.Report(0x4001, "Set Valve Position", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute Errors { get; } = zcl.Report(0x4002, "Errors", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentTemperatureSetpoint { get; } = zcl.Report(0x4003, "Current Temperature Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute HostFlags { get; } = zcl.Report(0x4008, "Host Flags", ZigbeeType.U24, r => r.ReadUInt24());
    #endregion 

    #region Danfoss specific
    public enum DanfossExerciseDayOfWeekEnum
    {
        Sunday = 0x00,
        Monday = 0x01,
        Tuesday = 0x02,
        Wednesday = 0x03,
        Thursday = 0x04,
        Friday = 0x05,
        Saturday = 0x06,
        Undefined = 0x07,
    }

    public static ReportAttribute DanfossExerciseDayOfWeek { get; } = zcl.Report(0x4010, "Exercise day of week", ZigbeeType.Enum8, r => (DanfossExerciseDayOfWeekEnum)r.ReadByte());
    public static ReportAttribute DanfossExerciseTriggerTime { get; } = zcl.Report(0x4011, "Exercise trigger time", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DanfossMountingModeActive { get; } = zcl.Report(0x4012, "Mounting mode active", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossMountingModeControl { get; } = zcl.Report(0x4013, "Mounting mode control", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfosseTRVOrientation { get; } = zcl.Report(0x4014, "eTRV Orientation", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossExternalMeasuredRoomSensor { get; } = zcl.Report(0x4015, "External Measured Room Sensor", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute DanfossRadiatorCovered { get; } = zcl.Report(0x4016, "Radiator Covered", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossControlAlgorithmScaleFactor { get; } = zcl.Report(0x4020, "Control Algorithm Scale Factor", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute DanfossHeatAvailable { get; } = zcl.Report(0x4030, "Heat Available", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossHeatSupplyRequest { get; } = zcl.Report(0x4031, "Heat Supply Request ", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossLoadBalancingEnabled { get; } = zcl.Report(0x4032, "Load Balancing Enabled", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossLoadRadiatorRoomMean { get; } = zcl.Report(0x4040, "Load Radiator Room Mean", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute DanfossLoadEstimateRadiator { get; } = zcl.Report(0x404A, "Load Estimate (Radiator)", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute DanfossRegulationSetPointOffset { get; } = zcl.Report(0x404B, "Regulation SetPoint Offset", ZigbeeType.S8, r => r.ReadByte());
    public enum DanfossAdaptationRunControlEnum
    {
        Idle = 0x00,
        InitiateAdaptationRun = 0x01,
        CancelAdaptationRun = 0x02,
    }

    public static ReportAttribute DanfossAdaptationRunControl { get; } = zcl.Report(0x404C, "Adaptation Run Control", ZigbeeType.Enum8, r => (DanfossAdaptationRunControlEnum)r.ReadByte());
    public static ReportAttribute DanfossAdaptationRunStatus { get; } = zcl.Report(0x404D, "Adaptation Run Status", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute DanfossAdaptationRunSettings { get; } = zcl.Report(0x404E, "Adaptation Run Settings", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute DanfossPreheatStatus { get; } = zcl.Report(0x404F, "Preheat Status", ZigbeeType.Bool, r => r.ReadBool());
    public static ReportAttribute DanfossPreheatTime { get; } = zcl.Report(0x4050, "Preheat Time", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute DanfossWindowOpenFeatureOn { get; } = zcl.Report(0x4051, "Window Open Feature On", ZigbeeType.Bool, r => r.ReadBool());
    #endregion 

    #region Stelpro specific
    public enum StelproSystemModeEnum
    {
        Off = 0x00,
        Heat = 0x04,
        Eco = 0x05,
    }

    /// <summary>
    /// States only supportedb by Stelpro thermostats (useless for Maestro).
    /// <summary>
    public static ReportAttribute StelproSystemMode { get; } = zcl.Report(0x401c, "System Mode", ZigbeeType.Enum8, r => (StelproSystemModeEnum)r.ReadByte());
    #endregion 

    #region Sunricher Specific Attributes
    public enum DisplayLEDBrightnessEnum
    {
        Low = 0x00,
        Medium = 0x01,
        High = 0x02,
    }

    /// <summary>
    /// OLED brightness when operating the buttons. Default: Medium.
    /// <summary>
    public static ReportAttribute DisplayLEDBrightness { get; } = zcl.Report(0x1000, "Display LED Brightness", ZigbeeType.Enum8, r => (DisplayLEDBrightnessEnum)r.ReadByte());
    public enum ButtonVibrationLevelEnum
    {
        Off = 0x0000,
        Low = 0x0001,
        High = 0x0002,
    }

    /// <summary>
    /// Key beep volume and vibration level. Default: Low.
    /// <summary>
    public static ReportAttribute ButtonVibrationLevel { get; } = zcl.Report(0x1001, "Button Vibration Level", ZigbeeType.Enum8, r => (ButtonVibrationLevelEnum)r.ReadByte());
    public enum FloorSensorTypeEnum
    {
        NTC10K25 = 0x01,
        NTC15K25 = 0x02,
        NTC50K25 = 0x03,
        NTC100K25 = 0x04,
        NTC12K25 = 0x05,
    }

    /// <summary>
    /// Type of the external floor sensor. Default: NTC 10K/25.
    /// <summary>
    public static ReportAttribute FloorSensorType { get; } = zcl.Report(0x1002, "Floor Sensor Type", ZigbeeType.Enum8, r => (FloorSensorTypeEnum)r.ReadByte());
    public enum ControlTypeEnum
    {
        RoomSensor = 0x00,
        FloorSensor = 0x01,
        RoomSensorFloorSensor = 0x02,
    }

    /// <summary>
    /// The sensor used for heat control. Default: Room Sensor.
    /// <summary>
    public static ReportAttribute ControlType { get; } = zcl.Report(0x1003, "Control Type", ZigbeeType.Enum8, r => (ControlTypeEnum)r.ReadByte());
    public enum PowerUpStatusEnum
    {
        DefaultMode = 0x00,
        PreviousMode = 0x01,
    }

    /// <summary>
    /// The mode after a power reset. Default: Previous Mode.
    /// <summary>
    public static ReportAttribute PowerUpStatus { get; } = zcl.Report(0x1004, "PowerUp Status", ZigbeeType.Enum8, r => (PowerUpStatusEnum)r.ReadByte());
    /// <summary>
    /// The tempearatue calibration for the exernal floor sensor, between -30 and 30 in 0.1°C. Default: 0.
    /// <summary>
    public static ReportAttribute FloorSensorCalibration { get; } = zcl.Report(0x1005, "Floor Sensor Calibration", ZigbeeType.S8, r => r.ReadByte());
    /// <summary>
    /// The duration of Dry Mode, between 5 and 100 minutes. Default: 5.
    /// <summary>
    public static ReportAttribute DryTime { get; } = zcl.Report(0x1006, "Dry Time", ZigbeeType.U8, r => r.ReadByte());
    public enum ModeAfterDryEnum
    {
        Off = 0x00,
        Manual = 0x01,
        Schedule = 0x02,
        Away = 0x03,
    }

    /// <summary>
    /// The mode after Dry Mode. Default: Schedule.
    /// <summary>
    public static ReportAttribute ModeAfterDry { get; } = zcl.Report(0x1007, "Mode After Dry", ZigbeeType.Enum8, r => (ModeAfterDryEnum)r.ReadByte());
    public enum TemperatureDisplayEnum
    {
        RoomTemperature = 0x00,
        FloorTemperature = 0x01,
    }

    /// <summary>
    /// The temperature on the display. Default: Room Temperature.
    /// <summary>
    public static ReportAttribute TemperatureDisplay { get; } = zcl.Report(0x1008, "Temperature Display", ZigbeeType.Enum8, r => (TemperatureDisplayEnum)r.ReadByte());
    /// <summary>
    /// The threshold to detect window open, between 3 and 8 in 0.5 °C. Default: 0 (disabled).
    /// <summary>
    public static ReportAttribute WindowOpenDetection { get; } = zcl.Report(0x1009, "Window Open Detection", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Hysteresis setting, between 5 and 20 in 0.1 °C. Default: 5.
    /// <summary>
    public static ReportAttribute Hysteresis { get; } = zcl.Report(0x100A, "Hysteresis", ZigbeeType.U8, r => r.ReadByte());
    /// <summary>
    /// Room temperature alarm threshold, between 20 and 60 in °C. 0 means disabled. Default: 45.
    /// <summary>
    public static ReportAttribute AlarmAirTemperature { get; } = zcl.Report(0x2001, "Alarm Air Temperature", ZigbeeType.U8, r => r.ReadByte());
    public enum AwayModeEnum
    {
        Home = 0x00,
        Away = 0x01,
    }

    /// <summary>
    /// Set Away Mode. Default: Home.
    /// <summary>
    public static ReportAttribute AwayMode { get; } = zcl.Report(0x2002, "Away Mode", ZigbeeType.Enum8, r => (AwayModeEnum)r.ReadByte());
    #endregion 

    #region Danfoss specific
    public enum DanfossRoomStatusCodeEnum
    {
        NoError = 0x0000,
        MissingRT = 0x0101,
        RTTouchError = 0x0201,
        FloorSensorShortCircuit = 0x0401,
        FloorSensorDisconnected = 0x0801,
    }

    public static ReportAttribute DanfossRoomStatusCode { get; } = zcl.Report(0x4100, "Room Status Code", ZigbeeType.Enum16, r => (DanfossRoomStatusCodeEnum)r.ReadInt16());
    public enum DanfossOutputStatusEnum
    {
        Inactive = 0x00,
        Active = 0x01,
    }

    public static ReportAttribute DanfossOutputStatus { get; } = zcl.Report(0x4110, "Output Status", ZigbeeType.Enum8, r => (DanfossOutputStatusEnum)r.ReadByte());
    public enum DanfossRoomFloorSensorModeEnum
    {
        ComfortMode = 0x00,
        FloorSensorMode = 0x01,
        DualMode = 0x02,
    }

    public static ReportAttribute DanfossRoomFloorSensorMode { get; } = zcl.Report(0x4120, "Room Floor Sensor Mode", ZigbeeType.Enum8, r => (DanfossRoomFloorSensorModeEnum)r.ReadByte());
    public static ReportAttribute DanfossFloorMinimumSetpoint { get; } = zcl.Report(0x4121, "Floor Minimum Setpoint", ZigbeeType.S16, r => r.ReadInt16());
    public enum DanfossScheduleTypeUsedEnum
    {
        RegularSchedule = 0x00,
        VacationSchedule = 0x01,
    }

    public static ReportAttribute DanfossScheduleTypeUsed { get; } = zcl.Report(0x4130, "Schedule Type Used", ZigbeeType.Enum8, r => (DanfossScheduleTypeUsedEnum)r.ReadByte());
    #endregion 

    #region Bosch specific
    public enum BoschOperatingModeEnum
    {
        Schedule = 0x00,
        Manual = 0x01,
        Off = 0x05,
    }

    public static ReportAttribute BoschOperatingMode { get; } = zcl.Report(0x4007, "Operating Mode", ZigbeeType.Enum8, r => (BoschOperatingModeEnum)r.ReadByte());
    public enum BoschExternalWindowOpenDetectionEnum
    {
        Closed = 0x00,
        Open = 0x01,
    }

    public static ReportAttribute BoschExternalWindowOpenDetection { get; } = zcl.Report(0x4042, "External Window Open Detection", ZigbeeType.Enum8, r => (BoschExternalWindowOpenDetectionEnum)r.ReadByte());
    public enum BoschBoostEnum
    {
        Off = 0x00,
        On = 0x01,
    }

    public static ReportAttribute BoschBoost { get; } = zcl.Report(0x4043, "Boost", ZigbeeType.Enum8, r => (BoschBoostEnum)r.ReadByte());
    public static ReportAttribute BoschErrorCode { get; } = zcl.Report(0x5000, "Error Code", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    /// <summary>
    /// This command increases (or decreases) the setpoint(s) by amount, in steps of 0.1°C.
    /// <summary>
    public static Task SetpointRaiseLower(this ZigbeeNode node, byte mode, byte amount) => node.Zcl(zcl, 0x00, w => w+ mode+ amount);
    public static Task SetWeeklySchedule(this ZigbeeNode node, byte numberOfTranstionsForSequence, byte dayOfWeekForSequence, byte modeForSequence, ushort transitionTime1, short heatSetPoint1, ushort transitionTime2, short heatSetPoint2, ushort transitionTime3, short heatSetPoint3, ushort transitionTime4, short heatSetPoint4, ushort transitionTime5, short heatSetPoint5, ushort transitionTime6, short heatSetPoint6, ushort transitionTime7, short heatSetPoint7, ushort transitionTime8, short heatSetPoint8, ushort transitionTime9, short heatSetPoint9, ushort transitionTime10, short heatSetPoint10) => node.Zcl(zcl, 0x01, w => w+ numberOfTranstionsForSequence+ dayOfWeekForSequence+ modeForSequence+ transitionTime1+ heatSetPoint1+ transitionTime2+ heatSetPoint2+ transitionTime3+ heatSetPoint3+ transitionTime4+ heatSetPoint4+ transitionTime5+ heatSetPoint5+ transitionTime6+ heatSetPoint6+ transitionTime7+ heatSetPoint7+ transitionTime8+ heatSetPoint8+ transitionTime9+ heatSetPoint9+ transitionTime10+ heatSetPoint10);
    public static Task GetWeeklySchedule(this ZigbeeNode node, byte daysToReturn, byte modeToReturn) => node.Zcl(zcl, 0x02, w => w+ daysToReturn+ modeToReturn);
    public static Task ClearWeeklySchedule(this ZigbeeNode node) => node.Zcl(zcl, 0x03);
    public static Task GetRelayStatusLog(this ZigbeeNode node) => node.Zcl(zcl, 0x04);

    public static Task GetWeeklyScheduleResponse(this ZigbeeNode node, byte numberOfTranstionsForSequence, byte dayOfWeekForSequence, byte modeForSequence, ushort transitionTime1, short heatSetPoint1, ushort transitionTime2, short heatSetPoint2, ushort transitionTime3, short heatSetPoint3, ushort transitionTime4, short heatSetPoint4, ushort transitionTime5, short heatSetPoint5, ushort transitionTime6, short heatSetPoint6, ushort transitionTime7, short heatSetPoint7, ushort transitionTime8, short heatSetPoint8, ushort transitionTime9, short heatSetPoint9, ushort transitionTime10, short heatSetPoint10) => node.Zcl(zcl, 0x00, w => w+ numberOfTranstionsForSequence+ dayOfWeekForSequence+ modeForSequence+ transitionTime1+ heatSetPoint1+ transitionTime2+ heatSetPoint2+ transitionTime3+ heatSetPoint3+ transitionTime4+ heatSetPoint4+ transitionTime5+ heatSetPoint5+ transitionTime6+ heatSetPoint6+ transitionTime7+ heatSetPoint7+ transitionTime8+ heatSetPoint8+ transitionTime9+ heatSetPoint9+ transitionTime10+ heatSetPoint10);
}
