using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_NetworkAdapter : CIM_LogicalDevice
{
    public CIM_NetworkAdapter()
    {
        NetworkAddresses = [];
    }

    public CIM_NetworkAdapter(CIM_NetworkAdapter cim_NetworkAdapter) : this()
    {
        RetrieveValues(cim_NetworkAdapter);
    }

    public CIM_NetworkAdapter(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public bool? AutoSense{  get; set; }
    public UInt64? MaxSpeed{  get; set; }
    public List<string> NetworkAddresses{  get; set; }
    public string? PermanentAddress {  get; set; }
    public UInt64? Speed {  get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_NetworkAdapter cim_NetworkAdapter = (CIM_NetworkAdapter)managementClass;
        AutoSense = cim_NetworkAdapter.AutoSense;
        MaxSpeed = cim_NetworkAdapter.MaxSpeed;
        NetworkAddresses = cim_NetworkAdapter.NetworkAddresses;
        PermanentAddress = cim_NetworkAdapter.PermanentAddress;
        Speed = cim_NetworkAdapter.Speed;
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
                    case nameof(AutoSense):
                        AutoSense = (bool)property.Value;
                        break;
                    case nameof(MaxSpeed):
                        MaxSpeed = (UInt64)property.Value;
                        break;
                    case nameof(NetworkAddresses):
                        if (property.Value != null)
                        {
                            string[] nas = (string[])property.Value;
                            foreach (string na in nas)
                            {
                                NetworkAddresses.Add(na);
                            }
                        }
                        break;
                    case nameof(PermanentAddress):
                        PermanentAddress = (string)property.Value;
                        break;
                    case nameof(Speed):
                        Speed = (UInt64)property.Value;
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
            new PnPEntityToList { Name = nameof(AutoSense), Value = AutoSense },
            new PnPEntityToList { Name = nameof(MaxSpeed), Value = MaxSpeed },
            new PnPEntityToList { Name = nameof(NetworkAddresses), Value = string.Join("\r\n", NetworkAddresses) },
            new PnPEntityToList { Name = nameof(PermanentAddress), Value = PermanentAddress },
            new PnPEntityToList { Name = nameof(Speed), Value = Speed },
        ];
        return filedsToList;
    }
}
