# BrandThus.Zigbee
C# zigbee interface using Conbee2

A basic example here:

```cs
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
                (ZclBasic.ManufacturerName + ZclBasic.ZCLVersion + ZclBasic.ApplicationVersion + 
                    ZclBasic.ModelIdentifier + ZclBasic.PowerSource).Read(n);
                break;
            case ConsoleKey.D6:
                //Get plug To Report each 10 seconds the On state
                n = GetPlug();
                await ZclOnOff.OnOff.ReportAsync(n, 10, 10);
                break;
        }
    }
}
```

# Background

It was quite challenging to find out how Zigbee works. I have used multiple other projects for inspiration like [ZigbeeNet](https://github.com/Mr-Markus/ZigbeeNet), [Zigbee2mqtt](https://github.com/Koenkk/zigbee2mqtt) and [Zigbee-herdsman](https://github.com/Koenkk/zigbee-herdsman)
The reason to write my own library was mainly that the other ones were very difficult to understand. The whole request response mechanism was hard to follow and seemed too complex for me. 
Another reason was that I had bought a few devices in China, which did not work (probably because of my lack of knowledge) so I set out to write something myself.

Code generators, seemed to be the right approach dealing with the many attributes and clusters of Zigbee. I found in the folder of my Dresden Elektronik application an Xml file which contained all the attributes and commands which they know of. This file is used as input for the code generator, and all Zcl clusters are generated automatically.
They can be found under the Dependancies/Analyzers/BrandThus.Zigbee.Tools
[<img src="generated files.png" alt="The generated cluster files">](generated files.png)

# Current development status 

For me this is a work in progress. The software does what it needs to do for me. There are however several area's which need to be improved in order to be fully functional. 
1) Discovery of nodes is very limited. All nodes are automaticallly added when they send information. All clusters are automatically loaded if they are used, either by the program itself, our by a node in the network.
2) Not all read/write operations have been tested, mainly because I do not have devices which send that information 
3) Other dongles

 
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