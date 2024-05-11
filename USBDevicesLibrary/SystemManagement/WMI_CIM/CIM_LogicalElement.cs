using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDevicesLibrary;

public class CIM_LogicalElement : CIM_ManagedSystemElement
{
    public CIM_LogicalElement()
    {
        
    }

    public CIM_LogicalElement(CIM_LogicalElement cim_LogicalElement)
    {
        RetrieveValues(cim_LogicalElement);
    }

    public CIM_LogicalElement(ManagementObject managementObject)
    {
        RetrieveValues(managementObject);
    }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        return base.FiledsToList();
    }

}
