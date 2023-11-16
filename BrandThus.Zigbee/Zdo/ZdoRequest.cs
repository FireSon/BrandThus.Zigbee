using System;
using System.ComponentModel.Design;

namespace BrandThus.Zigbee.Zdo
{
    public class ZdoRequest : ZigbeeRequest
    {
        #region Constructor
        public ZdoRequest(Func<ZigbeeWriter, ZigbeeWriter>? write = null) : base(write)
        {
        } 
        #endregion

        #region WritePayLoad
        internal override void WritePayLoad(ZigbeeWriter writer)
        {
            writer.WriteByte(TransactionId);
            Write?.Invoke(writer);
        }
        #endregion
    }
}