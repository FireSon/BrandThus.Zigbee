using System.Collections.Generic;

namespace BrandThus.Zigbee.Zdo
{
    public class SimpleDescriptor
    {
        #region Constructor
        public SimpleDescriptor(ZigbeeReader r)
        {
            Endpoint = r.ReadByte();
            DeviceId = r.ReadUInt16();
            DeviceVersion = r.ReadByte();
            InputClusterList = r.ReadList(r => r.ReadUInt16());
            OutputClusterList = r.ReadList(r => r.ReadUInt16());
        } 
        #endregion

        #region Properties
        public byte Endpoint;
        public ushort DeviceId;
        public byte DeviceVersion;
        public List<ushort> InputClusterList;
        public List<ushort> OutputClusterList; 
        #endregion
    }
}
