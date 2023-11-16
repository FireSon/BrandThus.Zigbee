using System;

namespace BrandThus.Zigbee.Conbee
{
    internal class ConbeeWriter : ZigbeeWriter
    {
        internal void WritePayload(Action<byte> write)
        {
            for (int i = 0; i < Length; i++)
            {
                write(Buffer[i]);
            }
        }
    }
}