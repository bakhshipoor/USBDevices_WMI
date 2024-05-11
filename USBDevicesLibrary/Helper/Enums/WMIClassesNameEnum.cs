using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public static class WMIClassesNameEnum
{
    
    public enum ClassName
    {
        Win32_PnPEntity=0,
        Win32_USBController,
        Win32_DiskDrive,
        Win32_DiskDriveToDiskPartition,
        Win32_DiskPartition,
        Win32_LogicalDiskToPartition,
        Win32_LogicalDisk,
        Win32_NetworkAdapter,
        Win32_NetworkAdapterConfiguration,
        Win32_SerialPort,
        Win32_SerialPortConfiguration,
        Win32_USBHub,
        MY_USBDevices,
        
        MY_USBDevices_OLD,
    }
}
