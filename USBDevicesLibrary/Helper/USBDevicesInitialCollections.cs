using System.Management;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

internal static class USBDevicesInitialCollections
{
    public static ThreadSafeDictionary<Enum, ThreadSafeObservableCollection<object>> Collection  { get; set; } = new();
    public static ThreadSafeDictionary<Enum, ObjectQuery> WMI_Query { get; set; } = new();
    public static ThreadSafeDictionary<Enum, ManagementObjectSearcher> WMI_Searcher { get; set; } = new();
    public static ThreadSafeDictionary<Enum, ManagementObjectCollection> WMI_Collection { get; set; } = new();
    public static List<USBDevicesFilter> USBDevicesFilterList { get; set; } = [];

    public static bool ConnectedEventStatus { get; set; }
    public static bool DisconnectedEventStatus { get; set; }
    public static bool ModifiedEventStatus { get; set; }
    public static bool FilterDeviceStatus { get; set; }

    public static void Init_Collection_Dictionary()
    {
        Collection.TryAdd(ClassName.Win32_DiskDrive, []);
        Collection.TryAdd(ClassName.Win32_DiskDriveToDiskPartition, []);
        Collection.TryAdd(ClassName.Win32_DiskPartition, []);
        Collection.TryAdd(ClassName.Win32_LogicalDiskToPartition, []);
        Collection.TryAdd(ClassName.Win32_LogicalDisk, []);
        Collection.TryAdd(ClassName.Win32_NetworkAdapter, []);
        Collection.TryAdd(ClassName.Win32_NetworkAdapterConfiguration, []);
        Collection.TryAdd(ClassName.Win32_SerialPort, []);
        Collection.TryAdd(ClassName.Win32_SerialPortConfiguration, []);
        Collection.TryAdd(ClassName.MY_USBDevices, []);
        Collection.TryAdd(ClassName.Win32_PnPEntity, []);
        Collection.TryAdd(ClassName.MY_USBDevices_OLD, []);
    }

    public static void Init_WMI_Dictionary()
    {
        WMI_Query.TryAdd(ClassName.Win32_PnPEntity, new ObjectQuery(@"SELECT * FROM Win32_PnPEntity"));
        WMI_Query.TryAdd(ClassName.Win32_DiskDrive, new ObjectQuery("SELECT * FROM Win32_DiskDrive"));
        WMI_Query.TryAdd(ClassName.Win32_DiskDriveToDiskPartition, new ObjectQuery("SELECT * FROM Win32_DiskDriveToDiskPartition"));
        WMI_Query.TryAdd(ClassName.Win32_DiskPartition, new ObjectQuery("SELECT * FROM Win32_DiskPartition"));
        WMI_Query.TryAdd(ClassName.Win32_LogicalDiskToPartition, new ObjectQuery("SELECT * FROM Win32_LogicalDiskToPartition"));
        WMI_Query.TryAdd(ClassName.Win32_LogicalDisk, new ObjectQuery("SELECT * FROM Win32_LogicalDisk"));
        WMI_Query.TryAdd(ClassName.Win32_NetworkAdapter, new ObjectQuery("SELECT * FROM Win32_NetworkAdapter"));
        WMI_Query.TryAdd(ClassName.Win32_NetworkAdapterConfiguration, new ObjectQuery("SELECT * FROM  Win32_NetworkAdapterConfiguration"));
        WMI_Query.TryAdd(ClassName.Win32_SerialPort, new ObjectQuery("SELECT * FROM Win32_SerialPort"));
        WMI_Query.TryAdd(ClassName.Win32_SerialPortConfiguration, new ObjectQuery("SELECT * FROM  Win32_SerialPortConfiguration"));
        WMI_Query.TryAdd(ClassName.MY_USBDevices, new ObjectQuery(@"SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'usb\\%' AND NOT (Service LIKE '%usbhub%')"));

        WMI_Searcher.TryAdd(ClassName.Win32_PnPEntity, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_PnPEntity]));
        WMI_Searcher.TryAdd(ClassName.Win32_DiskDrive, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_DiskDrive]));
        WMI_Searcher.TryAdd(ClassName.Win32_DiskDriveToDiskPartition, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_DiskDriveToDiskPartition]));
        WMI_Searcher.TryAdd(ClassName.Win32_DiskPartition, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_DiskPartition]));
        WMI_Searcher.TryAdd(ClassName.Win32_LogicalDiskToPartition, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_LogicalDiskToPartition]));
        WMI_Searcher.TryAdd(ClassName.Win32_LogicalDisk, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_LogicalDisk]));
        WMI_Searcher.TryAdd(ClassName.Win32_NetworkAdapter, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_NetworkAdapter]));
        WMI_Searcher.TryAdd(ClassName.Win32_NetworkAdapterConfiguration, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_NetworkAdapterConfiguration]));
        WMI_Searcher.TryAdd(ClassName.Win32_SerialPort, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_SerialPort]));
        WMI_Searcher.TryAdd(ClassName.Win32_SerialPortConfiguration, new ManagementObjectSearcher(WMI_Query[ClassName.Win32_SerialPortConfiguration]));
        WMI_Searcher.TryAdd(ClassName.MY_USBDevices, new ManagementObjectSearcher(WMI_Query[ClassName.MY_USBDevices]));

        WMI_Collection.TryAdd(ClassName.Win32_PnPEntity, WMI_Searcher[ClassName.Win32_PnPEntity].Get());
        WMI_Collection.TryAdd(ClassName.Win32_DiskDrive, WMI_Searcher[ClassName.Win32_DiskDrive].Get());
        WMI_Collection.TryAdd(ClassName.Win32_DiskDriveToDiskPartition, WMI_Searcher[ClassName.Win32_DiskDriveToDiskPartition].Get());
        WMI_Collection.TryAdd(ClassName.Win32_DiskPartition, WMI_Searcher[ClassName.Win32_DiskPartition].Get());
        WMI_Collection.TryAdd(ClassName.Win32_LogicalDiskToPartition, WMI_Searcher[ClassName.Win32_LogicalDiskToPartition].Get());
        WMI_Collection.TryAdd(ClassName.Win32_LogicalDisk, WMI_Searcher[ClassName.Win32_LogicalDisk].Get());
        WMI_Collection.TryAdd(ClassName.Win32_NetworkAdapter, WMI_Searcher[ClassName.Win32_NetworkAdapter].Get());
        WMI_Collection.TryAdd(ClassName.Win32_NetworkAdapterConfiguration, WMI_Searcher[ClassName.Win32_NetworkAdapterConfiguration].Get());
        WMI_Collection.TryAdd(ClassName.Win32_SerialPort, WMI_Searcher[ClassName.Win32_SerialPort].Get());
        WMI_Collection.TryAdd(ClassName.Win32_SerialPortConfiguration, WMI_Searcher[ClassName.Win32_SerialPortConfiguration].Get());
        WMI_Collection.TryAdd(ClassName.MY_USBDevices, WMI_Searcher[ClassName.MY_USBDevices].Get());
    }

}
