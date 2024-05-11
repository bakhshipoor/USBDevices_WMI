using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_Controller : CIM_LogicalDevice
{
    public CIM_Controller()
    {
        
    }

    public CIM_Controller(CIM_Controller cim_Controller)
    {
        RetrieveValues(cim_Controller);
    }

    public CIM_Controller(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public UInt32? MaxNumberControlled {  get; set; }
    public UInt16? ProtocolSupported { get; set; }
    public DateTime? TimeOfLastReset { get; set; }

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
                    case nameof(MaxNumberControlled):
                        MaxNumberControlled = (UInt32)property.Value;
                        break;
                    case nameof(ProtocolSupported):
                        ProtocolSupported = (UInt16)property.Value;
                        break;
                    case nameof(TimeOfLastReset):
                        TimeOfLastReset = ManagementDateTimeConverter.ToDateTime(property.Value.ToString());
                        break;
                }
            }
        });
 
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_Controller cim_Controller = (CIM_Controller)managementClass;
        MaxNumberControlled = cim_Controller.MaxNumberControlled;
        ProtocolSupported = cim_Controller.ProtocolSupported;
        TimeOfLastReset = cim_Controller.TimeOfLastReset;
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(MaxNumberControlled), Value = MaxNumberControlled },
            new PnPEntityToList { Name = nameof(ProtocolSupported), Value = ProtocolSupported },
            new PnPEntityToList { Name = nameof(TimeOfLastReset), Value = TimeOfLastReset },
        ];
        return filedsToList;
    }
}
