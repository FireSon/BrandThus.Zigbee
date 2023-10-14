using System.Security.AccessControl;
using System.Xml;

Console.WriteLine("Generate Zigbee Clusters!");

var xmlDoc = new XmlDocument();
xmlDoc.Load(Path.Combine("..", "..", "..", "general.xml"));

var domains = new Dictionary<string?, Domain>();
var xmlnode = xmlDoc.GetElementsByTagName("cluster");
for (int i = 0; i <= xmlnode.Count - 1; i++)
{
    Domain? domain = null;
    var n = xmlnode[i];
    var p = n.ParentNode;
    var dn = p?.LocalName == "domain" ? p.Attributes.GetNamedItem("name")?.Value?.ToString() : null;
    if (!domains.TryGetValue(dn, out domain))
        domains.Add(dn, domain = new() { Name = dn, Help = p?.InnerText });

    domain.Clusters.Add(new()
    {
        Name = n.Attributes.GetNamedItem("name")?.Value?.ToString(),
        Id = n.Attributes.GetNamedItem("id")?.Value?.ToString(),
        Help = n?.InnerText
    });
}
Console.WriteLine();

internal class Domain
{
    internal string? Name { get; set; }
    internal string? Help { get; set; }
    internal List<Cluster> Clusters = new();
}

internal class Cluster
{
    internal string? Name { get; set; }
    internal string? Id { get; set; }
    internal string? Help { get; set; }
}