using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class Win32_USBController : CIM_USBController
{
    public Win32_USBController()
    {
        
    }

    public Win32_USBController(Win32_USBController win32_USBController)
    {
        RetrieveValues(win32_USBController);
    }

    public Win32_USBController(ManagementObject managementObject)
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
