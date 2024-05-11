using System.Management;

namespace USBDevicesLibrary;

public class CIM_DataFile : CIM_LogicalFile
{
    public CIM_DataFile()
    {
        
    }

    public CIM_DataFile(CIM_DataFile cim_DataFile)
    {
        RetrieveValues(cim_DataFile);
    }

    public CIM_DataFile(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public string? Manufacturer { get; set; }
    public string? Version { get; set; }

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
                    case nameof(Manufacturer):
                        Manufacturer = (string)property.Value;
                        break;
                    case nameof(Version):
                        Version = (string)property.Value;
                        break;
                }
            }
        });
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_DataFile cim_DataFile = (CIM_DataFile)managementClass;
        Manufacturer = cim_DataFile.Manufacturer;
        Version = cim_DataFile.Version;
    }
}
