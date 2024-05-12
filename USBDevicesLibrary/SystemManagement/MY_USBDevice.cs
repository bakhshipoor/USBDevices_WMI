using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;

namespace USBDevicesLibrary;

public class MY_USBDevice : Win32_PnPEntity
{
    public MY_USBDevice()
    {
        Interfaces = [];
    }

    public MY_USBDevice(MY_USBDevice my_USBDevices) : this()
    {
        RetrieveValues(my_USBDevices);
    }

    public MY_USBDevice(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public Dictionary<Enum, List<string?>> Interfaces { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        MY_USBDevice my_USBDevice = (MY_USBDevice)managementClass;
        my_USBDevice.ParentUSBDevice = this;
        if (!Interfaces.ContainsKey(InterfaceName.USB))
            Interfaces.TryAdd(InterfaceName.USB, []);

        base.RetrieveValues(my_USBDevice);

        Interfaces[InterfaceName.USB].Add(string.Format("VID: {0}", VID));
        Interfaces[InterfaceName.USB].Add(string.Format("PID: {0}", PID));
        Interfaces[InterfaceName.USB].Add(string.Format("Manufacturer: {0}", Manufacturer));
        Interfaces[InterfaceName.USB].Add(string.Format("Caption: {0}", Caption));
    }

    public override void RetrieveValues(ManagementObject managementObject)
    {
        base.RetrieveValues(managementObject);
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<string> interfaces = [];

        foreach (var item in this.Interfaces)
        {
            interfaces.Add(item.Key + " : \r\n\t" + string.Join("\r\n\t", item.Value) );
        }
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(Interfaces), Value = string.Join("\r\n", interfaces) },
        ];
        
        return filedsToList;
    }

    public int GetTotlaChilds()
    {
        int totalChilds = 0;
        foreach (CIM_BaseClass item in this)
        {
            totalChilds++;
            if (item.Count>0)
            {
                totalChilds+=GetChilds(item);
            }
        }
        return totalChilds;
    }

    private int GetChilds(CIM_BaseClass baseClass)
    {
        int totalChilds = 0;
        foreach (CIM_BaseClass item in baseClass)
        {
            totalChilds++;
            if (item.Count > 0)
            {
                totalChilds += GetChilds(item);
            }
        }
        return totalChilds;
    }

    
}
