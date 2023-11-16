namespace BrandThus.Zigbee.Descriptors;

public record SimpleDescriptor(byte Endpoint, ushort DeviceId, byte DeviceVersion, List<ushort> InputClusterList, List<ushort> OutputClusterList);
