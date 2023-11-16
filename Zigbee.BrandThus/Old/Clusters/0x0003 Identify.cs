namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Attributes and commands for putting a device into Identification mode (e.g. flashing a light)
/// <summary>
[Cluster(0x0003, "Identify")]
public static class ZclIdentify
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclIdentify));

    public static ReportAttribute IdentifyTime { get; } = zcl.Report(0x0000, "Identify Time", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute IdentificationButton { get; } = zcl.Report(0x4000, "Identification button", ZigbeeType.Bool, r => r.ReadBool());
    /// <summary>
    /// Start or stop the device identifying itself.
    /// <summary>
    public static Task Identify(this ZigbeeNode node, ushort identifyTime) => node.Zcl(zcl, 00, w => w+ identifyTime);
    /// <summary>
    /// Allows the sending device to request the target or targets to respond if they are currently identifying themselves.
    /// <summary>
    public static Task IdentifyQuery(this ZigbeeNode node) => node.Zcl(zcl, 01);
    /// <summary>
    /// The trigger effect command allows the support of feedback to the user, such as a certain light effect.
    /// <summary>
    public static Task TriggerEffect(this ZigbeeNode node, byte effectIdentifier, byte effectVariant) => node.Zcl(zcl, 40, w => w+ effectIdentifier+ effectVariant);

    /// <summary>
    /// Response of a identify query command.
    /// <summary>
    public static Task IdentifyQueryResponse(this ZigbeeNode node, ushort timeout) => node.Zcl(zcl, 00, w => w+ timeout);
}
