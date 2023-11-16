using BrandThus.Zigbee.Conbee;
using BrandThus.Zigbee.Clusters;
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
            case ConsoleKey.D1:
                int value = Convert.ToInt32("0x6a5c", 16);
                var n = Zigbee.CreateNode((ushort)value);
                n.On().SendAsync();
                break;
            case ConsoleKey.D2:
                //
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                n.Off().SendAsync();
                break;
            case ConsoleKey.D3:
                //
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                n.NodeDescriptor().SendAsync();
                //(ZclOnOff.OnOff + ZclOnOff.OnTime).Read(n);
                //(ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion + ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(n);
                break;
            case ConsoleKey.D6:
                //
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                ZclOnOff.OnOff.ReportAsync(n, 10, 10);
                //(ZclOnOff.OnOff + ZclOnOff.OnTime).Read(n);
                //(ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion + ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(n);
                break;
            case ConsoleKey.D4:
                //
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                ZclBasic.ManufacturerName.ReadAsync(n);
                //(ZclOnOff.OnOff + ZclOnOff.OnTime).Read(n);
                //(ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion + ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(n);
                break;
            case ConsoleKey.D5:
                //x
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
                ZclOnOff.OnOff.Report(n, 0, 0);
                ZclOnOff.OnOff.Read(n);
                ZclOnOff.OnTime.Write(n, 0);
                ZclOnOff.OnOff.Read(n);
                ZclOnOff.OnTime.Report(n, 0, 0, 1);
                //var v = n.Read(ZclOnOff.OnTime);
                //ZclOnOff.OnTime.Write(n, 1);
                //ZclOnOff.OnTime.Read(n, ZclOnOff.OffWaitTime);
                break;
            case ConsoleKey.T:
                //
                value = Convert.ToInt32("0x6a5c", 16);
                n = Zigbee.CreateNode((ushort)value);
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