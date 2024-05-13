using System.Management;
using static USBDevicesLibrary.LogicalDeviceGetParent;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

internal static class USBDevicesUpdateCollections
{
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
                    if (FilterDeviceStatus && USBDevicesFilterList.Count>0)
                    {
                        MY_USBDevice my_USBDevice = new(item);
                        foreach (USBDevicesFilter itemFilter in USBDevicesFilterList)
                        {
                            if (!string.IsNullOrEmpty(itemFilter.VID) && !string.IsNullOrEmpty(itemFilter.PID))
                            {
                                if (itemFilter.VID.Equals(my_USBDevice.VID, StringComparison.OrdinalIgnoreCase) && itemFilter.PID.Equals(my_USBDevice.PID, StringComparison.OrdinalIgnoreCase))
                                {
                                    Collection[ClassName.MY_USBDevices].Add(my_USBDevice);
                                }
                            }
                            else if (!string.IsNullOrEmpty(itemFilter.VID) && string.IsNullOrEmpty(itemFilter.PID))
                            {
                                if (itemFilter.VID.Equals(my_USBDevice.VID, StringComparison.OrdinalIgnoreCase))
                                {
                                    Collection[ClassName.MY_USBDevices].Add(my_USBDevice);
                                }
                            }
                            else if (string.IsNullOrEmpty(itemFilter.VID) && !string.IsNullOrEmpty(itemFilter.PID))
                            {
                                if (itemFilter.PID.Equals(my_USBDevice.PID,StringComparison.OrdinalIgnoreCase))
                                {
                                    Collection[ClassName.MY_USBDevices].Add(my_USBDevice);
                                }
                            }
                        }
                    }
                    else
                    {
                        Collection[ClassName.MY_USBDevices].Add(new MY_USBDevice(item));
                    }
                }
                findID = false;
            }
        }
    }

    public static void UpdateWMICollectionByName(ClassName className)
    {
        WMI_Collection[className] = WMI_Searcher[className].Get();
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

    internal static async Task UpdateCollectionsAsync()
    {
        Task[] updateWMICollectionsTask =
        [
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_PnPEntity)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_DiskDrive)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_DiskDriveToDiskPartition)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_DiskPartition)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_LogicalDiskToPartition)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_LogicalDisk)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_NetworkAdapter)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_NetworkAdapterConfiguration)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_SerialPort)),
            Task.Run(() => UpdateWMICollectionByName(ClassName.Win32_SerialPortConfiguration)),
        ];
        await Task.WhenAll(updateWMICollectionsTask);

        Task[] updateCollectionsTask =
        [
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_PnPEntity)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_DiskDrive)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_DiskDriveToDiskPartition)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_DiskPartition)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_LogicalDiskToPartition)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_LogicalDisk)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_NetworkAdapter)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_NetworkAdapterConfiguration)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_SerialPort)),
            Task.Run(() => UpdateCollectionByNameAsync(ClassName.Win32_SerialPortConfiguration)),
        ];
        await Task.WhenAll(updateCollectionsTask);
    }
}
