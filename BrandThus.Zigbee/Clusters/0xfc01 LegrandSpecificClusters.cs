namespace BrandThus.Zigbee.Clusters;

/// <summary>
///   				Legrand Classic Specific clusters, used by all devices. But take care they are device specific.  				> Dimmer
/// switch without neutral : Option 1 = Dimmer on/off.  				> Cable outlet : Option 1 = Fil pilote on/off.  				>
/// Contactor : On/off=0003 - HP/HC=0004.  			
/// <summary>
[Cluster(0xfc01, "Legrand - Specific clusters")]
public static class ZclLegrandSpecificClusters
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclLegrandSpecificClusters));

    public static ReportAttribute Option1 { get; } = zcl.Report(0x0000, "Option 1", r => r.ReadByte());
    public static ReportAttribute Option2 { get; } = zcl.Report(0x0001, "Option 2", r => r.ReadBool());
    public static ReportAttribute Option3 { get; } = zcl.Report(0x0002, "Option 3", r => r.ReadBool());
}
