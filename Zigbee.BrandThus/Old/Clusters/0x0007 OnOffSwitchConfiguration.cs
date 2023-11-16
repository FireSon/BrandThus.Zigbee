namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for configuring On/Off switching devices
/// <summary>
[Cluster(0x0007, "On/Off Switch Configuration")]
public static class ZclOnOffSwitchConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOnOffSwitchConfiguration));

    #region Switch Information
    public enum SwitchTypeEnum
    {
        Toggle = 0,
        Momentary = 1,
    }

    /// <summary>
    /// The SwitchType attribute specifies the basic functionality of the On/Off switching device.
    /// <summary>
    public static ReportAttribute SwitchType { get; } = zcl.Report(0x0000, "SwitchType", ZigbeeType.Enum8, r => (SwitchTypeEnum)r.ReadByte());
    #endregion 

    #region Switch Settings
    public enum SwitchActionsEnum
    {
        OnOff = 0,
        OffOn = 1,
        Toggle = 2,
    }

    /// <summary>
    /// The SwitchActions attribute is 8-bits in length and specifies the commands of the On/Off cluster to be generated
    /// when the switch moves between its two states.
    /// <summary>
    public static ReportAttribute SwitchActions { get; } = zcl.Report(0x0010, "SwitchActions", ZigbeeType.Enum8, r => (SwitchActionsEnum)r.ReadByte());
    #endregion 

}
