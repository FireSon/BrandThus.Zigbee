namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Legrand Specific clusters, Used by cable outlet.
/// <summary>
[Cluster(0xfc40, "Legrand - Specific clusters 2")]
public static class ZclLegrandSpecificClusters2
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLegrandSpecificClusters2));

    public enum ModeEnum
    {
        Comfort = 0x00,
        Comfort1 = 0x01,
        Comfort2 = 0x02,
        Eco = 0x03,
        HorsGel = 0x04,
        Off = 0x05,
    }

    /// <summary>
    /// Heating mode
    /// <summary>
    public static ReportAttribute Mode { get; } = zcl.Report(0x0000, "Mode", ZigbeeType.Enum8, r => (ModeEnum)r.ReadByte());
    /// <summary>
    /// Set fil pilote mode
    /// <summary>
    public static Task Unknow(this ZigbeeNode node, byte mode) => node.Zcl(zcl, 00, w => w+ mode);
}
