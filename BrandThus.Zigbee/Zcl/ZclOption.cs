namespace BrandThus.Zigbee.Zcl;[Flags]public enum ZclOption{	None = 0,	Optional = 1,	Write = 2,	Report = 4,	All = 0xFF,	OptionalWrite = 3,	OptionalReport = 5,	WriteReport = 6}