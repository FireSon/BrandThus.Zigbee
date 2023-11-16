namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides a mechanism for querying data about the electrical properties as measured by the device.
/// <summary>
[Cluster(0x0b04, "Electrical Measurement")]
public static class ZclElectricalMeasurement
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclElectricalMeasurement));

    #region Basic Information
    public static ReportAttribute MeasurementType { get; } = zcl.Report(0x0000, "Measurement Type", ZigbeeType.Bmp32, r => r.ReadInt32());
    #endregion 

    #region DC Measurement
    public static ReportAttribute DCVoltage { get; } = zcl.Report(0x0100, "DC Voltage", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCVoltageMin { get; } = zcl.Report(0x0101, "DC Voltage Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCVoltageMax { get; } = zcl.Report(0x0102, "DC Voltage Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCCurrent { get; } = zcl.Report(0x0103, "DC Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCCurrentMin { get; } = zcl.Report(0x0104, "DC Current Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCCurrentMax { get; } = zcl.Report(0x0105, "DC Current Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCPower { get; } = zcl.Report(0x0106, "DC Power", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCPowerMin { get; } = zcl.Report(0x0107, "DC Power Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCPowerMax { get; } = zcl.Report(0x0108, "DC Power Max", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region DC Formatting
    public static ReportAttribute DCVoltageMultiplier { get; } = zcl.Report(0x0200, "DC Voltage Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCVoltageDivisor { get; } = zcl.Report(0x0201, "DC Voltage Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCCurrentMultiplier { get; } = zcl.Report(0x0202, "DC Current Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCCurrentDivisor { get; } = zcl.Report(0x0203, "DC Current Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCPowerMultiplier { get; } = zcl.Report(0x0204, "DC Power Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DCPowerDivisor { get; } = zcl.Report(0x0205, "DC Power Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region AC (Non-phase Specific) Measurements
    public static ReportAttribute ACFrequency { get; } = zcl.Report(0x0300, "AC Frequency", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACFrequencyMin { get; } = zcl.Report(0x0301, "AC Frequency Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACFrequencyMax { get; } = zcl.Report(0x0302, "AC Frequency Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NeutralCurrent { get; } = zcl.Report(0x0303, "Neutral current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute TotalActivePower { get; } = zcl.Report(0x0304, "Total Active Power", ZigbeeType.S32, r => r.ReadInt32());
    public static ReportAttribute TotalReactivePower { get; } = zcl.Report(0x0305, "Total Reactive Power", ZigbeeType.S32, r => r.ReadInt32());
    public static ReportAttribute TotalApparentPower { get; } = zcl.Report(0x0306, "Total Apparent Power", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute Measured1stHarmonicCurrent { get; } = zcl.Report(0x0307, "Measured 1st harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Measured3rdHarmonicCurrent { get; } = zcl.Report(0x0308, "Measured 3rd harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Measured5thHarmonicCurrent { get; } = zcl.Report(0x0309, "Measured 5th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Measured7thHarmonicCurrent { get; } = zcl.Report(0x030A, "Measured 7th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Measured9thHarmonicCurrent { get; } = zcl.Report(0x030B, "Measured 9th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute Measured11thHarmonicCurrent { get; } = zcl.Report(0x030C, "Measured 11th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase1stHarmonicCurrent { get; } = zcl.Report(0x030D, "Measured Phase 1st harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase3rdHarmonicCurrent { get; } = zcl.Report(0x030E, "Measured Phase 3rd harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase5thHarmonicCurrent { get; } = zcl.Report(0x030F, "Measured Phase 5th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase7thHarmonicCurrent { get; } = zcl.Report(0x0310, "Measured Phase 7th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase9thHarmonicCurrent { get; } = zcl.Report(0x0311, "Measured Phase 9th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute MeasuredPhase11thHarmonicCurrent { get; } = zcl.Report(0x0312, "Measured Phase 11th harmonic Current", ZigbeeType.S16, r => r.ReadInt16());
    #endregion 

    #region AC (Non-phase Specific) Formatting
    public static ReportAttribute ACFrequencyMultiplier { get; } = zcl.Report(0x0400, "AC Frequency Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACFrequencyDivisor { get; } = zcl.Report(0x0401, "AC Frequency Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PowerMultiplier { get; } = zcl.Report(0x0402, "Power Multiplier", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute PowerDivisor { get; } = zcl.Report(0x0403, "Power Divisor", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute HarmonicCurrentMultiplier { get; } = zcl.Report(0x0404, "Harmonic Current Multiplier", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute PhaseHarmonicCurrentMultiplier { get; } = zcl.Report(0x0405, "Phase Harmonic Current Multiplier", ZigbeeType.S8, r => r.ReadByte());
    #endregion 

    #region AC (Single Phase or Phase A) Measurements
    public static ReportAttribute LineCurrentA { get; } = zcl.Report(0x0501, "Line Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ActiveCurrentA { get; } = zcl.Report(0x0502, "Active Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactiveCurrentA { get; } = zcl.Report(0x0503, "Reactive Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSVoltageA { get; } = zcl.Report(0x0505, "RMS Voltage", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMinA { get; } = zcl.Report(0x0506, "RMS Voltage Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMaxA { get; } = zcl.Report(0x0507, "RMS Voltage Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentA { get; } = zcl.Report(0x0508, "RMS Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMinA { get; } = zcl.Report(0x0509, "RMS Current Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMaxA { get; } = zcl.Report(0x050a, "RMS Current Max", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Represents the single phase or Phase A, current demand of active power delivered or received at the premises,
    /// in Watts (W). Positive values indicate power delivered to the premises where negative values indicate power received
    /// from the premises.
    /// <summary>
    public static ReportAttribute ActivePowerA { get; } = zcl.Report(0x050b, "Active Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMinA { get; } = zcl.Report(0x050c, "Active Power Min", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMaxA { get; } = zcl.Report(0x050d, "Active Power Max", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactivePowerA { get; } = zcl.Report(0x050e, "Reactive Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ApparentPowerA { get; } = zcl.Report(0x050f, "Apparent Power", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PowerFactorA { get; } = zcl.Report(0x0510, "Power Factor", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute AverageRMSVoltageMeasurementPeriodA { get; } = zcl.Report(0x0511, "Average RMS Voltage Measurement Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSOverVoltageCounterA { get; } = zcl.Report(0x0512, "Average RMS Over Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSUnderVoltageCounterA { get; } = zcl.Report(0x0513, "Average RMS Under Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeOverVoltagePeriodA { get; } = zcl.Report(0x0514, "RMS Extreme Over Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeUnderVoltagePeriodA { get; } = zcl.Report(0x0515, "RMS Extreme Under Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSagPeriodA { get; } = zcl.Report(0x0516, "RMS Voltage Sag Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSwellPeriodA { get; } = zcl.Report(0x0517, "RMS Voltage Swell Period", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region AC Formatting
    public static ReportAttribute ACVoltageMultiplier { get; } = zcl.Report(0x0600, "AC Voltage Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACVoltageDivisor { get; } = zcl.Report(0x0601, "AC Voltage Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACCurrentMultiplier { get; } = zcl.Report(0x0602, "AC Current Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACCurrentDivisor { get; } = zcl.Report(0x0603, "AC Current Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACPowerMultiplier { get; } = zcl.Report(0x0604, "AC Power Multiplier", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ACPowerDivisor { get; } = zcl.Report(0x0605, "AC Power Divisor", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region DC Manufacturer Threshold Alarms
    public static ReportAttribute DCOverloadAlarmsMask { get; } = zcl.Report(0x0700, "DC Overload Alarms Mask", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute DCVoltageOverload { get; } = zcl.Report(0x0701, "DC Voltage Overload", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute DCCurrentOverload { get; } = zcl.Report(0x0702, "DC Current Overload", ZigbeeType.S16, r => r.ReadInt16());
    #endregion 

    #region AC Manufacturer Threshold Alarms
    public static ReportAttribute ACOverloadAlarmsMask { get; } = zcl.Report(0x0800, "AC Overload Alarms Mask", ZigbeeType.Bmp16, r => r.ReadInt16());
    public static ReportAttribute ACVoltageOverload { get; } = zcl.Report(0x0801, "AC Voltage Overload", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ACCurrentOverload { get; } = zcl.Report(0x0802, "AC Current Overload", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ACActivePowerOverload { get; } = zcl.Report(0x0803, "AC Active Power Overload", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ACReactivePowerOverload { get; } = zcl.Report(0x0804, "AC Reactive Power Overload", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AverageRMSOverVoltage { get; } = zcl.Report(0x0805, "Average RMS Over Voltage", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute AverageRMSUnderVoltage { get; } = zcl.Report(0x0806, "Average RMS Under Voltage", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSExtremeOverVoltage { get; } = zcl.Report(0x0807, "RMS Extreme Over Voltage", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSExtremeUnderVoltage { get; } = zcl.Report(0x0808, "RMS Extreme Under Voltage", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSVoltageSag { get; } = zcl.Report(0x0809, "RMS Voltage Sag", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSVoltageSwell { get; } = zcl.Report(0x080a, "RMS Voltage Swell", ZigbeeType.S16, r => r.ReadInt16());
    #endregion 

    #region AC (Phase B) Measurements
    public static ReportAttribute LineCurrentB { get; } = zcl.Report(0x0901, "Line Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ActiveCurrentB { get; } = zcl.Report(0x0902, "Active Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactiveCurrentB { get; } = zcl.Report(0x0903, "Reactive Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSVoltageB { get; } = zcl.Report(0x0905, "RMS Voltage", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMinB { get; } = zcl.Report(0x0906, "RMS Voltage Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMaxB { get; } = zcl.Report(0x0907, "RMS Voltage Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentB { get; } = zcl.Report(0x0908, "RMS Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMinB { get; } = zcl.Report(0x0909, "RMS Current Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMaxB { get; } = zcl.Report(0x090a, "RMS Current Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ActivePowerB { get; } = zcl.Report(0x090b, "Active Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMinB { get; } = zcl.Report(0x090c, "Active Power Min", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMaxB { get; } = zcl.Report(0x090d, "Active Power Max", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactivePowerB { get; } = zcl.Report(0x090e, "Reactive Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ApparentPowerB { get; } = zcl.Report(0x090f, "Apparent Power", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PowerFactorB { get; } = zcl.Report(0x0910, "Power Factor", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute AverageRMSVoltageMeasurementPeriodB { get; } = zcl.Report(0x0911, "Average RMS Voltage Measurement Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSOverVoltageCounterB { get; } = zcl.Report(0x0912, "Average RMS Over Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSUnderVoltageCounterB { get; } = zcl.Report(0x0913, "Average RMS Under Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeOverVoltagePeriodB { get; } = zcl.Report(0x0914, "RMS Extreme Over Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeUnderVoltagePeriodB { get; } = zcl.Report(0x0915, "RMS Extreme Under Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSagPeriodB { get; } = zcl.Report(0x0916, "RMS Voltage Sag Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSwellPeriodB { get; } = zcl.Report(0x0917, "RMS Voltage Swell Period", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region AC (Phase C) Measurements
    public static ReportAttribute LineCurrentC { get; } = zcl.Report(0x0a01, "Line Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ActiveCurrentC { get; } = zcl.Report(0x0a02, "Active Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactiveCurrentC { get; } = zcl.Report(0x0a03, "Reactive Current", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute RMSVoltageC { get; } = zcl.Report(0x0a05, "RMS Voltage", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMinC { get; } = zcl.Report(0x0a06, "RMS Voltage Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageMaxC { get; } = zcl.Report(0x0a07, "RMS Voltage Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentC { get; } = zcl.Report(0x0a08, "RMS Current", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMinC { get; } = zcl.Report(0x0a09, "RMS Current Min", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSCurrentMaxC { get; } = zcl.Report(0x0a0a, "RMS Current Max", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ActivePowerC { get; } = zcl.Report(0x0a0b, "Active Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMinC { get; } = zcl.Report(0x0a0c, "Active Power Min", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ActivePowerMaxC { get; } = zcl.Report(0x0a0d, "Active Power Max", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ReactivePowerC { get; } = zcl.Report(0x0a0e, "Reactive Power", ZigbeeType.S16, r => r.ReadInt16());
    public static ReportAttribute ApparentPowerC { get; } = zcl.Report(0x0a0f, "Apparent Power", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PowerFactorC { get; } = zcl.Report(0x0a10, "Power Factor", ZigbeeType.S8, r => r.ReadByte());
    public static ReportAttribute AverageRMSVoltageMeasurementPeriodC { get; } = zcl.Report(0x0a11, "Average RMS Voltage Measurement Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSOverVoltageCounterC { get; } = zcl.Report(0x0a12, "Average RMS Over Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AverageRMSUnderVoltageCounterC { get; } = zcl.Report(0x0a13, "Average RMS Under Voltage Counter", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeOverVoltagePeriodC { get; } = zcl.Report(0x0a14, "RMS Extreme Over Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSExtremeUnderVoltagePeriodC { get; } = zcl.Report(0x0a15, "RMS Extreme Under Voltage Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSagPeriodC { get; } = zcl.Report(0x0a16, "RMS Voltage Sag Period", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RMSVoltageSwellPeriodC { get; } = zcl.Report(0x0a17, "RMS Voltage Swell Period", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

}
