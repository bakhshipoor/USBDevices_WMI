using System.Collections.ObjectModel;
using System.Management;
using static USBDevicesLibrary.LogicalDeviceGetParent;

namespace USBDevicesLibrary;

public class CIM_LogicalDevice : CIM_LogicalElement
{
    public CIM_LogicalDevice()
    {
        DataFiles = [];
        PowerManagementCapabilities = [];
        ChildDevicesID = [];

    }

    public CIM_LogicalDevice(CIM_LogicalDevice cim_LogicalDevice) : this()
    {
        RetrieveValues(cim_LogicalDevice);
    }

    public CIM_LogicalDevice(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public UInt16? Availability { get; set; }
    public UInt32? ConfigManagerErrorCode { get; set; }
    public bool? ConfigManagerUserConfig { get; set; }
    public string? CreationClassName { get; set; }
    public string? DeviceID { get; set; }
    public List<UInt16> PowerManagementCapabilities { get; set; }
    public bool? ErrorCleared { get; set; }
    public string? ErrorDescription { get; set; }
    public UInt32? LastErrorCode { get; set; }
    public string? PNPDeviceID { get; set; }
    public bool? PowerManagementSupported { get; set; }
    public UInt16? StatusInfo { get; set; }
    public string? SystemCreationClassName { get; set; }
    public string? SystemName { get; set; }

    // Extra
    public string? VID {  get; set; }
    public string? PID {  get; set; }
    public string? ParentDeviceID { get; set; }
    public List<string> ChildDevicesID {  get; set; }
    public ThreadSafeObservableCollection<CIM_DataFile> DataFiles { get; set; }

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
                    case nameof(Availability):
                        Availability = (UInt16)property.Value;
                        break;
                    case nameof(ConfigManagerErrorCode):
                        ConfigManagerErrorCode = (UInt32)property.Value;
                        break;
                    case nameof(ConfigManagerUserConfig):
                        ConfigManagerUserConfig = (bool)property.Value;
                        break;
                    case nameof(CreationClassName):
                        CreationClassName = (string)property.Value;
                        break;
                    case nameof(DeviceID):
                        DeviceID = (string)property.Value;
                        ParentDeviceID = GetParent(DeviceID);
                        ChildDevicesID = GetChilds(DeviceID);
                        break;
                    case nameof(PowerManagementCapabilities):
                        if (property.Value != null)
                        {
                            UInt16[] pmcs = (UInt16[])property.Value;
                            foreach (UInt16 pmc in pmcs)
                            {
                                PowerManagementCapabilities.Add(pmc);
                            }
                        }
                        break;
                    case nameof(ErrorCleared):
                        ErrorCleared = (bool)property.Value;
                        break;
                    case nameof(ErrorDescription):
                        ErrorDescription = (string)property.Value;
                        break;
                    case nameof(LastErrorCode):
                        LastErrorCode = (UInt32)property.Value;
                        break;
                    case nameof(PNPDeviceID):
                        PNPDeviceID = (string)property.Value;
                        break;
                    case nameof(PowerManagementSupported):
                        PowerManagementSupported = (bool)property.Value;
                        break;
                    case nameof(StatusInfo):
                        StatusInfo = (UInt16)property.Value;
                        break;
                    case nameof(SystemCreationClassName):
                        SystemCreationClassName = (string)property.Value;
                        break;
                    case nameof(SystemName):
                        SystemName = (string)property.Value;
                        break;
                }
            }
        });
        if (!string.IsNullOrEmpty(DeviceID))
        {
            int indexofVID = DeviceID.IndexOf("VID", StringComparison.OrdinalIgnoreCase);
            int indexofPID = DeviceID.IndexOf("PID", StringComparison.OrdinalIgnoreCase);
            VID = indexofVID >= 0 ? DeviceID.Substring(indexofVID + 4, 4) : string.Empty;
            PID = indexofVID >= 0 ? DeviceID.Substring(indexofPID + 4, 4) : string.Empty;
        }
    }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        CIM_LogicalDevice cim_LogicalDevice = (CIM_LogicalDevice)managementClass;
        Availability = cim_LogicalDevice.Availability;
        ConfigManagerErrorCode = cim_LogicalDevice.ConfigManagerErrorCode;
        ConfigManagerUserConfig = cim_LogicalDevice.ConfigManagerUserConfig;
        CreationClassName = cim_LogicalDevice.CreationClassName;
        DeviceID = cim_LogicalDevice.DeviceID;
        PowerManagementCapabilities = cim_LogicalDevice.PowerManagementCapabilities;
        ErrorCleared = cim_LogicalDevice.ErrorCleared;
        ErrorDescription = cim_LogicalDevice.ErrorDescription;
        LastErrorCode = cim_LogicalDevice.LastErrorCode;
        PNPDeviceID = cim_LogicalDevice.PNPDeviceID;
        PowerManagementSupported = cim_LogicalDevice.PowerManagementSupported;
        StatusInfo = cim_LogicalDevice.StatusInfo;
        SystemCreationClassName = cim_LogicalDevice.SystemCreationClassName;
        SystemName = cim_LogicalDevice.SystemName;
        DataFiles = cim_LogicalDevice.DataFiles;
        VID = cim_LogicalDevice.VID;
        PID = cim_LogicalDevice.PID;
        ParentDeviceID = cim_LogicalDevice.ParentDeviceID;
        ChildDevicesID = cim_LogicalDevice.ChildDevicesID;
    }

    public override List<PnPEntityToList> FiledsToList()
    {
        List<PnPEntityToList> filedsToList =
        [
            .. base.FiledsToList(),
            new PnPEntityToList { Name = nameof(Availability), Value = Availability.ToString() },
            new PnPEntityToList { Name = nameof(ConfigManagerErrorCode), Value = ConfigManagerErrorCode.ToString() },
            new PnPEntityToList { Name = nameof(ConfigManagerUserConfig), Value = ConfigManagerUserConfig.ToString() },
            new PnPEntityToList { Name = nameof(CreationClassName), Value = CreationClassName },
            new PnPEntityToList { Name = nameof(DeviceID), Value = DeviceID },
            new PnPEntityToList { Name = nameof(PowerManagementCapabilities), Value = string.Join("\r\n", PowerManagementCapabilities) },
            new PnPEntityToList { Name = nameof(ErrorCleared), Value = ErrorCleared.ToString() },
            new PnPEntityToList { Name = nameof(ErrorDescription), Value = ErrorDescription },
            new PnPEntityToList { Name = nameof(LastErrorCode), Value = LastErrorCode.ToString() },
            new PnPEntityToList { Name = nameof(PNPDeviceID), Value = PNPDeviceID },
            new PnPEntityToList { Name = nameof(PowerManagementSupported), Value = PowerManagementSupported.ToString() },
            new PnPEntityToList { Name = nameof(StatusInfo), Value = StatusInfo.ToString() },
            new PnPEntityToList { Name = nameof(SystemCreationClassName), Value = SystemCreationClassName },
            new PnPEntityToList { Name = nameof(SystemName), Value = SystemName },
            new PnPEntityToList { Name = nameof(ParentDeviceID), Value = ParentDeviceID },
            new PnPEntityToList { Name = nameof(ChildDevicesID), Value = string.Join("\r\n", ChildDevicesID) },
            new PnPEntityToList { Name = nameof(VID), Value = VID },
            new PnPEntityToList { Name = nameof(PID), Value = PID },
        ];
        return filedsToList;
    }

}
