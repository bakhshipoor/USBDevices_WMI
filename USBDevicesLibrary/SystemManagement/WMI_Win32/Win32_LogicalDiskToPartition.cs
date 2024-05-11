using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public class Win32_LogicalDiskToPartition
{
    public Win32_LogicalDiskToPartition()
    {
        
    }

    public Win32_LogicalDiskToPartition(ManagementObject managementObject)
    {
        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property!=null && property.Value!=null)
            {
                switch (property.Name)
                {
                    case "Antecedent":
                        DiskPartitionDeviceID = ExtractDeviceID(property.Value as string);
                        break;
                    case "Dependent":
                        LogicalDiskDeviceID = ExtractDeviceID(property.Value as string);
                        break;
                }
            }
        });
    }

    public string? DiskPartitionDeviceID { get; set; }
    public string? LogicalDiskDeviceID { get; set; }

    private string? ExtractDeviceID(string? deviceID)
    {
        if (string.IsNullOrEmpty(deviceID)) return null;
        string response = string.Empty;
        string[] res = deviceID.Split("\"");
        if (res.Length > 0)
        {
            response = res[1];
        }
        if (!string.IsNullOrEmpty(response))
        {
            return response;
        }
        return null;
    }
}
