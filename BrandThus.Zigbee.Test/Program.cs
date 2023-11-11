using BrandThus.Zigbee.Clusters;
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
Zigbee.LogEvent = (type, file, mbr, line, msg) => Console.WriteLine($"{DateTime.Now} {mbr} {line} {msg}");

while (true)
{
    if (Console.KeyAvailable)
    {
        Console.WriteLine();
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Enter: goto ready;

            case ConsoleKey.C:
                Console.Clear();
                break;
            case ConsoleKey.T:
                //
                int value = Convert.ToInt32("0x6a5c", 16);
                var n = Zigbee.CreateNode((ushort)value);
                break;
            case ConsoleKey.D1:
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                Zigbee.SendAsync(n.IEEEDescriptor());
                break;
            case ConsoleKey.O:
                n = Zigbee.NodeList.FirstOrDefault(n => n.Addr16 == 14728);
                if (n != null)
                    n.Read(ZclTemperatureMeasurement.MeasuredValue, ZclTemperatureMeasurement.MinMeasuredValue, ZclTemperatureMeasurement.MaxMeasuredValue);
                break;
            case ConsoleKey.N:
                foreach (var zn in Zigbee.NodeList)
                    Zigbee.SendAsync(zn.NodeDescriptor());
                break;
            case ConsoleKey.P:
                foreach (var zn in Zigbee.NodeList)
                    Zigbee.SendAsync(zn.PowerDescriptor());
                break;
            case ConsoleKey.I:
                foreach (var zn in Zigbee.NodeList)
                    if (zn.Addr64 == 0)
                        Zigbee.SendAsync(zn.IEEEDescriptor());
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