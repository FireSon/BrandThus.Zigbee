namespace BrandThus.Zigbee;

public enum ZigbeeType : byte
{
    Bool = 16,

    U8 = 32,
    U16 = 33,
    U24 = 34,
    U32 = 35,
    U40 = 36,
    U48 = 37,
    U64 = 39,

    S8 = 40,
    S16 = 41,
    S24 = 42,
    S32 = 43,

    Bmp8 = 24,
    Bmp16 = 25,
    Bmp24 = 26,
    Bmp32 = 27,

    Enum8 = 48,
    Enum16 = 49,

    Dat16 = 251,

    Cstring = 66,
    Ostring = 65,
    Lostring = 254,
    Seckey = 241,
    Uid = 240,
    Utc = 226,
    Float = 57,
    Array = 128,
}
