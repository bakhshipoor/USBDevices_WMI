using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_StorageExtent : CIM_LogicalDevice
{
    public CIM_StorageExtent()
    {
        
    }

    public CIM_StorageExtent(CIM_StorageExtent cim_StorageExtent)
    {
        RetrieveValues(cim_StorageExtent);
    }

    public CIM_StorageExtent(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public UInt64? BlockSize {  get; set; }
    public string? ErrorMethodology { get; set; }
    public UInt64? NumberOfBlocks { get; set; }
    public string? Purpose { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_StorageExtent cim_StorageExtent = (CIM_StorageExtent)managementClass;
        BlockSize = cim_StorageExtent.BlockSize;
        ErrorMethodology = cim_StorageExtent.ErrorMethodology;
        NumberOfBlocks = cim_StorageExtent.NumberOfBlocks;
        Purpose = cim_StorageExtent.Purpose;
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
                    case nameof(BlockSize):
                        BlockSize = (UInt64)property.Value;
                        break;
                    case nameof(ErrorMethodology):
                        ErrorMethodology = (string)property.Value;
                        break;
                    case nameof(NumberOfBlocks):
                        NumberOfBlocks = (UInt64)property.Value;
                        break;
                    case nameof(Purpose):
                        Purpose = (string)property.Value;
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
            new PnPEntityToList { Name = nameof(BlockSize), Value = BlockSize },
            new PnPEntityToList { Name = nameof(ErrorMethodology), Value = ErrorMethodology },
            new PnPEntityToList { Name = nameof(NumberOfBlocks), Value = NumberOfBlocks },
            new PnPEntityToList { Name = nameof(Purpose), Value = Purpose },
        ];
        return filedsToList;
    }

}
