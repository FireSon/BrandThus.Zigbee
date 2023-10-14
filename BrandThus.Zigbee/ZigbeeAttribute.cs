#nullable disable

namespace BrandThus.Zigbee;

public abstract class ZigbeeAttribute
{
    #region Constructor
    internal ZigbeeAttribute(ZigbeeCluster cluster, ushort id, string name, byte dataType, bool analog)
    {
        Cluster = cluster;
        AttrId = id;
        Name = name;
        Attributes[id + (cluster.Id << 16)] = this;
        DataType = dataType;
        Analog = analog;
    } 
    #endregion

    #region Properties
    public ZigbeeCluster Cluster { get; set; }
    public ushort AttrId { get; set; }
    public string Name { get; set; }
    public int? ManufacturerCode { get; set; }
    public byte DataType { get; set; }
    public bool Analog { get; set; }

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
        : base(cluster, id, name, dataType, analog) => ReadValue = readValue;
    #endregion

    internal Func<ZigbeeReader, T> ReadValue;
    internal override object Read(ZigbeeReader reader) => ReadValue(reader);
}
