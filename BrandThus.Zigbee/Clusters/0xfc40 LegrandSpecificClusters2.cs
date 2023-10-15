namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Legrand Specific clusters, Used by cable outlet.
/// <summary>
[Cluster(0xfc40, "Legrand - Specific clusters 2")]
public static class ZclLegrandSpecificClusters2
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLegrandSpecificClusters2));

    public static ReportAttribute Mode { get; } = zcl.Report(0x0000, "Mode", r => r.ReadByte());
    public static Task Unknow => Task.CompletedTask;
}
