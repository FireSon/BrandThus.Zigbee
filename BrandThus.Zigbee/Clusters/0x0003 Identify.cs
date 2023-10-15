namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for putting a device into Identification mode (e.g. flashing a light)
/// <summary>
[Cluster(0x0003, "Identify")]
public static class ZclIdentify
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIdentify));

    public static ReportAttribute IdentifyTime { get; } = zcl.Report(0x0000, "Identify Time", r => r.ReadUInt16());
    public static ReportAttribute IdentificationButton { get; } = zcl.Report(0x4000, "Identification button", r => r.ReadBool());
    public static Task Identify => Task.CompletedTask;
    public static Task IdentifyQuery => Task.CompletedTask;
    public static Task TriggerEffect => Task.CompletedTask;

    public static Task IdentifyQueryResponse => Task.CompletedTask;
}
