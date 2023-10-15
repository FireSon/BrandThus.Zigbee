#nullable disable

namespace BrandThus.Zigbee;

public abstract class ReportAttribute : ZigbeeAttribute
{
    internal ReportAttribute(ZigbeeCluster cluster, ushort id, string name)
        : base(cluster, id, name)
    {
    }
}
public class ReportAttribute<T> : ReportAttribute
{
    internal ReportAttribute(ZigbeeCluster cluster, ushort id, string name, Func<ZigbeeReader, T> readValue)
        : base(cluster, id, name)
    {
        ReadValue = readValue;
    }

    #region Properties
    internal Func<ZigbeeReader, T> ReadValue;
    internal override object Read(ZigbeeReader reader) => ReadValue(reader);
    #endregion
}