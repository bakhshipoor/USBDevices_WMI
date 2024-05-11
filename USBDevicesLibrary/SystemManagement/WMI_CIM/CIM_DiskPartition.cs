using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_DiskPartition : CIM_StorageExtent
{
    public CIM_DiskPartition()
    {
        
    }

    public CIM_DiskPartition(CIM_DiskPartition cim_DiskPartition)
    {
        RetrieveValues(cim_DiskPartition);
    }

    public CIM_DiskPartition(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public UInt16? Access {  get; set; }
    public bool? Bootable { get; set; }
    public bool? PrimaryPartition { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_DiskPartition cim_DiskPartition = (CIM_DiskPartition)managementClass;
        Access = cim_DiskPartition.Access;
        Bootable = cim_DiskPartition.Bootable;
        PrimaryPartition = cim_DiskPartition.PrimaryPartition;
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
                    case nameof(Bootable):
                        Bootable = (bool)property.Value;
                        break;
                    case nameof(PrimaryPartition):
                        PrimaryPartition = (bool)property.Value;
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
            new PnPEntityToList { Name = nameof(Bootable), Value = Bootable },
            new PnPEntityToList { Name = nameof(PrimaryPartition), Value = PrimaryPartition },
        ];
        return filedsToList;
    }
}
