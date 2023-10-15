namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The Price Cluster provides the mechanism for communicating Gas, Energy, or Water pricing information within the
/// premise. This pricing information is distributed to the ESP from either the utilities or from regional energy
/// providers.
/// <summary>
[Cluster(0x0700, "Price")]
public static class ZclPrice
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPrice));

    public static ReportAttribute Tier1PriceLabel { get; } = zcl.Report(0000, "Tier1 Price Label", r => r.ReadString());
    public static ReportAttribute Tier2PriceLabel { get; } = zcl.Report(0001, "Tier2 Price Label", r => r.ReadString());
    public static ReportAttribute Tier3PriceLabel { get; } = zcl.Report(0002, "Tier3 Price Label", r => r.ReadString());
    public static ReportAttribute Tier4PriceLabel { get; } = zcl.Report(0003, "Tier4 Price Label", r => r.ReadString());
    public static ReportAttribute Tier5PriceLabel { get; } = zcl.Report(0004, "Tier5 Price Label", r => r.ReadString());
    public static ReportAttribute Tier6PriceLabel { get; } = zcl.Report(0005, "Tier6 Price Label", r => r.ReadString());
    public static Task GetCurrentPrice => Task.CompletedTask;
    public static Task GetScheduledPrices => Task.CompletedTask;

}
