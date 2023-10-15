namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Thermostat control cluster attributes and commands.
/// <summary>
[Cluster(0x0201, "Thermostat")]
public static class ZclThermostat
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclThermostat));

    #region Thermostat Information
    public static ReportAttribute LocalTemperature { get; } = zcl.Report(0x0000, "Local Temperature", r => r.ReadInt16());
    public static ReportAttribute OutdoorTemperature { get; } = zcl.Report(0x0001, "Outdoor Temperature", r => r.ReadInt16());
    public static ReportAttribute Occupancy { get; } = zcl.Report(0x0002, "Occupancy", r => r.ReadByte());
    public static ReportAttribute AbsMinHeatSetpointLimit { get; } = zcl.Report(0x0003, "Abs Min Heat Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute AbsMaxHeatSetpointLimit { get; } = zcl.Report(0x0004, "Abs Max Heat Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute AbsMinCoolSetpointLimit { get; } = zcl.Report(0x0005, "Abs Min Cool Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute AbsMaxCoolSetpointLimit { get; } = zcl.Report(0x0006, "Abs Max Cool Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute PICoolingDemand { get; } = zcl.Report(0x0007, "PI Cooling Demand", r => r.ReadByte());
    public static ReportAttribute PIHeatingDemand { get; } = zcl.Report(0x0008, "PI Heating Demand", r => r.ReadByte());
    public static ReportAttribute HVACSystemTypeConfiguration { get; } = zcl.Report(0x0009, "HVAC System Type Configuration", r => r.ReadByte());
    #endregion 

    #region Thermostat Settings
    public static ReportAttribute LocalTemperatureCalibration { get; } = zcl.Report(0x0010, "Local Temperature Calibration", r => r.ReadByte());
    public static ReportAttribute OccupiedCoolingSetpoint { get; } = zcl.Report(0x0011, "Occupied Cooling Setpoint", r => r.ReadInt16());
    public static ReportAttribute OccupiedHeatingSetpoint { get; } = zcl.Report(0x0012, "Occupied Heating Setpoint", r => r.ReadInt16());
    public static ReportAttribute UnoccupiedCoolingSetpoint { get; } = zcl.Report(0x0013, "Unoccupied Cooling Setpoint", r => r.ReadInt16());
    public static ReportAttribute UnoccupiedHeatingSetpoint { get; } = zcl.Report(0x0014, "Unoccupied Heating Setpoint", r => r.ReadInt16());
    public static ReportAttribute MinHeatSetpointLimit { get; } = zcl.Report(0x0015, "Min Heat Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute MaxHeatSetpointLimit { get; } = zcl.Report(0x0016, "Max Heat Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute MinCoolSetpointLimit { get; } = zcl.Report(0x0017, "Min Cool Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute MaxCoolSetpointLimit { get; } = zcl.Report(0x0018, "Max Cool Setpoint Limit", r => r.ReadInt16());
    public static ReportAttribute MinSetpointDeadBand { get; } = zcl.Report(0x0019, "Min Setpoint Dead Band", r => r.ReadByte());
    public static ReportAttribute RemoteSensing { get; } = zcl.Report(0x001a, "Remote Sensing", r => r.ReadByte());
    public static ReportAttribute ControlSequenceOfOperation { get; } = zcl.Report(0x001b, "Control Sequence Of Operation", r => r.ReadByte());
    public static ReportAttribute SystemMode { get; } = zcl.Report(0x001c, "System Mode", r => r.ReadByte());
    public static ReportAttribute AlarmMask { get; } = zcl.Report(0x001d, "Alarm Mask", r => r.ReadByte());
    public static ReportAttribute ThermostatRunningMode { get; } = zcl.Report(0x001e, "Thermostat Running Mode", r => r.ReadByte());
    #endregion 

    #region Thermostat Schedule and HVAC Relay
    public static ReportAttribute StartOfWeek { get; } = zcl.Report(0x0020, "Start of Week", r => r.ReadByte());
    public static ReportAttribute NumberOfWeeklyTransitions { get; } = zcl.Report(0x0021, "Number of Weekly Transitions", r => r.ReadByte());
    public static ReportAttribute NumberOfDailyTransitions { get; } = zcl.Report(0x0022, "Number of Daily Transitions", r => r.ReadByte());
    public static ReportAttribute TemperatureSetpointHold { get; } = zcl.Report(0x0023, "Temperature Setpoint Hold", r => r.ReadByte());
    public static ReportAttribute TemperatureSetpointHoldDuration { get; } = zcl.Report(0x0024, "Temperature Setpoint Hold Duration", r => r.ReadUInt16());
    public static ReportAttribute ThermostatProgrammingOperationMode { get; } = zcl.Report(0x0025, "Thermostat Programming Operation Mode", r => r.ReadByte());
    #endregion 

    #region HVAC Relay
    public static ReportAttribute ThermostatRunningState { get; } = zcl.Report(0x0029, "Thermostat Running State", r => r.ReadInt16());
    #endregion 

    #region Thermostat Setpoint Change Tracking
    public static ReportAttribute SetpointChangeSource { get; } = zcl.Report(0x0030, "Setpoint Change Source", r => r.ReadByte());
    public static ReportAttribute SetpointChangeAmount { get; } = zcl.Report(0x0031, "Setpoint Change Amount", r => r.ReadInt16());
    public static ReportAttribute SetpointChangeTimestamp { get; } = zcl.Report(0x0032, "Setpoint Change Timestamp", r => r.ReadDateTime());
    #endregion 

    #region AC Information
    public static ReportAttribute ACType { get; } = zcl.Report(0x0040, "AC Type", r => r.ReadByte());
    public static ReportAttribute ACCapacity { get; } = zcl.Report(0x0041, "AC Capacity", r => r.ReadUInt16());
    public static ReportAttribute ACRefrigerantType { get; } = zcl.Report(0x0042, "AC Refrigerant Type", r => r.ReadByte());
    public static ReportAttribute ACCompressorType { get; } = zcl.Report(0x0043, "AC Compressor Type", r => r.ReadByte());
    public static ReportAttribute ACErrorCode { get; } = zcl.Report(0x0044, "AC Error Code", r => r.ReadInt32());
    public static ReportAttribute ACLouverPosition { get; } = zcl.Report(0x0045, "AC Louver Position", r => r.ReadByte());
    public static ReportAttribute ACCoilTemperature { get; } = zcl.Report(0x0046, "AC Coil Temperature", r => r.ReadInt16());
    public static ReportAttribute ACCapacityFormat { get; } = zcl.Report(0x0047, "AC Capacity Format", r => r.ReadByte());
    #endregion 

    #region eCozy
    #endregion 

    #region Sinope specific
    public static ReportAttribute SinopeOccupancy { get; } = zcl.Report(0x0400, "Occupancy", r => r.ReadByte());
    public static ReportAttribute SinopeMainCycleOutput { get; } = zcl.Report(0x0401, "Main Cycle Output", r => r.ReadUInt16());
    public static ReportAttribute SinopeBacklight { get; } = zcl.Report(0x0402, "Backlight", r => r.ReadByte());
    public static ReportAttribute SinopeAuxCycleOutput { get; } = zcl.Report(0x0404, "Aux Cycle Output", r => r.ReadUInt16());
    #endregion 

    #region ELKO specific
    public static ReportAttribute ELKOTemperatureMeasurement { get; } = zcl.Report(0x0403, "Temperature measurement", r => r.ReadByte());
    public static ReportAttribute ELKORegulatorMode { get; } = zcl.Report(0x0405, "Regulator mode", r => r.ReadBool());
    public static ReportAttribute ELKODeviceOn { get; } = zcl.Report(0x0406, "Device on", r => r.ReadBool());
    public static ReportAttribute ELKOFloorTemperatureSensor { get; } = zcl.Report(0x0409, "Floor temperature sensor", r => r.ReadInt16());
    public static ReportAttribute ELKONightLowering { get; } = zcl.Report(0x0411, "Night lowering", r => r.ReadBool());
    public static ReportAttribute ELKOChildLock { get; } = zcl.Report(0x0413, "Child lock", r => r.ReadBool());
    public static ReportAttribute ELKOHeatingActiveinactive { get; } = zcl.Report(0x0415, "Heating active/inactive", r => r.ReadBool());
    #endregion 

    #region Eurotronic
    public static ReportAttribute TRVMode { get; } = zcl.Report(0x4000, "TRV Mode", r => r.ReadByte());
    public static ReportAttribute SetValvePosition { get; } = zcl.Report(0x4001, "Set Valve Position", r => r.ReadByte());
    public static ReportAttribute Errors { get; } = zcl.Report(0x4002, "Errors", r => r.ReadByte());
    public static ReportAttribute CurrentTemperatureSetpoint { get; } = zcl.Report(0x4003, "Current Temperature Setpoint", r => r.ReadInt16());
    public static ReportAttribute HostFlags { get; } = zcl.Report(0x4008, "Host Flags", r => r.ReadUInt24());
    #endregion 

    #region Danfoss specific
    public static ReportAttribute DanfossExerciseDayOfWeek { get; } = zcl.Report(0x4010, "Exercise day of week", r => r.ReadByte());
    public static ReportAttribute DanfossExerciseTriggerTime { get; } = zcl.Report(0x4011, "Exercise trigger time", r => r.ReadUInt16());
    public static ReportAttribute DanfossMountingModeActive { get; } = zcl.Report(0x4012, "Mounting mode active", r => r.ReadBool());
    public static ReportAttribute DanfossMountingModeControl { get; } = zcl.Report(0x4013, "Mounting mode control", r => r.ReadBool());
    public static ReportAttribute DanfosseTRVOrientation { get; } = zcl.Report(0x4014, "eTRV Orientation", r => r.ReadBool());
    public static ReportAttribute DanfossExternalMeasuredRoomSensor { get; } = zcl.Report(0x4015, "External Measured Room Sensor", r => r.ReadInt16());
    public static ReportAttribute DanfossRadiatorCovered { get; } = zcl.Report(0x4016, "Radiator Covered", r => r.ReadBool());
    public static ReportAttribute DanfossControlAlgorithmScaleFactor { get; } = zcl.Report(0x4020, "Control Algorithm Scale Factor", r => r.ReadByte());
    public static ReportAttribute DanfossHeatAvailable { get; } = zcl.Report(0x4030, "Heat Available", r => r.ReadBool());
    public static ReportAttribute DanfossHeatSupplyRequest { get; } = zcl.Report(0x4031, "Heat Supply Request ", r => r.ReadBool());
    public static ReportAttribute DanfossLoadBalancingEnabled { get; } = zcl.Report(0x4032, "Load Balancing Enabled", r => r.ReadBool());
    public static ReportAttribute DanfossLoadRadiatorRoomMean { get; } = zcl.Report(0x4040, "Load Radiator Room Mean", r => r.ReadInt16());
    public static ReportAttribute DanfossLoadEstimateRadiator { get; } = zcl.Report(0x404A, "Load Estimate (Radiator)", r => r.ReadInt16());
    public static ReportAttribute DanfossRegulationSetPointOffset { get; } = zcl.Report(0x404B, "Regulation SetPoint Offset", r => r.ReadByte());
    public static ReportAttribute DanfossAdaptationRunControl { get; } = zcl.Report(0x404C, "Adaptation Run Control", r => r.ReadByte());
    public static ReportAttribute DanfossAdaptationRunStatus { get; } = zcl.Report(0x404D, "Adaptation Run Status", r => r.ReadByte());
    public static ReportAttribute DanfossAdaptationRunSettings { get; } = zcl.Report(0x404E, "Adaptation Run Settings", r => r.ReadByte());
    public static ReportAttribute DanfossPreheatStatus { get; } = zcl.Report(0x404F, "Preheat Status", r => r.ReadBool());
    public static ReportAttribute DanfossPreheatTime { get; } = zcl.Report(0x4050, "Preheat Time", r => r.ReadUInt32());
    public static ReportAttribute DanfossWindowOpenFeatureOn { get; } = zcl.Report(0x4051, "Window Open Feature On", r => r.ReadBool());
    #endregion 

    #region Stelpro specific
    public static ReportAttribute StelproSystemMode { get; } = zcl.Report(0x401c, "System Mode", r => r.ReadByte());
    #endregion 

    #region Sunricher Specific Attributes
    public static ReportAttribute DisplayLEDBrightness { get; } = zcl.Report(0x1000, "Display LED Brightness", r => r.ReadByte());
    public static ReportAttribute ButtonVibrationLevel { get; } = zcl.Report(0x1001, "Button Vibration Level", r => r.ReadByte());
    public static ReportAttribute FloorSensorType { get; } = zcl.Report(0x1002, "Floor Sensor Type", r => r.ReadByte());
    public static ReportAttribute ControlType { get; } = zcl.Report(0x1003, "Control Type", r => r.ReadByte());
    public static ReportAttribute PowerUpStatus { get; } = zcl.Report(0x1004, "PowerUp Status", r => r.ReadByte());
    public static ReportAttribute FloorSensorCalibration { get; } = zcl.Report(0x1005, "Floor Sensor Calibration", r => r.ReadByte());
    public static ReportAttribute DryTime { get; } = zcl.Report(0x1006, "Dry Time", r => r.ReadByte());
    public static ReportAttribute ModeAfterDry { get; } = zcl.Report(0x1007, "Mode After Dry", r => r.ReadByte());
    public static ReportAttribute TemperatureDisplay { get; } = zcl.Report(0x1008, "Temperature Display", r => r.ReadByte());
    public static ReportAttribute WindowOpenDetection { get; } = zcl.Report(0x1009, "Window Open Detection", r => r.ReadByte());
    public static ReportAttribute Hysteresis { get; } = zcl.Report(0x100A, "Hysteresis", r => r.ReadByte());
    public static ReportAttribute AlarmAirTemperature { get; } = zcl.Report(0x2001, "Alarm Air Temperature", r => r.ReadByte());
    public static ReportAttribute AwayMode { get; } = zcl.Report(0x2002, "Away Mode", r => r.ReadByte());
    #endregion 

    #region Danfoss specific
    public static ReportAttribute DanfossRoomStatusCode { get; } = zcl.Report(0x4100, "Room Status Code", r => r.ReadInt16());
    public static ReportAttribute DanfossOutputStatus { get; } = zcl.Report(0x4110, "Output Status", r => r.ReadByte());
    public static ReportAttribute DanfossRoomFloorSensorMode { get; } = zcl.Report(0x4120, "Room Floor Sensor Mode", r => r.ReadByte());
    public static ReportAttribute DanfossFloorMinimumSetpoint { get; } = zcl.Report(0x4121, "Floor Minimum Setpoint", r => r.ReadInt16());
    public static ReportAttribute DanfossScheduleTypeUsed { get; } = zcl.Report(0x4130, "Schedule Type Used", r => r.ReadByte());
    #endregion 

    #region Bosch specific
    public static ReportAttribute BoschOperatingMode { get; } = zcl.Report(0x4007, "Operating Mode", r => r.ReadByte());
    public static ReportAttribute BoschExternalWindowOpenDetection { get; } = zcl.Report(0x4042, "External Window Open Detection", r => r.ReadByte());
    public static ReportAttribute BoschBoost { get; } = zcl.Report(0x4043, "Boost", r => r.ReadByte());
    public static ReportAttribute BoschErrorCode { get; } = zcl.Report(0x5000, "Error Code", r => r.ReadByte());
    #endregion 

    public static Task SetpointRaiseLower => Task.CompletedTask;
    public static Task SetWeeklySchedule => Task.CompletedTask;
    public static Task GetWeeklySchedule => Task.CompletedTask;
    public static Task ClearWeeklySchedule => Task.CompletedTask;
    public static Task GetRelayStatusLog => Task.CompletedTask;

    public static Task GetWeeklyScheduleResponse => Task.CompletedTask;
}
