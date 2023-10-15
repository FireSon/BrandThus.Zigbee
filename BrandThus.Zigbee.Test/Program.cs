using BrandThus.Zigbee.Conbee;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Zigbee Test program");

#region Get configuration
var environment = args.Length == 1 ? args[0] : "Production";
var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json")
     .AddJsonFile($"appsettings.{environment}.json", optional: true);
var config = configuration.Build();
#endregion

var Zigbee = new ConbeeManager(config, new());
Zigbee.OnLine = () => Console.WriteLine("Online");
Zigbee.LogEvent = (type, file, mbr, line, msg) => Console.WriteLine($"{type} {file} {mbr} {line} {msg}");

while (true)
{
    if (Console.KeyAvailable)
    {
        Console.WriteLine();
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Enter: goto ready;
            case ConsoleKey.O:
                foreach (var c in Zigbee.NodeList)
                {
                    await c.NodeDescriptor();
                }
                break;
                //case ConsoleKey.P:
                //    foreach (var c in Zigbee.Nodes)
                //        c.Relay(false);
                //    break;
                //case ConsoleKey.T:
                //    foreach (var c in Zigbee.Nodes)
                //        c.Relay(null);
                //    break;
                //case ConsoleKey.R:
                //    foreach (var c in Zigbee.Nodes)
                //        c.Refresh();
                //    break;
        }
        Console.WriteLine("Handled");
    }
}

ready:
Console.WriteLine();