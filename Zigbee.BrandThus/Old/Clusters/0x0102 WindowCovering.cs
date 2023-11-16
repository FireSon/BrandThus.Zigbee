namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The window covering cluster provides an interface for controlling and adjusting automatic window coverings such
/// as drapery motors, automatic shades, and blinds.
/// <summary>
[Cluster(0x0102, "Window Covering")]
public static class ZclWindowCovering
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclWindowCovering));

    #region Window Covering Information
    public enum WindowCoveringTypeEnum
    {
        Rollershade = 0,
        Rollershade2Motor = 1,
        RollershadeExterior = 2,
        RollershadeExterior2Motor = 3,
        Drapery = 4,
        Awning = 5,
        Shutter = 6,
        TiltBlindTiltOnly = 7,
        TiltBlindLiftAndTilt = 8,
        ProjectorScreen = 9,
    }

    public static ReportAttribute WindowCoveringType { get; } = zcl.Report(0x0000, "Window Covering Type", ZigbeeType.Enum8, r => (WindowCoveringTypeEnum)r.ReadByte());
    public static ReportAttribute PhysicalClosedLimitLift { get; } = zcl.Report(0x0001, "Physical Closed Limit – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PhysicalClosedLimitTilt { get; } = zcl.Report(0x0002, "Physical Closed Limit – Tilt", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CurrentPositionLift { get; } = zcl.Report(0x0003, "Current Position – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CurrentPositionTilt { get; } = zcl.Report(0x0004, "Current Position – Tilt", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfActuationsLift { get; } = zcl.Report(0x0005, "Number of Actuations – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NumberOfActuationsTilt { get; } = zcl.Report(0x0006, "Number of Actuations – Tilt", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ConfigStatus { get; } = zcl.Report(0x0007, "Config / Status", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute CurrentPositionLiftPercentage { get; } = zcl.Report(0x0008, "Current Position Lift Percentage", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute CurrentPositionTiltPercentage { get; } = zcl.Report(0x0009, "Current Position Tilt Percentage", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute OperationalStatus { get; } = zcl.Report(0x000a, "Operational Status", ZigbeeType.Bmp8, r => r.ReadByte());
    #endregion 

    #region Window Covering Settings
    public static ReportAttribute InstalledOpenLimitLift { get; } = zcl.Report(0x0010, "Installed Open Limit – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute InstalledClosedLimitLift { get; } = zcl.Report(0x0011, "Installed Closed Limit – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute InstalledOpenLimitTilt { get; } = zcl.Report(0x0012, "Installed Open Limit – Tilt", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute InstalledClosedLimitTilt { get; } = zcl.Report(0x0013, "Installed Closed Limit – Tilt", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute VelocityLift { get; } = zcl.Report(0x0014, "Velocity – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AccelerationTimeLift { get; } = zcl.Report(0x0015, "Acceleration Time – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute DecelerationTimeLift { get; } = zcl.Report(0x0016, "Deceleration Time – Lift", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute Mode { get; } = zcl.Report(0x0017, "Mode", ZigbeeType.Bmp8, r => r.ReadByte());
    public static ReportAttribute IntermediateSetpointsLift { get; } = zcl.Report(0x0018, "Intermediate Setpoints – Lift", ZigbeeType.Ostring, r => r.ReadString());
    public static ReportAttribute IntermediateSetpointsTilt { get; } = zcl.Report(0x0019, "Intermediate Setpoints – Tilt", ZigbeeType.Ostring, r => r.ReadString());
    #endregion 

    #region Tuya specific Window Covering Setting
    public enum TuyaWindowCoverStatusEnum
    {
        Upopen = 0,
        Downclose = 1,
        Stop = 2,
    }

    public static ReportAttribute TuyaWindowCoverStatus { get; } = zcl.Report(0xf000, "Window cover status", ZigbeeType.Enum8, r => (TuyaWindowCoverStatusEnum)r.ReadByte());
    public enum TuyaCalibrationEnum
    {
        Start = 0,
        End = 1,
    }

    public static ReportAttribute TuyaCalibration { get; } = zcl.Report(0xf001, "Calibration", ZigbeeType.Enum8, r => (TuyaCalibrationEnum)r.ReadByte());
    public enum TuyaMotorReversalEnum
    {
        Off = 0,
        On = 1,
    }

    public static ReportAttribute TuyaMotorReversal { get; } = zcl.Report(0xf002, "Motor Reversal", ZigbeeType.Enum8, r => (TuyaMotorReversalEnum)r.ReadByte());
    public static ReportAttribute TuyaCalibrationTimetenthOfASecond { get; } = zcl.Report(0xf003, "Calibration time (tenth of a second)", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Schneider specific
    /// <summary>
    /// Obsolete (only because backward compatibility). Driving time from fully open to fully close state in seconds.
    /// If possible, use Lift Drive Up Time, Lift Drive Down Time. If you set this time, also both (Lift Drive Up Time,
    /// Lift Drive Down Time) are set to this value automatically.
    /// <summary>
    public static ReportAttribute SchneiderDriveCloseDuration { get; } = zcl.Report(0xe000, "Drive Close Duration", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The Protection Status attribute specifies the status of the different protections of the device. Can be active
    /// only if Protection Sensor attribute is set (protection sensor as external device must be connected to device).
    /// Bit0: 0 = sun protection not active, 1 = sun protection active. Other bits reserved.
    /// <summary>
    public static ReportAttribute SchneiderProtectionStatus { get; } = zcl.Report(0xe010, "Protection Status", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// Default value in lux is 1862 Lux. Value in attribute = 10000 x log10 1862 = 10000 x3.26 = around 32767. The Sun
    /// Protection Illuminance Threshold attribute specifies the illuminance level above which the device enters Sun Protection
    /// mode if enabled (if ProtectionSensor attribute is set = protection sensor is connected to device). Sun Protection
    /// Illuminance Threshold represents illuminance in Lux (symbol lx) as follows: Sun Protection Illuminance Threshold
    /// = 10,000 x log10 Illuminance Where 1lx gt Illuminance gt 3.576 Mlx, corresponding to a SunProtectionIlluminanceThreshold
    /// in the range 0 to 0xfffe. A value of 0xffff indicates that this attribute is not valid.
    /// <summary>
    public static ReportAttribute SchneiderSunProtectionIlluminanceThreshold { get; } = zcl.Report(0xe012, "Sun Protection Illuminance Threshold", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The ProtectionSensor attribute specifies if the sun protection sensor (as external device) is connected or device
    /// receives measurement from a type of protection sensor (either local wired or wireless). Bit0: 0 = sun protection
    /// sensor not connected, 1 = sun protection sensor connected Other bits reserved.
    /// <summary>
    public static ReportAttribute SchneiderProtectionSensor { get; } = zcl.Report(0xe013, "Protection Sensor", ZigbeeType.Bmp8, r => r.ReadByte());
    /// <summary>
    /// Driving time from fully close to fully open state in1 /10 seconds.
    /// <summary>
    public static ReportAttribute SchneiderLiftDriveUpTime { get; } = zcl.Report(0xe014, "Lift Drive Up Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Driving time from fully open to fully close state in 1/10 seconds.
    /// <summary>
    public static ReportAttribute SchneiderLiftDriveDownTime { get; } = zcl.Report(0xe015, "Lift Drive Down Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Time from fully open to fully close tilt position in 1/100 seconds. This time is also taken as base for calculation
    /// of step size in Schneider manufacture specific command Stop Or Step Lift Percentage. If set to 0, WindosCoveringType
    /// attribute is automatically set to 0 (lift only)
    /// <summary>
    public static ReportAttribute SchneiderTiltOpenCloseAndStepTime { get; } = zcl.Report(0xe016, "Tilt Open Close And Step Time", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// Tilt position in percent adopted by tilt after receiving go to lift percentage command. Values 0-100 are absolute
    /// position of tilt with following meaning: 100: Position of tilt when shutter is moving up (usually up). 0: Position
    /// of tilt when shutter is moving down (usually down). 255: No action after command. 101-254: Tilt position before
    /// movement is restored.
    /// <summary>
    public static ReportAttribute SchneiderTiltPositionPercentageAfterMoveToLevel { get; } = zcl.Report(0xe017, "Tilt Position Percentage After Move To Level", ZigbeeType.U8, r => r.ReadByte());
    #endregion 

    #region Ubisys specific
    public static ReportAttribute UbisysTurnaroundGuardTime { get; } = zcl.Report(0x1000, "Turnaround Guard Time", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute UbisysLiftToTiltTransitionSteps { get; } = zcl.Report(0x1001, "Lift to Tilt Transition Steps", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute UbisysTotalSteps { get; } = zcl.Report(0x1002, "Total Steps", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute UbisysLiftToTiltTransitionSteps2 { get; } = zcl.Report(0x1003, "Lift to Tilt Transition Steps 2", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute UbisysTotalSteps2 { get; } = zcl.Report(0x1004, "Total Steps 2", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute UbisysAdditionalSteps { get; } = zcl.Report(0x1005, "Additional Steps", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute UbisysInactivePowerThreshold { get; } = zcl.Report(0x1006, "Inactive Power Threshold", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute UbisysStartupSteps { get; } = zcl.Report(0x1007, "Startup Steps", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    public static Task UpOpen(this ZigbeeNode node) => node.Zcl(zcl, 0x00);
    public static Task DownClose(this ZigbeeNode node) => node.Zcl(zcl, 0x01);
    public static Task Stop(this ZigbeeNode node) => node.Zcl(zcl, 0x02);
    public static Task GoToLiftValue(this ZigbeeNode node, ushort liftValue) => node.Zcl(zcl, 0x04, w => w+ liftValue);
    public static Task GoToLiftPercentage(this ZigbeeNode node, byte liftPercentage) => node.Zcl(zcl, 0x05, w => w+ liftPercentage);
    public static Task GoToTiltValue(this ZigbeeNode node, ushort tiltValue) => node.Zcl(zcl, 0x07, w => w+ tiltValue);
    public static Task GoToTiltPercentage(this ZigbeeNode node, byte tiltPercentage) => node.Zcl(zcl, 0x08, w => w+ tiltPercentage);
}
