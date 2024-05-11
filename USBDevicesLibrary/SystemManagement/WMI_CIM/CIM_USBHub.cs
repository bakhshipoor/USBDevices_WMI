using System.Management;

namespace USBDevicesLibrary;

public class CIM_USBHub : CIM_USBDevice
{
    public CIM_USBHub()
    {
        
    }

    public CIM_USBHub(CIM_USBHub cim_USBHub) : this()
    {
        RetrieveValues(cim_USBHub);
    }

    public CIM_USBHub(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public bool GangSwitched {  get; set; }
    public byte NumberOfPorts { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_USBHub cim_USBHub = (CIM_USBHub)managementClass;
        GangSwitched = cim_USBHub.GangSwitched;
        NumberOfPorts = cim_USBHub.NumberOfPorts;
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
                    case nameof(GangSwitched):
                        GangSwitched = (bool)property.Value;
                        break;
                    case nameof(NumberOfPorts):
                        NumberOfPorts = (byte)property.Value;
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
            new PnPEntityToList { Name = nameof(GangSwitched), Value = GangSwitched },
            new PnPEntityToList { Name = nameof(NumberOfPorts), Value = NumberOfPorts },
        ];
        return filedsToList;
    }
}
