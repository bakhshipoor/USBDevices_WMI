using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public static class USBDevicesInterfacesEnum
{
    public enum InterfaceName
    {
        DiskDrive = 0,
        Net,
        Ports,
        USB,
        DiskPartition,
        LogicalDisk,
        NetworkAdapter,
        MACAddress,
        IPAddress,
        SerialPort,
        SerialPortConfiguration,
    }
}
