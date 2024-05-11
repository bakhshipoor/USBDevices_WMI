using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class Win32_USBHub : CIM_USBHub
{
    public Win32_USBHub()
    {
        
    }

    public Win32_USBHub(Win32_USBHub win32_USBHub)
    {
        RetrieveValues(win32_USBHub);
    }

    public Win32_USBHub(ManagementObject managementObject)
    {

        RetrieveValues(managementObject);
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
    }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
        
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        return base.FiledsToList();
    }
}
