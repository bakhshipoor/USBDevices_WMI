using System.IO;
using System.Management;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;
using static USBDevicesLibrary.USBDevicesInterfaces;
using System.Collections;

namespace USBDevicesLibrary;

public class Win32_PnPEntity : CIM_LogicalDevice
{
    public Win32_PnPEntity()
    {
        CompatibleID = [];
        HardwareID = [];
    }

    public Win32_PnPEntity(Win32_PnPEntity win32_PnPEntity) : this()
    {
        RetrieveValues(win32_PnPEntity);
    }

    public Win32_PnPEntity(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public string? ClassGuid { get; set; }
    public List<string> CompatibleID { get; set; }
    public List<string> HardwareID { get; set; }
    public string? Manufacturer { get; set; }
    public string? PNPClass { get; set; }
    public bool? Present { get; set; }
    public string? Service { get; set; }

    // Extra

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property!=null && property.Value != null)
            {
                switch (property.Name)
                {
                    case nameof(ClassGuid):
                        ClassGuid = (string)property.Value;
                        break;
                    case nameof(CompatibleID):
                        if (property.Value != null)
                        {
                            string[] CompatibleIDs = (string[])property.Value;
                            foreach (string compatibleID in CompatibleIDs)
                                CompatibleID.Add(compatibleID);
                        }
                        break;
                    case nameof(HardwareID):
                        if (property.Value != null)
                        {
                            string[] HardwareIDs = (string[])property.Value;
                            foreach (string hardwareID in HardwareIDs)
                                HardwareID.Add(hardwareID);
                        }
                        break;
                    case nameof(Manufacturer):
                        Manufacturer = (string)property.Value;
                        break;
                    case nameof(PNPClass):
                        PNPClass = (string)property.Value;
                        break;
                    case nameof(Present):
                        Present = (bool)property.Value;
                        break;
                    case nameof(Service):
                        Service = (string)property.Value;
                        break;
                }
            }
        });
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_PnPEntity win32_PnPEntity = (Win32_PnPEntity)managementClass;
        ClassGuid = win32_PnPEntity.ClassGuid;
        CompatibleID = win32_PnPEntity.CompatibleID;
        HardwareID = win32_PnPEntity.HardwareID;
        Manufacturer = win32_PnPEntity.Manufacturer;
        PNPClass = win32_PnPEntity.PNPClass;
        Present = win32_PnPEntity.Present;
        Service = win32_PnPEntity.Service;
        DataFiles = win32_PnPEntity.DataFiles;
        Win32_PnPEntity_GetChilds(this);
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(ClassGuid), Value = ClassGuid },
            new PnPEntityToList { Name = nameof(CompatibleID), Value = string.Join("\r\n", CompatibleID) },
            new PnPEntityToList { Name = nameof(HardwareID), Value = string.Join("\r\n", HardwareID) },
            new PnPEntityToList { Name = nameof(Manufacturer), Value = Manufacturer },
            new PnPEntityToList { Name = nameof(PNPClass), Value = PNPClass },
            new PnPEntityToList { Name = nameof(Present), Value = Present.ToString() },
            new PnPEntityToList { Name = nameof(Service), Value = Service },
        ];
        return filedsToList;
    }

    
}
