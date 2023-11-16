namespace BrandThus.Zigbee.Conbee
{
    public enum ConbeeParameter : byte
    {
        MacAddress = 1,
        NwkPanId = 5,
        NwkAddress = 7,
        NwkExtendedPanId = 8,
        ApsDesignedCoordinator = 9,
        ChannelMask = 10,
        ApsExtendedPanId = 11,
        TrustCenterAddress = 14,
        SecurityMode = 16,
        NetworkKey = 24,
        CurrentChannel = 28,
        ProtocolVersion = 34,
        NwkUpdateId = 36,
        WatchdogTTL = 38
    }
}