using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_USBController : CIM_Controller
{
    public CIM_USBController()
    {
        
    }

    public CIM_USBController(CIM_USBController cim_USBController)
    {
        RetrieveValues(cim_USBController);
    }

    public CIM_USBController(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }


    public string? Manufacturer { get; set; }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
        PropertyData[] propertyDatas = new PropertyData[managementObject.Properties.Count];
        managementObject.Properties.CopyTo(propertyDatas, 0);
        Parallel.ForEach(propertyDatas, property =>
        {
            if (property != null && property.Value != null)
            {
                if (property.Name == nameof(Manufacturer))
                    Manufacturer = (string)property.Value;
            }
        });
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);   
        CIM_USBController cim_USBController = (CIM_USBController)managementClass;
        Manufacturer = cim_USBController.Manufacturer;
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(Manufacturer), Value = Manufacturer },
        ];
        return filedsToList;
    }

}
