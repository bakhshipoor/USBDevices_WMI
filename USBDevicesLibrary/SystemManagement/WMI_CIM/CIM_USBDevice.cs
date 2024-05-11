using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace USBDevicesLibrary;

public class CIM_USBDevice : CIM_LogicalDevice
{
    public CIM_USBDevice()
    {
        CurrentAlternateSettings = [];
    }

    public CIM_USBDevice(CIM_USBDevice cim_USBDevice) : this()
    {
        RetrieveValues(cim_USBDevice);
    }

    public CIM_USBDevice(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public byte? ClassCode { get; set; }
    public List<byte> CurrentAlternateSettings { get; set; }
    public byte? CurrentConfigValue { get; set; }
    public byte? NumberOfConfigs { get; set; }
    public byte? ProtocolCode { get; set; }
    public byte? SubclassCode { get; set; }
    public UInt16? USBVersion { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_USBDevice cim_USBDevice = (CIM_USBDevice)managementClass;
        ClassCode = cim_USBDevice.ClassCode;
        CurrentAlternateSettings = cim_USBDevice.CurrentAlternateSettings;
        CurrentConfigValue = cim_USBDevice.CurrentConfigValue;
        NumberOfConfigs = cim_USBDevice.NumberOfConfigs;
        ProtocolCode = cim_USBDevice.ProtocolCode;
        SubclassCode = cim_USBDevice.SubclassCode;
        USBVersion = cim_USBDevice.USBVersion;
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
                    case nameof(ClassCode):
                        ClassCode = (byte)property.Value;
                        break;
                    case nameof(CurrentAlternateSettings):
                        if (property.Value != null)
                        {
                            byte[] cass = (byte[])property.Value;
                            foreach (byte cas in cass)
                            {
                                CurrentAlternateSettings.Add(cas);
                            }
                        }
                        break;
                    case nameof(CurrentConfigValue):
                        CurrentConfigValue = (byte)property.Value;
                        break;
                    case nameof(NumberOfConfigs):
                        NumberOfConfigs = (byte)property.Value;
                        break;
                    case nameof(ProtocolCode):
                        ProtocolCode = (byte)property.Value;
                        break;
                    case nameof(SubclassCode):
                        SubclassCode = (byte)property.Value;
                        break;
                    case nameof(USBVersion):
                        USBVersion = (UInt16)property.Value;
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
            new PnPEntityToList { Name = nameof(ClassCode), Value = ClassCode },
            new PnPEntityToList { Name = nameof(CurrentAlternateSettings), Value = string.Join("\r\n", CurrentAlternateSettings) },
            new PnPEntityToList { Name = nameof(CurrentConfigValue), Value = CurrentConfigValue },
            new PnPEntityToList { Name = nameof(NumberOfConfigs), Value = NumberOfConfigs },
            new PnPEntityToList { Name = nameof(ProtocolCode), Value = ProtocolCode },
            new PnPEntityToList { Name = nameof(SubclassCode), Value = SubclassCode },
            new PnPEntityToList { Name = nameof(USBVersion), Value = USBVersion },
        ];
        return filedsToList;
    }
}
