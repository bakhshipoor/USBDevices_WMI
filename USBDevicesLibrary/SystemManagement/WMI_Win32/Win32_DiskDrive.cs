using System.Management;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public class Win32_DiskDrive : CIM_DiskDrive
{
    public Win32_DiskDrive()
    {

    }

    public Win32_DiskDrive(Win32_DiskDrive win32_DiskDrive) : this()
    {
        RetrieveValues(win32_DiskDrive);
    }

    public Win32_DiskDrive(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
        
    }

    public UInt32? BytesPerSector { get; set; }
    public string? FirmwareRevision { get; set; }
    public UInt32? Index { get; set; }
    public string? InterfaceType { get; set; }
    public string? Manufacturer { get; set; }
    public bool? MediaLoaded { get; set; }
    public string? MediaType { get; set; }
    public string? Model { get; set; }
    public UInt32? Partitions { get; set; }
    public UInt32? SCSIBus { get; set; }
    public UInt16? SCSILogicalUnit { get; set; }
    public UInt16? SCSIPort { get; set; }
    public UInt16? SCSITargetId { get; set; }
    public UInt32? SectorsPerTrack { get; set; }
    public string? SerialNumber { get; set; }
    public UInt32? Signature { get; set; }
    public UInt64? Size { get; set; }
    public UInt64? TotalCylinders { get; set; }
    public UInt32? TotalHeads { get; set; }
    public UInt64? TotalSectors { get; set; }
    public UInt64? TotalTracks { get; set; }
    public UInt32? TracksPerCylinder { get; set; }

    //Extra

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_DiskDrive win32_DiskDrive = (Win32_DiskDrive)managementClass;
        BytesPerSector = win32_DiskDrive.BytesPerSector;
        FirmwareRevision = win32_DiskDrive.FirmwareRevision;
        Index = win32_DiskDrive.Index;
        InterfaceType = win32_DiskDrive.InterfaceType;
        Manufacturer = win32_DiskDrive.Manufacturer;
        MediaLoaded = win32_DiskDrive.MediaLoaded;
        MediaType = win32_DiskDrive.MediaType;
        Model = win32_DiskDrive.Model;
        Partitions = win32_DiskDrive.Partitions;
        SCSIBus = win32_DiskDrive.SCSIBus;
        SCSILogicalUnit = win32_DiskDrive.SCSILogicalUnit;
        SCSIPort = win32_DiskDrive.SCSIPort;
        SCSITargetId = win32_DiskDrive.SCSITargetId;
        SectorsPerTrack = win32_DiskDrive.SectorsPerTrack;
        SerialNumber = win32_DiskDrive.SerialNumber;
        Signature = win32_DiskDrive.Signature;
        Size = win32_DiskDrive.Size;
        TotalCylinders = win32_DiskDrive.TotalCylinders;
        TotalHeads = win32_DiskDrive.TotalHeads;
        TotalSectors = win32_DiskDrive.TotalSectors;
        TotalTracks = win32_DiskDrive.TotalTracks;
        TracksPerCylinder = win32_DiskDrive.TracksPerCylinder;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.DiskDrive))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.DiskDrive, []);
            ParentUSBDevice.Interfaces[InterfaceName.DiskDrive].Add(Name);
            if (Collection[ClassName.Win32_DiskDriveToDiskPartition] != null)
            {
                foreach (Win32_DiskDriveToDiskPartition item in Collection[ClassName.Win32_DiskDriveToDiskPartition].Cast<Win32_DiskDriveToDiskPartition>())
                {
                    if (DeviceID == item.DiskDriveDeviceID)
                    {
                        if (!string.IsNullOrEmpty(item.DiskPartitionDeviceID))
                            ChildDevicesID.Add(item.DiskPartitionDeviceID);
                        if (Collection[ClassName.Win32_DiskPartition] != null)
                        {
                            foreach (Win32_DiskPartition itemPartition in Collection[ClassName.Win32_DiskPartition].Cast<Win32_DiskPartition>())
                            {
                                if (item.DiskPartitionDeviceID == itemPartition.DeviceID)
                                {
                                    itemPartition.ParentDeviceID = DeviceID;
                                    itemPartition.ParentUSBDevice = ParentUSBDevice;
                                    this.Add(new Win32_DiskPartition(itemPartition));
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
                    case nameof(BytesPerSector):
                        BytesPerSector = (UInt32)property.Value;
                        break;
                    case nameof(FirmwareRevision):
                        FirmwareRevision = (string)property.Value;
                        break;
                    case nameof(Index):
                        Index = (UInt32)property.Value;
                        break;
                    case nameof(InterfaceType):
                        InterfaceType = (string)property.Value;
                        break;
                    case nameof(Manufacturer):
                        Manufacturer = (string)property.Value;
                        break;
                    case nameof(MediaLoaded):
                        MediaLoaded = (bool)property.Value;
                        break;
                    case nameof(MediaType):
                        MediaType = (string)property.Value;
                        break;
                    case nameof(Model):
                        Model = (string)property.Value;
                        break;
                    case nameof(Partitions):
                        Partitions = (UInt32)property.Value;
                        break;
                    case nameof(SCSIBus):
                        SCSIBus = (UInt32)property.Value;
                        break;
                    case nameof(SCSILogicalUnit):
                        SCSILogicalUnit = (UInt16)property.Value;
                        break;
                    case nameof(SCSIPort):
                        SCSIPort = (UInt16)property.Value;
                        break;
                    case nameof(SCSITargetId):
                        SCSITargetId = (UInt16)property.Value;
                        break;
                    case nameof(SectorsPerTrack):
                        SectorsPerTrack = (UInt32)property.Value;
                        break;
                    case nameof(SerialNumber):
                        SerialNumber = (string)property.Value;
                        break;
                    case nameof(Signature):
                        Signature = (UInt32)property.Value;
                        break;
                    case nameof(Size):
                        Size = (UInt64)property.Value;
                        break;
                    case nameof(TotalCylinders):
                        TotalCylinders = (UInt64)property.Value;
                        break;
                    case nameof(TotalHeads):
                        TotalHeads = (UInt32)property.Value;
                        break;
                    case nameof(TotalSectors):
                        TotalSectors = (UInt64)property.Value;
                        break;
                    case nameof(TotalTracks):
                        TotalTracks = (UInt64)property.Value;
                        break;
                    case nameof(TracksPerCylinder):
                        TracksPerCylinder = (UInt32)property.Value;
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
            new PnPEntityToList { Name = nameof(BytesPerSector), Value = BytesPerSector },
            new PnPEntityToList { Name = nameof(FirmwareRevision), Value = FirmwareRevision },
            new PnPEntityToList { Name = nameof(Index), Value = Index },
            new PnPEntityToList { Name = nameof(InterfaceType), Value = InterfaceType },
            new PnPEntityToList { Name = nameof(Manufacturer), Value = Manufacturer },
            new PnPEntityToList { Name = nameof(MediaLoaded), Value = MediaLoaded },
            new PnPEntityToList { Name = nameof(MediaType), Value = MediaType },
            new PnPEntityToList { Name = nameof(Model), Value = Model },
            new PnPEntityToList { Name = nameof(Partitions), Value = Partitions },
            new PnPEntityToList { Name = nameof(SCSIBus), Value = SCSIBus },
            new PnPEntityToList { Name = nameof(SCSILogicalUnit), Value = SCSILogicalUnit },
            new PnPEntityToList { Name = nameof(SCSIPort), Value = SCSIPort },
            new PnPEntityToList { Name = nameof(SCSITargetId), Value = SCSITargetId },
            new PnPEntityToList { Name = nameof(SectorsPerTrack), Value = SectorsPerTrack },
            new PnPEntityToList { Name = nameof(SerialNumber), Value = SerialNumber },
            new PnPEntityToList { Name = nameof(Signature), Value = Signature },
            new PnPEntityToList { Name = nameof(Size), Value = Size },
            new PnPEntityToList { Name = nameof(TotalCylinders), Value = TotalCylinders },
            new PnPEntityToList { Name = nameof(TotalHeads), Value = TotalHeads },
            new PnPEntityToList { Name = nameof(TotalSectors), Value = TotalSectors },
            new PnPEntityToList { Name = nameof(TotalTracks), Value = TotalTracks },
            new PnPEntityToList { Name = nameof(TracksPerCylinder), Value = TracksPerCylinder },
        ];
        return filedsToList;
    }
}
