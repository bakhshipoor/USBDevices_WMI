using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_SerialController : CIM_Controller
{
    public CIM_SerialController()
    {
        Capabilities = [];
        CapabilityDescriptions = [];
    }

    public CIM_SerialController(CIM_SerialController cim_SerialController) : this()
    {
        RetrieveValues(cim_SerialController);
    }

    public CIM_SerialController(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public List<UInt16> Capabilities { get; set; }
    public List<string> CapabilityDescriptions { get; set; }
    public UInt32? MaxBaudRate { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_SerialController cim_SerialController = (CIM_SerialController)managementClass;
        Capabilities = cim_SerialController.Capabilities;
        CapabilityDescriptions = cim_SerialController.CapabilityDescriptions;
        MaxBaudRate = cim_SerialController.MaxBaudRate;
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
                    case nameof(Capabilities):
                        UInt16[] caps = (UInt16[])property.Value;
                        foreach (UInt16 cap in caps)
                        {
                            Capabilities.Add(cap);
                        }
                        break;
                    case nameof(CapabilityDescriptions):
                        string[] capds = (string[])property.Value;
                        foreach (string capd in capds)
                        {
                            CapabilityDescriptions.Add(capd);
                        }
                        break;
                    case nameof(MaxBaudRate):
                        MaxBaudRate = (UInt32)property.Value;
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
            new PnPEntityToList { Name = nameof(Capabilities), Value = string.Join("\r\n", Capabilities) },
            new PnPEntityToList { Name = nameof(CapabilityDescriptions), Value = string.Join("\r\n", CapabilityDescriptions) },
            new PnPEntityToList { Name = nameof(MaxBaudRate), Value = MaxBaudRate },
        ];
        return filedsToList;
    }
}
