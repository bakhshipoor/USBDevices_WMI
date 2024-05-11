using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_LogicalDisk : CIM_StorageExtent
{
    public CIM_LogicalDisk()
    {
        
    }

    public CIM_LogicalDisk(CIM_LogicalDisk cim_LogicalDisk)
    {
        RetrieveValues(cim_LogicalDisk);
    }

    public CIM_LogicalDisk(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public UInt16? Access {  get; set; }
    public UInt64? FreeSpace { get; set; }
    public UInt64? Size { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_LogicalDisk cim_LogicalDisk = (CIM_LogicalDisk)managementClass;
        Access = cim_LogicalDisk.Access;
        FreeSpace = cim_LogicalDisk.FreeSpace;
        Size = cim_LogicalDisk.Size;
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
                    case nameof(Access):
                        Access = (UInt16)property.Value;
                        break;
                    case nameof(FreeSpace):
                        FreeSpace = (UInt64)property.Value;
                        break;
                    case nameof(Size):
                        Size = (UInt64)property.Value;
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
            new PnPEntityToList { Name = nameof(Access), Value = Access },
            new PnPEntityToList { Name = nameof(FreeSpace), Value = FreeSpace },
            new PnPEntityToList { Name = nameof(Size), Value = Size },
        ];
        return filedsToList;
    }
}
