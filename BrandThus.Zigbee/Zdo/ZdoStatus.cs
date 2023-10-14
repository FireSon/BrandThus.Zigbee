namespace BrandThus.Zigbee.Zdo;

public enum ZdoStatus : byte
{
    UNKNOWN = byte.MaxValue,
    SUCCESS = 0,
    INV_REQUESTTYPE = 128,
    DEVICE_NOT_FOUND = 129,
    INVALID_EP = 130,
    NOT_ACTIVE = 131,
    NOT_SUPPORTED = 132,
    TIMEOUT = 133,
    NO_MATCH = 134,
    NO_ENTRY = 136,
    NO_DESCRIPTOR = 137,
    INSUFFICIENT_SPACE = 138,
    NOT_PERMITTED = 139,
    TABLE_FULL = 140,
    NOT_AUTHORIZED = 141
}
