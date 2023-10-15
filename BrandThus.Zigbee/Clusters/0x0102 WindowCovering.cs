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
    public static ReportAttribute WindowCoveringType { get; } = zcl.Report(0x0000, "Window Covering Type", r => r.ReadByte());
    public static ReportAttribute PhysicalClosedLimitLift { get; } = zcl.Report(0x0001, "Physical Closed Limit – Lift", r => r.ReadUInt16());
    public static ReportAttribute PhysicalClosedLimitTilt { get; } = zcl.Report(0x0002, "Physical Closed Limit – Tilt", r => r.ReadUInt16());
    public static ReportAttribute CurrentPositionLift { get; } = zcl.Report(0x0003, "Current Position – Lift", r => r.ReadUInt16());
    public static ReportAttribute CurrentPositionTilt { get; } = zcl.Report(0x0004, "Current Position – Tilt", r => r.ReadUInt16());
    public static ReportAttribute NumberOfActuationsLift { get; } = zcl.Report(0x0005, "Number of Actuations – Lift", r => r.ReadUInt16());
    public static ReportAttribute NumberOfActuationsTilt { get; } = zcl.Report(0x0006, "Number of Actuations – Tilt", r => r.ReadUInt16());
    public static ReportAttribute ConfigStatus { get; } = zcl.Report(0x0007, "Config / Status", r => r.ReadByte());
    public static ReportAttribute CurrentPositionLiftPercentage { get; } = zcl.Report(0x0008, "Current Position Lift Percentage", r => r.ReadByte());
    public static ReportAttribute CurrentPositionTiltPercentage { get; } = zcl.Report(0x0009, "Current Position Tilt Percentage", r => r.ReadByte());
    public static ReportAttribute OperationalStatus { get; } = zcl.Report(0x000a, "Operational Status", r => r.ReadByte());
    #endregion 

    #region Window Covering Settings
    public static ReportAttribute InstalledOpenLimitLift { get; } = zcl.Report(0x0010, "Installed Open Limit – Lift", r => r.ReadUInt16());
    public static ReportAttribute InstalledClosedLimitLift { get; } = zcl.Report(0x0011, "Installed Closed Limit – Lift", r => r.ReadUInt16());
    public static ReportAttribute InstalledOpenLimitTilt { get; } = zcl.Report(0x0012, "Installed Open Limit – Tilt", r => r.ReadUInt16());
    public static ReportAttribute InstalledClosedLimitTilt { get; } = zcl.Report(0x0013, "Installed Closed Limit – Tilt", r => r.ReadUInt16());
    public static ReportAttribute VelocityLift { get; } = zcl.Report(0x0014, "Velocity – Lift", r => r.ReadUInt16());
    public static ReportAttribute AccelerationTimeLift { get; } = zcl.Report(0x0015, "Acceleration Time – Lift", r => r.ReadUInt16());
    public static ReportAttribute DecelerationTimeLift { get; } = zcl.Report(0x0016, "Deceleration Time – Lift", r => r.ReadUInt16());
    public static ReportAttribute Mode { get; } = zcl.Report(0x0017, "Mode", r => r.ReadByte());
    public static ReportAttribute IntermediateSetpointsLift { get; } = zcl.Report(0x0018, "Intermediate Setpoints – Lift", r => r.ReadString());
    public static ReportAttribute IntermediateSetpointsTilt { get; } = zcl.Report(0x0019, "Intermediate Setpoints – Tilt", r => r.ReadString());
    #endregion 

    #region Tuya specific Window Covering Setting
    public static ReportAttribute TuyaWindowCoverStatus { get; } = zcl.Report(0xf000, "Window cover status", r => r.ReadByte());
    public static ReportAttribute TuyaCalibration { get; } = zcl.Report(0xf001, "Calibration", r => r.ReadByte());
    public static ReportAttribute TuyaMotorReversal { get; } = zcl.Report(0xf002, "Motor Reversal", r => r.ReadByte());
    public static ReportAttribute TuyaCalibrationTimetenthOfASecond { get; } = zcl.Report(0xf003, "Calibration time (tenth of a second)", r => r.ReadUInt16());
    #endregion 

    #region Schneider specific
    public static ReportAttribute SchneiderDriveCloseDuration { get; } = zcl.Report(0xe000, "Drive Close Duration", r => r.ReadUInt16());
    public static ReportAttribute SchneiderProtectionStatus { get; } = zcl.Report(0xe010, "Protection Status", r => r.ReadByte());
    public static ReportAttribute SchneiderSunProtectionIlluminanceThreshold { get; } = zcl.Report(0xe012, "Sun Protection Illuminance Threshold", r => r.ReadUInt16());
    public static ReportAttribute SchneiderProtectionSensor { get; } = zcl.Report(0xe013, "Protection Sensor", r => r.ReadByte());
    public static ReportAttribute SchneiderLiftDriveUpTime { get; } = zcl.Report(0xe014, "Lift Drive Up Time", r => r.ReadUInt16());
    public static ReportAttribute SchneiderLiftDriveDownTime { get; } = zcl.Report(0xe015, "Lift Drive Down Time", r => r.ReadUInt16());
    public static ReportAttribute SchneiderTiltOpenCloseAndStepTime { get; } = zcl.Report(0xe016, "Tilt Open Close And Step Time", r => r.ReadUInt16());
    public static ReportAttribute SchneiderTiltPositionPercentageAfterMoveToLevel { get; } = zcl.Report(0xe017, "Tilt Position Percentage After Move To Level", r => r.ReadByte());
    #endregion 

    #region Ubisys specific
    public static ReportAttribute UbisysTurnaroundGuardTime { get; } = zcl.Report(0x1000, "Turnaround Guard Time", r => r.ReadByte());
    public static ReportAttribute UbisysLiftToTiltTransitionSteps { get; } = zcl.Report(0x1001, "Lift to Tilt Transition Steps", r => r.ReadUInt16());
    public static ReportAttribute UbisysTotalSteps { get; } = zcl.Report(0x1002, "Total Steps", r => r.ReadUInt16());
    public static ReportAttribute UbisysLiftToTiltTransitionSteps2 { get; } = zcl.Report(0x1003, "Lift to Tilt Transition Steps 2", r => r.ReadUInt16());
    public static ReportAttribute UbisysTotalSteps2 { get; } = zcl.Report(0x1004, "Total Steps 2", r => r.ReadUInt16());
    public static ReportAttribute UbisysAdditionalSteps { get; } = zcl.Report(0x1005, "Additional Steps", r => r.ReadByte());
    public static ReportAttribute UbisysInactivePowerThreshold { get; } = zcl.Report(0x1006, "Inactive Power Threshold", r => r.ReadUInt16());
    public static ReportAttribute UbisysStartupSteps { get; } = zcl.Report(0x1007, "Startup Steps", r => r.ReadUInt16());
    #endregion 

    public static Task UpOpen => Task.CompletedTask;
    public static Task DownClose => Task.CompletedTask;
    public static Task Stop => Task.CompletedTask;
    public static Task GoToLiftValue => Task.CompletedTask;
    public static Task GoToLiftPercentage => Task.CompletedTask;
    public static Task GoToTiltValue => Task.CompletedTask;
    public static Task GoToTiltPercentage => Task.CompletedTask;
}
