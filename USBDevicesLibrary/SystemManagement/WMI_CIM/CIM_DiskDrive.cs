using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_DiskDrive : CIM_MediaAccessDevice
{
    public CIM_DiskDrive()
    {
        
    }

    public CIM_DiskDrive(CIM_DiskDrive cim_DiskDrive)
    {
        RetrieveValues(cim_DiskDrive);
    }

    public CIM_DiskDrive(ManagementObject managementObject)
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
