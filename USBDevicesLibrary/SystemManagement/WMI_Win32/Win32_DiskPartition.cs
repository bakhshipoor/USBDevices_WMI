using System.Management;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public class Win32_DiskPartition : CIM_DiskPartition
{
    public Win32_DiskPartition()
    {
        IdentifyingDescriptions = [];
    }

    public Win32_DiskPartition(Win32_DiskPartition win32_DiskPartition) : this()
    {
        RetrieveValues(win32_DiskPartition);
    }

    public Win32_DiskPartition(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public UInt16? AdditionalAvailability {  get; set; }
    public List<string> IdentifyingDescriptions { get; set; }
    public UInt64? MaxQuiesceTime { get; set; }
    public UInt64? OtherIdentifyingInfo { get; set; }
    public UInt64? PowerOnHours { get; set; }
    public UInt64? TotalPowerOnHours { get; set; }
    public bool? BootPartition { get; set; }
    public UInt32? DiskIndex { get; set; }
    public UInt32? HiddenSectors { get; set; }
    public UInt32? Index { get; set; }
    public bool? RewritePartition { get; set; }
    public UInt64? Size { get; set; }
    public UInt64? StartingOffset { get; set; }
    public string? Type { get; set; }

    // Extra


    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_DiskPartition win32_DiskPartition = (Win32_DiskPartition)managementClass;
        AdditionalAvailability = win32_DiskPartition.AdditionalAvailability;
        IdentifyingDescriptions = win32_DiskPartition.IdentifyingDescriptions;
        MaxQuiesceTime = win32_DiskPartition.MaxQuiesceTime;
        OtherIdentifyingInfo = win32_DiskPartition.OtherIdentifyingInfo;
        PowerOnHours = win32_DiskPartition.PowerOnHours;
        TotalPowerOnHours = win32_DiskPartition.TotalPowerOnHours;
        BootPartition = win32_DiskPartition.BootPartition;
        DiskIndex = win32_DiskPartition.DiskIndex;
        HiddenSectors = win32_DiskPartition.HiddenSectors;
        Index = win32_DiskPartition.Index;
        RewritePartition = win32_DiskPartition.RewritePartition;
        Size = win32_DiskPartition.Size;
        StartingOffset = win32_DiskPartition.StartingOffset;
        Type = win32_DiskPartition.Type;
        ParentDeviceID = win32_DiskPartition.ParentDeviceID;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.DiskPartition))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.DiskPartition, []);
            ParentUSBDevice.Interfaces[InterfaceName.DiskPartition].Add(Name);
            if (Collection[ClassName.Win32_LogicalDiskToPartition] != null)
            {
                foreach (Win32_LogicalDiskToPartition item in Collection[ClassName.Win32_LogicalDiskToPartition].Cast<Win32_LogicalDiskToPartition>())
                {
                    if (DeviceID == item.DiskPartitionDeviceID)
                    {
                        ChildDevicesID.Clear();
                        if (!string.IsNullOrEmpty(item.LogicalDiskDeviceID))
                            ChildDevicesID.Add(item.LogicalDiskDeviceID);
                        if (Collection[ClassName.Win32_LogicalDisk] != null)
                        {
                            foreach (Win32_LogicalDisk itemLogical in Collection[ClassName.Win32_LogicalDisk].Cast<Win32_LogicalDisk>())
                            {
                                if (item.LogicalDiskDeviceID == itemLogical.DeviceID)
                                {
                                    itemLogical.ParentDeviceID = DeviceID;
                                    itemLogical.ParentUSBDevice = ParentUSBDevice;
                                    this.Add(new Win32_LogicalDisk(itemLogical));
                                }
                            }
                        }
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
                    case nameof(AdditionalAvailability):
                        AdditionalAvailability = (UInt16)property.Value;
                        break;
                    case nameof(IdentifyingDescriptions):
                        if (property.Value != null)
                        {
                            string[] identdescs = (string[])property.Value;
                            foreach (string identdesc in identdescs)
                            {
                                IdentifyingDescriptions.Add(identdesc);
                            }
                        }
                        break;
                    case nameof(MaxQuiesceTime):
                        MaxQuiesceTime = (UInt64)property.Value;
                        break;
                    case nameof(OtherIdentifyingInfo):
                        OtherIdentifyingInfo = (UInt64)property.Value;
                        break;
                    case nameof(PowerOnHours):
                        PowerOnHours = (UInt64)property.Value;
                        break;
                    case nameof(TotalPowerOnHours):
                        TotalPowerOnHours = (UInt64)property.Value;
                        break;
                    case nameof(BootPartition):
                        BootPartition = (bool)property.Value;
                        break;
                    case nameof(DiskIndex):
                        DiskIndex = (UInt32)property.Value;
                        break;
                    case nameof(HiddenSectors):
                        HiddenSectors = (UInt32)property.Value;
                        break;
                    case nameof(Index):
                        Index = (UInt32)property.Value;
                        break;
                    case nameof(RewritePartition):
                        RewritePartition = (bool)property.Value;
                        break;
                    case nameof(Size):
                        Size = (UInt64)property.Value;
                        break;
                    case nameof(StartingOffset):
                        StartingOffset = (UInt64)property.Value;
                        break;
                    case nameof(Type):
                        Type = (string)property.Value;
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
            new PnPEntityToList { Name = nameof(AdditionalAvailability), Value = AdditionalAvailability },
            new PnPEntityToList { Name = nameof(IdentifyingDescriptions), Value = string.Join("\r\n", IdentifyingDescriptions) },
            new PnPEntityToList { Name = nameof(MaxQuiesceTime), Value = MaxQuiesceTime },
            new PnPEntityToList { Name = nameof(OtherIdentifyingInfo), Value = OtherIdentifyingInfo },
            new PnPEntityToList { Name = nameof(PowerOnHours), Value = PowerOnHours.ToString() },
            new PnPEntityToList { Name = nameof(TotalPowerOnHours), Value = TotalPowerOnHours },
            new PnPEntityToList { Name = nameof(BootPartition), Value = BootPartition },
            new PnPEntityToList { Name = nameof(DiskIndex), Value = DiskIndex },
            new PnPEntityToList { Name = nameof(HiddenSectors), Value = HiddenSectors },
            new PnPEntityToList { Name = nameof(Index), Value = Index },
            new PnPEntityToList { Name = nameof(RewritePartition), Value = RewritePartition },
            new PnPEntityToList { Name = nameof(Size), Value = Size },
            new PnPEntityToList { Name = nameof(StartingOffset), Value = StartingOffset },
            new PnPEntityToList { Name = nameof(Type), Value = Type },
        ];
        return filedsToList;
    }
}
