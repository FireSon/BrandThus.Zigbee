namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// Provides a mechanism for the management of an end device’s MAC Data Request rate.
/// <summary>
[Cluster(0x0020, "Poll Control")]
public static class ZclPollControl
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclPollControl));

    public static ReportAttribute CheckinInterval { get; } = zcl.Report(0x0000, "Check-in Interval", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute LongPollInterval { get; } = zcl.Report(0x0001, "Long Poll Interval", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute ShortPollInterval { get; } = zcl.Report(0x0002, "Short Poll Interval", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute FastPollTimeout { get; } = zcl.Report(0x0003, "Fast Poll Timeout", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute CheckinIntervalMin { get; } = zcl.Report(0x0004, "Check-in Interval Min", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute LongPollIntervalMin { get; } = zcl.Report(0x0005, "Long Poll Interval Min", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute FastPollTimeoutMax { get; } = zcl.Report(0x0006, "Fast Poll Timeout Max", ZigbeeType.U16, r => r.ReadUInt16());
    /// <summary>
    /// The Poll Control Cluster server sends out a Check-in command to the devices to which it is paired based on the
    /// server‘s Check-inInterval attribute. It does this to find out if any of the Poll Control Cluster Clients with
    /// which it is paired are interested in having it enter fast poll mode so that it can be managed. This request is
    /// sent out based on either the Check-inInterval, or the next Check-in value in the Fast Poll Stop Request generated
    /// by the Poll Control Cluster Client.
    /// <summary>
    public static Task Checkin(this ZigbeeNode node) => node.Zcl(zcl, 0x00);
    /// <summary>
    /// send Fast Poll Stop
    /// <summary>
    public static Task Stop(this ZigbeeNode node) => node.Zcl(zcl, 0x01);
    /// <summary>
    /// Sets the Read Only LongPollInterval attribute.
    /// <summary>
    public static Task SetLongPollInterval(this ZigbeeNode node, uint newLongPollInterval) => node.Zcl(zcl, 0x02, w => w+ newLongPollInterval);
    /// <summary>
    /// Sets the Read Only ShortPollInterval attribute.
    /// <summary>
    public static Task SetShortPollInterval(this ZigbeeNode node, ushort newShortPollInterval) => node.Zcl(zcl, 0x03, w => w+ newShortPollInterval);
}
