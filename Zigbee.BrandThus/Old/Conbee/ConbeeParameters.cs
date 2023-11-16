namespace BrandThus.Zigbee.Conbee;

public class ConbeeParameters
{
    internal ulong MacAddress;
    internal ushort NwkPanId;
    internal ushort NwkAddress;
    internal ulong NwkExtendedPanId;
    internal byte ApsDesignedCoordinator;
    internal ushort ChannelMask;
    internal ulong ApsExtendedPanId;
    internal ulong TrustCenterAddress;
    internal byte SecurityMode;
    internal string? NetworkKey;
    internal byte CurrentChannel;
    internal ushort ProtocolVersion;
    internal byte NwkUpdateId;
    internal ushort WatchdogTTL;
}
