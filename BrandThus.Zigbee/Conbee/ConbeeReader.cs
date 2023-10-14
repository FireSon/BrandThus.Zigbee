using System;
using System.Linq;
using System.Text;

namespace BrandThus.Zigbee.Conbee;

internal class ConbeeReader : ZigbeeReader
{
    internal ConbeeCommand Command => (ConbeeCommand)Buffer[0];
    internal ConbeeStatus Status => (ConbeeStatus)Buffer[2];
}
