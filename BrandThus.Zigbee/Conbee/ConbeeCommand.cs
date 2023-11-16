namespace BrandThus.Zigbee.Conbee
{
    public enum ConbeeCommand : byte
    {
        DEVICE_STATE = 7,
        CHANGE_NETWORK_STATE = 8,
        READ_PARAMETER = 10,
        WRITE_PARAMETER = 11,
        DEVICE_STATE_CHANGED = 14,
        VERSION = 13,
        APS_DATA_REQUEST = 18,
        APS_DATA_CONFIRM = 4,
        APS_DATA_INDICATION = 23,
        MAC_POLL_INDICATION = 28,
        MAC_BEACON_INDICATION = 31,
        UPDATE_BOOTLOADER = 33
    }
}