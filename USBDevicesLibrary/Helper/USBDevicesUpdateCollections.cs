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

    public static void UpdateCollection_Win32_PnPEntity()
    {
        //UpdateCollectionByName(ClassName.Win32_PnPEntity);
        RunUpdateCollectionByNameAsync(ClassName.Win32_PnPEntity);
    }

    public static void UpdateCollection_Win32_DiskDrive()
    {
        //UpdateCollectionByName(ClassName.Win32_DiskDrive);
        RunUpdateCollectionByNameAsync(ClassName.Win32_DiskDrive);
    }

    public static void UpdateCollection_Win32_DiskDriveToDiskPartition()
    {
        //UpdateCollectionByName(ClassName.Win32_DiskDriveToDiskPartition);
        RunUpdateCollectionByNameAsync(ClassName.Win32_DiskDriveToDiskPartition);
    }

    public static void UpdateCollection_Win32_DiskPartition()
    {
        //UpdateCollectionByName(ClassName.Win32_DiskPartition);
        RunUpdateCollectionByNameAsync(ClassName.Win32_DiskPartition);
    }

    public static void UpdateCollection_Win32_LogicalDiskToPartition()
    {
        //UpdateCollectionByName(ClassName.Win32_LogicalDiskToPartition);
        RunUpdateCollectionByNameAsync(ClassName.Win32_LogicalDiskToPartition);
    }

    public static void UpdateCollection_Win32_LogicalDisk()
    {
        //UpdateCollectionByName(ClassName.Win32_LogicalDisk);
        RunUpdateCollectionByNameAsync(ClassName.Win32_LogicalDisk);
    }

    public static void UpdateCollection_Win32_NetworkAdapter()
    {
        //UpdateCollectionByName(ClassName.Win32_NetworkAdapter);
        RunUpdateCollectionByNameAsync(ClassName.Win32_NetworkAdapter);
    }

    public static void UpdateCollection_Win32_NetworkAdapterConfiguration()
    {
        //UpdateCollectionByName(ClassName.Win32_NetworkAdapterConfiguration);
        RunUpdateCollectionByNameAsync(ClassName.Win32_NetworkAdapterConfiguration);
    }

    public static void UpdateCollection_Win32_SerialPort()
    {
        //UpdateCollectionByName(ClassName.Win32_SerialPort);
        RunUpdateCollectionByNameAsync(ClassName.Win32_SerialPort);
    }

    public static void UpdateCollection_Win32_SerialPortConfiguration()
    {
        //UpdateCollectionByName(ClassName.Win32_SerialPortConfiguration);
        RunUpdateCollectionByNameAsync(ClassName.Win32_SerialPortConfiguration);
    }

    public static void UpdateCollectionByName(ClassName className)
    {
        Type? type = Type.GetType($"USBDevicesLibrary.{className}, USBDevicesLibrary");
        if (type == null) return;
        if (WMI_Collection[className] == null) return;
        Collection[className].Clear();
        foreach (ManagementObject item in WMI_Collection[className].Cast<ManagementObject>())
        {
            object? entity = Activator.CreateInstance(type, new object[] { item });
            if (entity != null)
                Collection[className].Add( entity);
        }
    }

    public static async void RunUpdateCollectionByNameAsync(ClassName className)
    {
        await UpdateCollectionByNameAsync(className);
    }

    public static async Task UpdateCollectionByNameAsync(ClassName className)
    {
        Type? type = Type.GetType($"USBDevicesLibrary.{className}, USBDevicesLibrary");
        if (type == null) return;
        if (WMI_Collection[className] == null) return;
        Collection[className].Clear();
        List<Task> tasks = [];
        foreach (ManagementObject item in WMI_Collection[className].Cast<ManagementObject>())
        {
            object? entity = Activator.CreateInstance(type, new object[] { item });
            if (entity != null)
                tasks.Add(Task.Run(() => Collection[className].Add(entity)));
        }
        await Task.WhenAll(tasks);
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
