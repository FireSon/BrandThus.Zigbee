using BrandThus.Zigbee;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Text;

namespace BrandThus.Zigbee;

public abstract class ZigbeeManager
{
    #region Properties
    public abstract bool IsOpen { get; }
    public string Firmware { get; internal set; } = "??";
    public Action? OnLine { get; set; }
    public Action<ZigbeeNode>? OnNodeCreate { get; set; }
    public Action<ZigbeeNode>? OnNodePoll { get; set; }
    public List<ZigbeeNode>? NodeList => Nodes.Values.ToList();
    public LogEvent? LogEvent { get => Logger.LogEvent; set => Logger.LogEvent = value; }
    public Action<ZigbeeNode, ZigbeeAttribute, byte, object>? OnUpdate { get; set; }

    internal ZigbeeNode Coordinator = default!;
    internal Dictionary<ushort, ZigbeeNode> Nodes = [];
    #endregion

    #region CreateNode
    public ZigbeeNode CreateNode(ushort addr16)
    {
        if (Nodes.TryGetValue(addr16, out var node))
            return node;

        node = Nodes[addr16] = new ZigbeeNode(this) { Addr16 = addr16 };
        node.Requests.Add(node.NodeDescriptor());
        node.Requests.Add(node.PowerDescriptor());
        node.Requests.Add(node.IEEEDescriptor());
        OnNodeCreate?.Invoke(node);
        return node;
    }
    #endregion

    #region SendAsync
    public abstract Task SendAsync(ZigbeeRequest request);
    #endregion

    #region PermitJoin
    public Task PermitJoin(bool enable) => SendAsync(Coordinator.Zdo(54, w => w + (byte)(enable ? 255u : 0u) + (byte)1));
    #endregion
}
