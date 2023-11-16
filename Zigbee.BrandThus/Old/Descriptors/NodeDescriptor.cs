namespace BrandThus.Zigbee.Descriptors;

public record NodeDescriptor(byte BitsFlag0, byte BitsFlag1, byte MacCapabilities, ushort ManufacturerCode, byte MaxBufferSize, ushort MaxRxSize, ushort ServerMask, ushort MaxTxSize, byte DescriptorCapabilities)
{
	public override string ToString()
	{
		return $"ManufacturerCode: {ManufacturerCode:X4}, MaxBufferSize: {MaxBufferSize:X2}, MaxRxSize: {MaxRxSize:X4}, MaxTxSize: {MaxTxSize:X4}, ServerMask: {ServerMask:X4}, MacCapabilities: {MacCapabilities:X2}, DescriptorCapabilities: {MacCapabilities:X2}";
	}
}
