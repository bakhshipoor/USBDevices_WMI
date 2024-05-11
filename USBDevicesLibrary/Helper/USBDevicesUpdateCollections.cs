using System.Management;
using static USBDevicesLibrary.LogicalDeviceGetParent;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public static class USBDevicesUpdateCollections
{
    public static void UpdateWMICollection_MY_USBDevices()
    {
        WMI_Collection[ClassName.MY_USBDevices] = WMI_Searcher[ClassName.MY_USBDevices].Get();
    }

    public static void UpdateWMICollection_Win32_PnPEntity()
    {
        WMI_Collection[ClassName.Win32_PnPEntity] = WMI_Searcher[ClassName.Win32_PnPEntity].Get();
    }

    public static void UpdateWMICollection_Win32_DiskDrive()
    {
        WMI_Collection[ClassName.Win32_DiskDrive] = WMI_Searcher[ClassName.Win32_DiskDrive].Get();
    }

    public static void UpdateWMICollection_Win32_DiskDriveToDiskPartition()
    {
        WMI_Collection[ClassName.Win32_DiskDriveToDiskPartition] = WMI_Searcher[ClassName.Win32_DiskDriveToDiskPartition].Get();
    }

    public static void UpdateWMICollection_Win32_DiskPartition()
    {
        WMI_Collection[ClassName.Win32_DiskPartition] = WMI_Searcher[ClassName.Win32_DiskPartition].Get();
    }

    public static void UpdateWMICollection_Win32_LogicalDiskToPartition()
    {
        WMI_Collection[ClassName.Win32_LogicalDiskToPartition] = WMI_Searcher[ClassName.Win32_LogicalDiskToPartition].Get();
    }

    public static void UpdateWMICollection_Win32_LogicalDisk()
    {
        WMI_Collection[ClassName.Win32_LogicalDisk] = WMI_Searcher[ClassName.Win32_LogicalDisk].Get();
    }

    public static void UpdateWMICollection_Win32_NetworkAdapter()
    {
        WMI_Collection[ClassName.Win32_NetworkAdapter] = WMI_Searcher[ClassName.Win32_NetworkAdapter].Get();
    }

    public static void UpdateWMICollection_Win32_NetworkAdapterConfiguration()
    {
        WMI_Collection[ClassName.Win32_NetworkAdapterConfiguration] = WMI_Searcher[ClassName.Win32_NetworkAdapterConfiguration].Get();
    }

    public static void UpdateWMICollection_Win32_SerialPort()
    {
        WMI_Collection[ClassName.Win32_SerialPort] = WMI_Searcher[ClassName.Win32_SerialPort].Get();
    }

    public static void UpdateWMICollection_Win32_SerialPortConfiguration()
    {
        WMI_Collection[ClassName.Win32_SerialPortConfiguration] = WMI_Searcher[ClassName.Win32_SerialPortConfiguration].Get();
    }




    public static void UpdateCollection_MY_USBDevices()
    {
        List<string> devicesID = [];
        if (WMI_Collection[ClassName.MY_USBDevices] != null)
        {
            Collection[ClassName.MY_USBDevices_OLD].Clear();
            foreach (var item in Collection[ClassName.MY_USBDevices])
                Collection[ClassName.MY_USBDevices_OLD].Add(item);
            Collection[ClassName.MY_USBDevices].Clear();
            foreach (ManagementObject item in WMI_Collection[ClassName.MY_USBDevices].Cast<ManagementObject>())
            {
                string? itemDeviceID = item["DeviceID"] as string;
                bool findID = false;
                if (!string.IsNullOrEmpty(itemDeviceID))
                {
                    string? itemParentDeviceID = GetParent(itemDeviceID);
                    if (!string.IsNullOrEmpty(itemParentDeviceID))
                    {
                        foreach (string id in devicesID)
                        {
                            if (itemParentDeviceID == id)
                            {
                                findID = true;
                                break;
                            }
                        }
                    }
                }
                if (!findID && !string.IsNullOrEmpty(itemDeviceID))
                {
                    devicesID.Add(itemDeviceID);
                    
                    Collection[ClassName.MY_USBDevices].Add(new MY_USBDevice(item));
                }
                findID = false;
            }

        }
    }

    public static async void UpdateCollection_Win32_PnPEntity()
    {
        if (WMI_Collection[ClassName.Win32_PnPEntity] != null)
        {
            Collection[ClassName.Win32_PnPEntity].Clear();
            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_PnPEntity].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_PnPEntity].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_PnPEntity].Add(new Win32_PnPEntity(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_DiskDrive()
    {
        if (WMI_Collection[ClassName.Win32_DiskDrive] != null)
        {
            Collection[ClassName.Win32_DiskDrive].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskDrive])
            //    Collection[ClassName.Win32_DiskDrive].Add(new Win32_DiskDrive(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_DiskDrive].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskDrive].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_DiskDrive].Add(new Win32_DiskDrive(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_DiskDriveToDiskPartition()
    {
        if (WMI_Collection[ClassName.Win32_DiskDriveToDiskPartition] != null)
        {
            Collection[ClassName.Win32_DiskDriveToDiskPartition].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskDriveToDiskPartition])
            //    Collection[ClassName.Win32_DiskDriveToDiskPartition].Add(new Win32_DiskDriveToDiskPartition(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_DiskDriveToDiskPartition].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskDriveToDiskPartition].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_DiskDriveToDiskPartition].Add(new Win32_DiskDriveToDiskPartition(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_DiskPartition()
    {
        if (WMI_Collection[ClassName.Win32_DiskPartition] != null)
        {
            Collection[ClassName.Win32_DiskPartition].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskPartition])
            //    Collection[ClassName.Win32_DiskPartition].Add(new Win32_DiskPartition(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_DiskPartition].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_DiskPartition].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_DiskPartition].Add(new Win32_DiskPartition(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_LogicalDiskToPartition()
    {
        if (WMI_Collection[ClassName.Win32_LogicalDiskToPartition] != null)
        {
            Collection[ClassName.Win32_LogicalDiskToPartition].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_LogicalDiskToPartition])
            //    Collection[ClassName.Win32_LogicalDiskToPartition].Add(new Win32_LogicalDiskToPartition(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_LogicalDiskToPartition].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_LogicalDiskToPartition].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_LogicalDiskToPartition].Add(new Win32_LogicalDiskToPartition(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_LogicalDisk()
    {
        if (WMI_Collection[ClassName.Win32_LogicalDisk] != null)
        {
            Collection[ClassName.Win32_LogicalDisk].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_LogicalDisk])
            //    Collection[ClassName.Win32_LogicalDisk].Add(new Win32_LogicalDisk(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_LogicalDisk].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_LogicalDisk].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_LogicalDisk].Add(new Win32_LogicalDisk(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_NetworkAdapter()
    {
        if (WMI_Collection[ClassName.Win32_NetworkAdapter] != null)
        {
            Collection[ClassName.Win32_NetworkAdapter].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_NetworkAdapter])
            //    Collection[ClassName.Win32_NetworkAdapter].Add(new Win32_NetworkAdapter(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_NetworkAdapter].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_NetworkAdapter].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_NetworkAdapter].Add(new Win32_NetworkAdapter(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_NetworkAdapterConfiguration()
    {
        if (WMI_Collection[ClassName.Win32_NetworkAdapterConfiguration] != null )
        {
            Collection[ClassName.Win32_NetworkAdapterConfiguration].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_NetworkAdapterConfiguration])
            //    Collection[ClassName.Win32_NetworkAdapterConfiguration].Add(new Win32_NetworkAdapterConfiguration(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_NetworkAdapterConfiguration].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_NetworkAdapterConfiguration].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_NetworkAdapterConfiguration].Add(new Win32_NetworkAdapterConfiguration(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_SerialPort()
    {
        if (WMI_Collection[ClassName.Win32_SerialPort] != null)
        {
            Collection[ClassName.Win32_SerialPort].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_SerialPort])
            //    Collection[ClassName.Win32_SerialPort].Add(new Win32_SerialPort(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_SerialPort].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_SerialPort].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_SerialPort].Add(new Win32_SerialPort(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    public static async void UpdateCollection_Win32_SerialPortConfiguration()
    {
        if (WMI_Collection[ClassName.Win32_SerialPortConfiguration] != null)
        {
            Collection[ClassName.Win32_SerialPortConfiguration].Clear();
            //foreach (ManagementObject item in WMI_Collection[ClassName.Win32_SerialPortConfiguration])
            //    Collection[ClassName.Win32_SerialPortConfiguration].Add(new Win32_SerialPortConfiguration(item));

            Task[] tasks = new Task[WMI_Collection[ClassName.Win32_SerialPortConfiguration].Count];
            int counter = 0;
            foreach (ManagementObject item in WMI_Collection[ClassName.Win32_SerialPortConfiguration].Cast<ManagementObject>())
            {
                tasks[counter] = Task.Run(() => Collection[ClassName.Win32_SerialPortConfiguration].Add(new Win32_SerialPortConfiguration(item)));
                counter++;
            }
            await Task.WhenAll(tasks);
        }
    }

    internal static async Task UpdateCollections()
    {
        Task[] InitialTasks =
        [
            Task.Run(UpdateWMICollection_Win32_PnPEntity),
            Task.Run(UpdateWMICollection_Win32_DiskDrive),
            Task.Run(UpdateWMICollection_Win32_DiskDriveToDiskPartition),
            Task.Run(UpdateWMICollection_Win32_DiskPartition),
            Task.Run(UpdateWMICollection_Win32_LogicalDiskToPartition),
            Task.Run(UpdateWMICollection_Win32_LogicalDisk),
            Task.Run(UpdateWMICollection_Win32_NetworkAdapter),
            Task.Run(UpdateWMICollection_Win32_NetworkAdapterConfiguration),
            Task.Run(UpdateWMICollection_Win32_SerialPort),
            Task.Run(UpdateWMICollection_Win32_SerialPortConfiguration),
        ];
        await Task.WhenAll(InitialTasks);

        Task[] InitialTasks2 =
        [
            Task.Run(UpdateCollection_Win32_PnPEntity),
            Task.Run(UpdateCollection_Win32_DiskDrive),
            Task.Run(UpdateCollection_Win32_DiskDriveToDiskPartition),
            Task.Run(UpdateCollection_Win32_DiskPartition),
            Task.Run(UpdateCollection_Win32_LogicalDiskToPartition),
            Task.Run(UpdateCollection_Win32_LogicalDisk),
            Task.Run(UpdateCollection_Win32_NetworkAdapter),
            Task.Run(UpdateCollection_Win32_NetworkAdapterConfiguration),
            Task.Run(UpdateCollection_Win32_SerialPort),
            Task.Run(UpdateCollection_Win32_SerialPortConfiguration),
        ];
        await Task.WhenAll(InitialTasks2);
    }

    internal static MY_USBDevice AddUSBDeviceToCollection(MY_USBDevice my_USBDevice)
    {
        MY_USBDevice usbDevice = new(my_USBDevice);
        USBDevicesCollection.TryAdd(usbDevice, usbDevice);
        return usbDevice;
    }

}
