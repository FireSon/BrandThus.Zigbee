using BrandThus.Zigbee.Conbee;
using BrandThus.Zigbee.Clusters;
using Microsoft.Extensions.Configuration;
using BrandThus.Zigbee;


await Console.Out.WriteLineAsync("Zigbee Test program");

#region Get configuration
var environment = args.Length == 1 ? args[0] : "Production";
var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json")
     .AddJsonFile($"appsettings.{environment}.json", optional: true);
var config = configuration.Build();
#endregion

var Zigbee = new ConbeeManager(config, new());
Zigbee.OnLine = async () => await Console.Out.WriteLineAsync("Online");
//Program logging
Zigbee.LogEvent = async (type, file, mbr, line, msg) => await Console.Out.WriteLineAsync($"{DateTime.Now} {mbr} {line} {msg}");
//Attribute has changed
Zigbee.OnUpdate = async (n, a, ep, v) => await Console.Out.WriteLineAsync($"{DateTime.Now} => Node:0x{n.Addr16:X4} Attr:{a.Name} Ep:{ep} Value:{v}");

ushort interval = 10;

var plug = Zigbee.CreateNode((ushort)Convert.ToInt32("0x6a5c", 16));
var temp = Zigbee.CreateNode((ushort)Convert.ToInt32("0x3988", 16));

while (true)
{
    if (Console.KeyAvailable)
    {
        await Console.Out.WriteLineAsync();
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.C:
                Console.Clear();
                break;
            case ConsoleKey.D1:
                //Turn plug On
                await plug.On().SendAsync();
                break;
            case ConsoleKey.D2:
                //Turn plug Off
                await plug.Off().SendAsync();
                break;
            case ConsoleKey.D3:
                //Get plug NodeDescriptor
                await plug.NodeDescriptor().SendAsync();
                await plug.PowerDescriptor().SendAsync();
                await plug.SimpleDescriptor().SendAsync();
                await ZclOnOff.OnOff.ReportAsync(plug, 0, 0);
                break;
            case ConsoleKey.D4:
                //Read the plug ManufacturerName
                await ZclBasic.ManufacturerName.ReadAsync(plug);
                break;
            case ConsoleKey.D5:
                //Read multiple plug attributes
                (ZclOnOff.OnOff + ZclOnOff.OnTime).Read(plug);
                (ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion +
                    ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(plug);
                break;
            case ConsoleKey.D6:
                //Get plug To Report each 10 seconds the On state
                await ZclOnOff.OnOff.ReportAsync(plug, interval, interval);
                interval = interval != 0 ? (ushort)0 : interval;
                break;

            case ConsoleKey.D7:
                //Get plug To Report each 10 seconds the On state
                await ZclTemperatureMeasurement.MeasuredValue.ReportAsync(plug, 10, 10, 1);
                break;
            case ConsoleKey.D8:
                //Get plug To Report each 10 seconds the On state
                await ZclTemperatureMeasurement.MeasuredValue.ReportAsync(plug, 0, 0, 0);
                break;

            case ConsoleKey.Enter: return;
        }
    }
    await Console.Out.WriteAsync(".");
    await Task.Delay(1000);
}

