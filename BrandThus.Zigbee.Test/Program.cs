using BrandThus.Zigbee.Conbee;
using BrandThus.Zigbee.Clusters;
using Microsoft.Extensions.Configuration;
using BrandThus.Zigbee;

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
    ZigbeeNode GetPlug()
    {
        int value = Convert.ToInt32("0x6a5c", 16);
        return Zigbee.CreateNode((ushort)value);
    }
    if (Console.KeyAvailable)
    {
        Console.WriteLine();
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.Enter: goto ready;

            case ConsoleKey.C:
                Console.Clear();
                break;
            case ConsoleKey.D1:
                //Turn plug On
                var n = GetPlug();
                await n.On().SendAsync();
                break;
            case ConsoleKey.D2:
                //Turn plug Off
                n = GetPlug();
                await n.Off().SendAsync();
                break;
            case ConsoleKey.D3:
                //Get plug NodeDescriptor
                n = GetPlug();
                await n.NodeDescriptor().SendAsync();
                break;
            case ConsoleKey.D4:
                //Read the plug ManufacturerName
                n = GetPlug();
                await ZclBasic.ManufacturerName.ReadAsync(n);
                break;
            case ConsoleKey.D5:
                //Read multiple plug attributes
                n = GetPlug();
                (ZclOnOff.OnOff + ZclOnOff.OnTime).Read(n);
                (ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion + ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(n);
                break;
            case ConsoleKey.D6:
                //Get plug To Report each 10 seconds the On state
                n = GetPlug();
                await ZclOnOff.OnOff.ReportAsync(n, 10, 10);
                break;
            case ConsoleKey.T:
                n = GetPlug();
                break;
            case ConsoleKey.O:
                n = Zigbee.NodeList.FirstOrDefault(n => n.Addr16 == 14728);
                //if (n != null)
                //    n.Read(ZclTemperatureMeasurement.MeasuredValue, ZclTemperatureMeasurement.MinMeasuredValue, ZclTemperatureMeasurement.MaxMeasuredValue);
                break;
            //case ConsoleKey.N:
            //    foreach (var zn in Zigbee.NodeList)
            //        Zigbee.SendAsync(zn.NodeDescriptor());
            //    break;
            //case ConsoleKey.P:
            //    foreach (var zn in Zigbee.NodeList)
            //        Zigbee.SendAsync(zn.PowerDescriptor());
            //    break;
            //case ConsoleKey.I:
            //    foreach (var zn in Zigbee.NodeList)
            //        if (zn.Addr64 == 0)
            //            Zigbee.SendAsync(zn.IEEEDescriptor());
            //    break;
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