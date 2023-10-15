using System.Reflection;

namespace BrandThus.Zigbee;

public class ZigbeeCluster
{
    #region Constructor
    public ZigbeeCluster(Type type)
    {
        var c = type.GetCustomAttribute<ClusterAttribute>();
        if (c != null)
            Id = c.ClusterId;
        Name = c != null ? c.Name : string.Empty;
    } 
    #endregion

    #region Properties
    public ushort Id { get; set; } 
    public string Name { get; set; } 
    #endregion

    #region Attributes
    internal ReportAttribute Report<T>(ushort id, string name, Func<ZigbeeReader, T> reader) =>
        new ReportAttribute<T>(this, id, name, reader);

    internal ReportAttribute Attribute<T>(ushort id, string name, Func<ZigbeeReader, T> reader) =>
        new ReportAttribute<T>(this, id, name, reader); 
    #endregion
}

#region ClusterAttribute
[global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ClusterAttribute(ushort clusterId, string name) : Attribute
{
    #region Properties
    public ushort ClusterId { get; set; } = clusterId;
    public string Name { get; set; } = name;
    #endregion
}
#endregion
