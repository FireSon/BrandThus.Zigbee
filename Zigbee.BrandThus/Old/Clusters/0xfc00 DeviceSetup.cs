namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands.
/// <summary>
[Cluster(0xfc00, "Device Setup")]
public static class ZclDeviceSetup
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDeviceSetup));

    public static ReportAttribute InputConfigurations { get; } = zcl.Report(0x0000, "Input Configurations", ZigbeeType.Array, r => r.ReadArray());
    public static ReportAttribute InputActions { get; } = zcl.Report(0x0001, "Input Actions", ZigbeeType.Array, r => r.ReadArray());
}
