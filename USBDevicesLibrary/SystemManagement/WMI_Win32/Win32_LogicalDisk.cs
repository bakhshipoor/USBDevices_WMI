using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using USBDevicesLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;

namespace USBDevicesLibrary;

public  class Win32_LogicalDisk : CIM_LogicalDisk
{
    public Win32_LogicalDisk()
    {
        
    }

    public Win32_LogicalDisk(Win32_LogicalDisk win32_LogicalDisk)
    {
        RetrieveValues(win32_LogicalDisk);
    }

    public Win32_LogicalDisk(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public bool? Compressed { get; set; }
    public UInt32? DriveType { get; set; }
    public string? FileSystem { get; set; }
    public UInt32? MaximumComponentLength { get; set; }
    public UInt32? MediaType { get; set; }
    public string? ProviderName { get; set; }
    public bool? QuotasDisabled { get; set; }
    public bool? QuotasIncomplete { get; set; }
    public bool? QuotasRebuilding { get; set; }
    public bool? SupportsDiskQuotas { get; set; }
    public bool? SupportsFileBasedCompression { get; set; }
    public bool? VolumeDirty { get; set; }
    public string? VolumeName { get; set; }
    public string? VolumeSerialNumber { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_LogicalDisk win32_LogicalDisk = (Win32_LogicalDisk)managementClass;
        Compressed = win32_LogicalDisk.Compressed;
        DriveType = win32_LogicalDisk.DriveType;
        FileSystem = win32_LogicalDisk.FileSystem;
        MaximumComponentLength = win32_LogicalDisk.MaximumComponentLength;
        MediaType = win32_LogicalDisk.MediaType;
        ProviderName = win32_LogicalDisk.ProviderName;
        QuotasDisabled = win32_LogicalDisk.QuotasDisabled;
        QuotasIncomplete = win32_LogicalDisk.QuotasIncomplete;
        QuotasRebuilding = win32_LogicalDisk.QuotasRebuilding;
        SupportsDiskQuotas = win32_LogicalDisk.SupportsDiskQuotas;
        SupportsFileBasedCompression = win32_LogicalDisk.SupportsFileBasedCompression;
        VolumeDirty = win32_LogicalDisk.VolumeDirty;
        VolumeName = win32_LogicalDisk.VolumeName;
        VolumeSerialNumber = win32_LogicalDisk.VolumeSerialNumber;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.LogicalDisk))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.LogicalDisk, []);
            ParentUSBDevice.Interfaces[InterfaceName.LogicalDisk].Add(string.Format("{0}, {1}", ParentDeviceID, Name));
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
                    case nameof(Compressed):
                        Compressed = (bool)property.Value;
                        break;
                    case nameof(DriveType):
                        DriveType = (UInt32)property.Value;
                        break;
                    case nameof(FileSystem):
                        FileSystem = (string)property.Value;
                        break;
                    case nameof(MaximumComponentLength):
                        MaximumComponentLength = (UInt32)property.Value;
                        break;
                    case nameof(MediaType):
                        MediaType = (UInt32)property.Value;
                        break;
                    case nameof(ProviderName):
                        ProviderName = (string)property.Value;
                        break;
                    case nameof(QuotasDisabled):
                        QuotasDisabled = (bool)property.Value;
                        break;
                    case nameof(QuotasIncomplete):
                        QuotasIncomplete = (bool)property.Value;
                        break;
                    case nameof(QuotasRebuilding):
                        QuotasRebuilding = (bool)property.Value;
                        break;
                    case nameof(SupportsDiskQuotas):
                        SupportsDiskQuotas = (bool)property.Value;
                        break;
                    case nameof(SupportsFileBasedCompression):
                        SupportsFileBasedCompression = (bool)property.Value;
                        break;
                    case nameof(VolumeDirty):
                        VolumeDirty = (bool)property.Value;
                        break;
                    case nameof(VolumeName):
                        VolumeName = (string)property.Value;
                        break;
                    case nameof(VolumeSerialNumber):
                        VolumeSerialNumber = (string)property.Value;
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
            new PnPEntityToList { Name = nameof(Compressed), Value = Compressed },
            new PnPEntityToList { Name = nameof(DriveType), Value = DriveType },
            new PnPEntityToList { Name = nameof(FileSystem), Value = FileSystem },
            new PnPEntityToList { Name = nameof(MaximumComponentLength), Value = MaximumComponentLength },
            new PnPEntityToList { Name = nameof(MediaType), Value = MediaType },
            new PnPEntityToList { Name = nameof(ProviderName), Value = ProviderName },
            new PnPEntityToList { Name = nameof(QuotasDisabled), Value = QuotasDisabled },
            new PnPEntityToList { Name = nameof(QuotasIncomplete), Value = QuotasIncomplete },
            new PnPEntityToList { Name = nameof(QuotasRebuilding), Value = QuotasRebuilding },
            new PnPEntityToList { Name = nameof(SupportsDiskQuotas), Value = SupportsDiskQuotas },
            new PnPEntityToList { Name = nameof(SupportsFileBasedCompression), Value = SupportsFileBasedCompression },
            new PnPEntityToList { Name = nameof(VolumeDirty), Value = VolumeDirty },
            new PnPEntityToList { Name = nameof(VolumeName), Value = VolumeName },
            new PnPEntityToList { Name = nameof(VolumeSerialNumber), Value = VolumeSerialNumber },
        ];
        return filedsToList;
    }
}
