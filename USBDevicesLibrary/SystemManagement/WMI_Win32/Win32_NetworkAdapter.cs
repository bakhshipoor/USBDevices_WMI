using System.Globalization;
using System.Management;
using System.Reflection;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;
using static USBDevicesLibrary.WMIClassesNameEnum;



namespace USBDevicesLibrary;

public class Win32_NetworkAdapter : CIM_NetworkAdapter
{
    public Win32_NetworkAdapter()
    {

    }

    public Win32_NetworkAdapter(Win32_NetworkAdapter win32_NetworkAdapter) : this()
    {
        RetrieveValues(win32_NetworkAdapter);
    }

    public Win32_NetworkAdapter(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public string? AdapterType {  get; set; }
    public UInt16? AdapterTypeID {  get; set; }
    public string? GUID {  get; set; }
    public UInt32? Index {  get; set; }
    public bool? Installed {  get; set; }
    public UInt32? InterfaceIndex {  get; set; }
    public string? MACAddress {  get; set; }
    public string? Manufacturer {  get; set; }
    public UInt32? MaxNumberControlled {  get; set; }
    public string? NetConnectionID {  get; set; }
    public UInt16? NetConnectionStatus {  get; set; }
    public bool? NetEnabled {  get; set; }
    public bool? PhysicalAdapter {  get; set; }
    public string? ProductName {  get; set; }
    public string? ServiceName {  get; set; }
    public DateTime? TimeOfLastReset {  get; set; }

    //Extra

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_NetworkAdapter win32_NetworkAdapter = (Win32_NetworkAdapter)managementClass;
        AdapterType = win32_NetworkAdapter.AdapterType;
        AdapterTypeID = win32_NetworkAdapter.AdapterTypeID;
        GUID = win32_NetworkAdapter.GUID;
        Index = win32_NetworkAdapter.Index;
        Installed = win32_NetworkAdapter.Installed;
        InterfaceIndex = win32_NetworkAdapter.InterfaceIndex;
        MACAddress = win32_NetworkAdapter.MACAddress;
        Manufacturer = win32_NetworkAdapter.Manufacturer;
        MaxNumberControlled = win32_NetworkAdapter.MaxNumberControlled;
        NetConnectionID = win32_NetworkAdapter.NetConnectionID;
        NetConnectionStatus = win32_NetworkAdapter.NetConnectionStatus;
        NetEnabled = win32_NetworkAdapter.NetEnabled;
        PhysicalAdapter = win32_NetworkAdapter.PhysicalAdapter;
        ProductName = win32_NetworkAdapter.ProductName;
        ServiceName = win32_NetworkAdapter.ServiceName;
        TimeOfLastReset = win32_NetworkAdapter.TimeOfLastReset;
        if (ParentUSBDevice != null && DeviceID!=null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.NetworkAdapter))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.NetworkAdapter, []);
            ParentUSBDevice.Interfaces[InterfaceName.NetworkAdapter].Add(Name);
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.MACAddress))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.MACAddress, []);
            ParentUSBDevice.Interfaces[InterfaceName.MACAddress].Add(string.Format("{0}, {1}", Name, MACAddress));
            if (Collection[ClassName.Win32_NetworkAdapterConfiguration] != null)
            {
                foreach (Win32_NetworkAdapterConfiguration item in Collection[ClassName.Win32_NetworkAdapterConfiguration].Cast<Win32_NetworkAdapterConfiguration>())
                {
                    if (Convert.ToUInt32(DeviceID) == item.Index)
                    {
                        item.ParentUSBDevice = ParentUSBDevice;
                        Add(new Win32_NetworkAdapterConfiguration(item));
                    }
                }
            }
        }
    }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);

        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property != null && property.Value != null)
            {
                switch (property.Name)
                {
                    case nameof(AdapterType):
                        AdapterType = (string)property.Value;
                        break;
                    case nameof(AdapterTypeID):
                        AdapterTypeID = (UInt16)property.Value;
                        break;
                    case nameof(GUID):
                        GUID = (string)property.Value;
                        break;
                    case nameof(Index):
                        Index = (UInt32)property.Value;
                        break;
                    case nameof(Installed):
                        Installed = (bool)property.Value;
                        break;
                    case nameof(InterfaceIndex):
                        InterfaceIndex = (UInt32)property.Value;
                        break;
                    case nameof(MACAddress):
                        MACAddress = (string)property.Value;
                        break;
                    case nameof(Manufacturer):
                        Manufacturer = (string)property.Value;
                        break;
                    case nameof(MaxNumberControlled):
                        MaxNumberControlled = (UInt32)property.Value;
                        break;
                    case nameof(NetConnectionID):
                        NetConnectionID = (string)property.Value;
                        break;
                    case nameof(NetConnectionStatus):
                        NetConnectionStatus = (UInt16)property.Value;
                        break;
                    case nameof(NetEnabled):
                        NetEnabled = (bool)property.Value;
                        break;
                    case nameof(PhysicalAdapter):
                        PhysicalAdapter = (bool)property.Value;
                        break;
                    case nameof(ProductName):
                        ProductName = (string)property.Value;
                        break;
                    case nameof(ServiceName):
                        ServiceName = (string)property.Value;
                        break;
                    case nameof(TimeOfLastReset):
                        TimeOfLastReset = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                }
            }
        });
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(AdapterType), Value = AdapterType },
            new PnPEntityToList { Name = nameof(AdapterTypeID), Value = AdapterTypeID },
            new PnPEntityToList { Name = nameof(GUID), Value = GUID },
            new PnPEntityToList { Name = nameof(Index), Value = Index },
            new PnPEntityToList { Name = nameof(Installed), Value = Installed },
            new PnPEntityToList { Name = nameof(InterfaceIndex), Value = InterfaceIndex },
            new PnPEntityToList { Name = nameof(MACAddress), Value = MACAddress },
            new PnPEntityToList { Name = nameof(Manufacturer), Value = Manufacturer },
            new PnPEntityToList { Name = nameof(MaxNumberControlled), Value = MaxNumberControlled },
            new PnPEntityToList { Name = nameof(NetConnectionID), Value = NetConnectionID },
            new PnPEntityToList { Name = nameof(NetConnectionStatus), Value = NetConnectionStatus },
            new PnPEntityToList { Name = nameof(NetEnabled), Value = NetEnabled },
            new PnPEntityToList { Name = nameof(PhysicalAdapter), Value = PhysicalAdapter },
            new PnPEntityToList { Name = nameof(ProductName), Value = ProductName },
            new PnPEntityToList { Name = nameof(ServiceName), Value = ServiceName },
            new PnPEntityToList { Name = nameof(TimeOfLastReset), Value = TimeOfLastReset },
        ];
        return filedsToList;
    }
}
