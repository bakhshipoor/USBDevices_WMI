using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static USBDevicesLibrary.LogicalDeviceGetParent;

namespace USBDevicesLibrary;

public class CIM_MediaAccessDevice : CIM_LogicalDevice
{
    public CIM_MediaAccessDevice()
    {
        Capabilities = [];
        CapabilityDescriptions = [];
    }

    public CIM_MediaAccessDevice(CIM_MediaAccessDevice cim_MediaAccessDevice) : this()
    {
        RetrieveValues(cim_MediaAccessDevice);
    }

    public CIM_MediaAccessDevice(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public List<UInt16> Capabilities {  get; set; }
    public List<string> CapabilityDescriptions { get; set; }
    public string? CompressionMethod { get; set; }
    public UInt64? DefaultBlockSize { get; set; }
    public string? ErrorMethodology { get; set; }
    public UInt64? MaxBlockSize { get; set; }
    public UInt64? MaxMediaSize { get; set; }
    public UInt64? MinBlockSize { get; set; }
    public bool? NeedsCleaning { get; set; }
    public UInt32? NumberOfMediaSupported { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_MediaAccessDevice cim_MediaAccessDevice = (CIM_MediaAccessDevice)managementClass;
        Capabilities = cim_MediaAccessDevice.Capabilities;
        CapabilityDescriptions = cim_MediaAccessDevice.CapabilityDescriptions;
        CompressionMethod = cim_MediaAccessDevice.CompressionMethod;
        DefaultBlockSize = cim_MediaAccessDevice.DefaultBlockSize;
        ErrorMethodology = cim_MediaAccessDevice.ErrorMethodology;
        MaxBlockSize = cim_MediaAccessDevice.MaxBlockSize;
        MaxMediaSize = cim_MediaAccessDevice.MaxMediaSize;
        MinBlockSize = cim_MediaAccessDevice.MinBlockSize;
        NeedsCleaning = cim_MediaAccessDevice.NeedsCleaning;
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
                        if (property.Value != null)
                        {
                            UInt16[] caps = (UInt16[])property.Value;
                            foreach (UInt16 cap in caps)
                            {
                                Capabilities.Add(cap);
                            }
                        }
                        break;
                    case nameof(CapabilityDescriptions):
                        if (property.Value != null)
                        {
                            string[] capds = (string[])property.Value;
                            foreach (string capd in capds)
                            {
                                CapabilityDescriptions.Add(capd);
                            }
                        }
                        break;
                    case nameof(CompressionMethod):
                        CompressionMethod = (string)property.Value;
                        break;
                    case nameof(DefaultBlockSize):
                        DefaultBlockSize = (UInt64)property.Value;
                        break;
                    case nameof(ErrorMethodology):
                        ErrorMethodology = (string)property.Value;
                        break;
                    case nameof(MaxBlockSize):
                        MaxBlockSize = (UInt64)property.Value;
                        break;
                    case nameof(MaxMediaSize):
                        MaxMediaSize = (UInt64)property.Value;
                        break;
                    case nameof(MinBlockSize):
                        MinBlockSize = (UInt64)property.Value;
                        break;
                    case nameof(NeedsCleaning):
                        NeedsCleaning = (bool)property.Value;
                        break;
                    case nameof(NumberOfMediaSupported):
                        NumberOfMediaSupported = (UInt32)property.Value;
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
            new PnPEntityToList { Name = nameof(CompressionMethod), Value = CompressionMethod },
            new PnPEntityToList { Name = nameof(DefaultBlockSize), Value = DefaultBlockSize },
            new PnPEntityToList { Name = nameof(ErrorMethodology), Value = ErrorMethodology },
            new PnPEntityToList { Name = nameof(MaxBlockSize), Value = MaxBlockSize },
            new PnPEntityToList { Name = nameof(MaxMediaSize), Value = MaxMediaSize },
            new PnPEntityToList { Name = nameof(MinBlockSize), Value = MinBlockSize },
            new PnPEntityToList { Name = nameof(NeedsCleaning), Value = NeedsCleaning },
            new PnPEntityToList { Name = nameof(NumberOfMediaSupported), Value = NumberOfMediaSupported },
        ];
        return filedsToList;
    }
}
