# BrandThus.Zigbee
C# zigbee interface using Conbee2

An example using an Ikea plug:

```cs
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
```

# Background

It was quite challenging to find out how Zigbee works. I have used multiple other projects for inspiration like [ZigbeeNet](https://github.com/Mr-Markus/ZigbeeNet), [Zigbee2mqtt](https://github.com/Koenkk/zigbee2mqtt) and [Zigbee-herdsman](https://github.com/Koenkk/zigbee-herdsman)
The reason to write my own library was mainly that the other ones were very difficult to understand. The whole request response mechanism was hard to follow and seemed too complex for me. 
Another reason was that I had bought a few devices in China, which did not work (probably because of my lack of knowledge) so I set out to write something myself.

Code generators, seemed to be the right approach dealing with the many attributes and clusters of Zigbee. I found in the folder of my Dresden Elektronik application an Xml file which contained all the attributes and commands which they know of. This file is used as input for the code generator, and all Zcl clusters are generated automatically.
They can be found under the Dependancies/Analyzers/BrandThus.Zigbee.Tools

<img src="generated files.png" alt="The generated cluster files">

# Current development status 

For me this is a work in progress. The software does what it needs to do for me. There are however several area's which need to be improved in order to be fully functional. 
1) Discovery of nodes is very limited. All nodes are automaticallly added when they send information. All clusters are automatically loaded if they are used, either by the program itself, our by a node in the network.
2) Not all read/write operations have been tested, mainly because I do not have devices which send that information 
3) Other dongles
4) The ReadAsync does not return the read value. An event is raised when the attribute is read with the correct value.

 
# ConBeeII

BrandThus.Zigbee is developed using a ConBeeII usb stick from Dresden Elektronik

Source: [https://www.phoscon.de/en/conbee2](https://www.phoscon.de/en/conbee2)

It should be straight forward to implement it for other devices as well, but I do not have the hardware...


# Contributing

Feel free to open an issue if you have any idea or enhancement. If you want to implement on code create a fork and open a pull request.


# ZigBee Documentation

Some documentation used to create parts of this framework is copyright © ZigBee Alliance, Inc. All rights Reserved. The following copyright notice is copied from the ZigBee documentation.

Elements of ZigBee Alliance specifications may be subject to third party intellectual property rights, including without limitation, patent, copyright or trademark rights (such a third party may or may not be a member of ZigBee). ZigBee is not responsible and shall not be held responsible in any manner for identifying or failing to identify any or all such third party intellectual property rights.

No right to use any ZigBee name, logo or trademark is conferred herein. Use of any ZigBee name, logo or trademark requires membership in the ZigBee Alliance and compliance with the ZigBee Logo and Trademark Policy and related ZigBee policies.

This document and the information contained herein are provided on an “AS IS” basis and ZigBee DISCLAIMS ALL WARRANTIES EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO (A) ANY WARRANTY THAT THE USE OF THE INFORMATION HEREIN WILL NOT INFRINGE ANY RIGHTS OF THIRD PARTIES (INCLUDING WITHOUT LIMITATION ANY INTELLECTUAL PROPERTY RIGHTS INCLUDING PATENT, COPYRIGHT OR TRADEMARK RIGHTS) OR (B) ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, TITLE OR NONINFRINGEMENT. IN NO EVENT WILL ZIGBEE BE LIABLE FOR ANY LOSS OF PROFITS, LOSS OF BUSINESS, LOSS OF USE OF DATA, INTERRUPTION OF BUSINESS, OR FOR ANY OTHER DIRECT, INDIRECT, SPECIAL OR EXEMPLARY, INCIDENTIAL, PUNITIVE OR CONSEQUENTIAL DAMAGES OF ANY KIND, IN CONTRACT OR IN TORT, IN CONNECTION WITH THIS DOCUMENT OR THE INFORMATION CONTAINED HEREIN, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH LOSS OR DAMAGE.

All Company, brand and product names may be trademarks that are the sole property of their respective owners.