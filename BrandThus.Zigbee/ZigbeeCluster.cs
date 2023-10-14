namespace BrandThus.Zigbee;

public class ZigbeeCluster(ushort id, string name)
{
    #region Properties
    public ushort Id { get; set; } = id;
    public string Name { get; set; } = name;
    #endregion

    #region Attributes
    internal ZigbeeAttribute Report<T>(ushort id, string name, byte dataType, bool analog, Func<ZigbeeReader, T> reader) =>
        new ZigbeeAttribute<T>(this, id, name, dataType, analog, reader);

    internal ZigbeeAttribute Attribute<T>(ushort id, string name, byte dataType, bool analog, Func<ZigbeeReader, T> reader) =>
        new ZigbeeAttribute<T>(this, id, name, dataType, analog, reader); 
    #endregion
}
