namespace BrandThus.Zigbee.Zdo
{
    public class NodeDescriptor
    {
        #region Constructor
        public NodeDescriptor(ZigbeeReader r)
        {
            BitsFlag0 = r.ReadByte();
            BitsFlag1 = r.ReadByte();
            MacCapabilities = r.ReadByte();
            ManufacturerCode = r.ReadUInt16();
            MaxBufferSize = r.ReadByte();
            MaxRxSize = r.ReadUInt16();
            ServerMask = r.ReadUInt16();
            MaxTxSize = r.ReadUInt16();
            DescriptorCapabilities = r.ReadByte();
        }
        #endregion

        #region Properties
        public byte BitsFlag0;
        public byte BitsFlag1;
        public byte MacCapabilities;
        public ushort ManufacturerCode;
        public byte MaxBufferSize;
        public ushort MaxRxSize;
        public ushort ServerMask;
        public ushort MaxTxSize;
        public byte DescriptorCapabilities;
        #endregion

        #region ToString
        public override string ToString() => $"ManufacturerCode: {ManufacturerCode:X4}, MaxBufferSize: {MaxBufferSize:X2}, MaxRxSize: {MaxRxSize:X4}, MaxTxSize: {MaxTxSize:X4}, ServerMask: {ServerMask:X4}, MacCapabilities: {MacCapabilities:X2}, DescriptorCapabilities: {MacCapabilities:X2}"; 
        #endregion
    }
}