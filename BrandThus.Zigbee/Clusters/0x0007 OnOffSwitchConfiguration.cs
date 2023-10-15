namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for configuring On/Off switching devices
/// <summary>
[Cluster(0x0007, "On/Off Switch Configuration")]
public static class ZclOnOffSwitchConfiguration
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclOnOffSwitchConfiguration));

    #region Switch Information
    public static ReportAttribute SwitchType { get; } = zcl.Report(0x0000, "SwitchType", r => r.ReadByte());
    #endregion 

    #region Switch Settings
    public static ReportAttribute SwitchActions { get; } = zcl.Report(0x0010, "SwitchActions", r => r.ReadByte());
    #endregion 

}
