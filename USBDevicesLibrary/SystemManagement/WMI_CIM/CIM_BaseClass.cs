using System.Collections;
using System.Management;

namespace USBDevicesLibrary;

public class CIM_BaseClass : ThreadSafeObservableCollection<CIM_BaseClass>
{
    public CIM_BaseClass()
    {

    }

    public CIM_BaseClass(CIM_BaseClass cim_BaseClass) : this()
    {
        RetrieveValues(cim_BaseClass);
    }

    public CIM_BaseClass(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public MY_USBDevice? ParentUSBDevice { get; set; }

    public IEnumerable Children
    {
        get
        {
            return this;
        }
    }

    public virtual void RetrieveValues(object managementClass)
    {
        CIM_BaseClass cim_BaseClass = (CIM_BaseClass)managementClass;
        ParentUSBDevice = cim_BaseClass.ParentUSBDevice;
        //foreach (var item in cim_BaseClass)
        //    Add(item);
    }

    public virtual void RetrieveValues(ManagementObject managementObject)
    {
        
    }

    public virtual List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            ParentUSBDevice != null ? new PnPEntityToList { Name = nameof(ParentUSBDevice), Value = ParentUSBDevice.DeviceID } : new PnPEntityToList { Name = nameof(ParentUSBDevice), Value = string.Empty },
        ];
        return filedsToList;
    }

}
