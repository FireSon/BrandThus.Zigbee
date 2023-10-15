#nullable disable

namespace BrandThus.Zigbee;

public abstract class ZigbeeAttribute
{
    #region Constructor
    internal ZigbeeAttribute(ZigbeeCluster cluster, ushort id, string name)
    {
        Cluster = cluster;
        AttrId = id;
        Name = name;
        Attributes[id + (cluster.Id << 16)] = this;
    } 
    #endregion

    #region Properties
    public ZigbeeCluster Cluster { get; set; }
    public ushort AttrId { get; set; }
    public string Name { get; set; }
    public int? ManufacturerCode { get; set; }

    internal static Dictionary<int, ZigbeeAttribute> Attributes = [];
    #endregion

    #region Read
    internal abstract object Read(ZigbeeReader reader); 
    #endregion
}

public class ZigbeeAttribute<T> : ZigbeeAttribute
{
    #region Constructor
    internal ZigbeeAttribute(ZigbeeCluster cluster, ushort id, string name, byte dataType, bool analog, Func<ZigbeeReader, T> readValue)
        : base(cluster, id, name) => ReadValue = readValue;
    #endregion

    #region Properties
    internal Func<ZigbeeReader, T> ReadValue;
    internal override object Read(ZigbeeReader reader) => ReadValue(reader); 
    #endregion
}

