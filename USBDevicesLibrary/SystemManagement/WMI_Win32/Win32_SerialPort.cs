using System.Management;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public class Win32_SerialPort : CIM_SerialController
{

    public Win32_SerialPort()
    {
        
    }

    public Win32_SerialPort(Win32_SerialPort win32_SerialPort) : this()
    {
        RetrieveValues(win32_SerialPort);
    }

    public Win32_SerialPort(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public bool? Binary { get; set; }
    public UInt32? MaximumInputBufferSize { get; set; }
    public UInt32? MaximumOutputBufferSize { get; set; }
    public bool? OSAutoDiscovered { get; set; }
    public string? ProviderType { get; set; }
    public bool? SettableBaudRate { get; set; }
    public bool? SettableDataBits { get; set; }
    public bool? SettableFlowControl { get; set; }
    public bool? SettableParity { get; set; }
    public bool? SettableParityCheck { get; set; }
    public bool? SettableRLSD { get; set; }
    public bool? SettableStopBits { get; set; }
    public bool? Supports16BitMode { get; set; }
    public bool? SupportsDTRDSR { get; set; }
    public bool? SupportsElapsedTimeouts { get; set; }
    public bool? SupportsIntTimeouts { get; set; }
    public bool? SupportsParityCheck { get; set; }
    public bool? SupportsRLSD { get; set; }
    public bool? SupportsRTSCTS { get; set; }
    public bool? SupportsSpecialCharacters { get; set; }
    public bool? SupportsXOnXOff { get; set; }
    public bool? SupportsXOnXOffSet { get; set; }

    // Extra

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_SerialPort win32_SerialPort = (Win32_SerialPort)managementClass;
        Binary = win32_SerialPort.Binary;
        MaximumInputBufferSize = win32_SerialPort.MaximumInputBufferSize;
        MaximumOutputBufferSize = win32_SerialPort.MaximumOutputBufferSize;
        OSAutoDiscovered = win32_SerialPort.OSAutoDiscovered;
        ProviderType = win32_SerialPort.ProviderType;
        SettableBaudRate = win32_SerialPort.SettableBaudRate;
        SettableDataBits = win32_SerialPort.SettableDataBits;
        SettableFlowControl = win32_SerialPort.SettableFlowControl;
        SettableParity = win32_SerialPort.SettableParity;
        SettableParityCheck = win32_SerialPort.SettableParityCheck;
        SettableRLSD = win32_SerialPort.SettableRLSD;
        SettableStopBits = win32_SerialPort.SettableStopBits;
        Supports16BitMode = win32_SerialPort.Supports16BitMode;
        SupportsDTRDSR = win32_SerialPort.SupportsDTRDSR;
        SupportsElapsedTimeouts = win32_SerialPort.SupportsElapsedTimeouts;
        SupportsIntTimeouts = win32_SerialPort.SupportsIntTimeouts;
        SupportsParityCheck = win32_SerialPort.SupportsParityCheck;
        SupportsRLSD = win32_SerialPort.SupportsRLSD;
        SupportsRTSCTS = win32_SerialPort.SupportsRTSCTS;
        SupportsSpecialCharacters = win32_SerialPort.SupportsSpecialCharacters;
        SupportsXOnXOff = win32_SerialPort.SupportsXOnXOff;
        SupportsXOnXOffSet = win32_SerialPort.SupportsXOnXOffSet;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.SerialPort))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.SerialPort, []);
            ParentUSBDevice.Interfaces[InterfaceName.SerialPort].Add(DeviceID);
            if (Collection[ClassName.Win32_SerialPortConfiguration] != null)
            {
                foreach (Win32_SerialPortConfiguration item in Collection[ClassName.Win32_SerialPortConfiguration].Cast<Win32_SerialPortConfiguration>())
                {
                    if (DeviceID == item.Name)
                    {
                        item.ParentUSBDevice = ParentUSBDevice;
                        Add(new Win32_SerialPortConfiguration(item));
                    }
                }
            }
        }
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
                    case nameof(Binary):
                        Binary = (bool)property.Value;
                        break;
                    case nameof(MaximumInputBufferSize):
                        MaximumInputBufferSize = (UInt32)property.Value;
                        break;
                    case nameof(MaximumOutputBufferSize):
                        MaximumOutputBufferSize = (UInt32)property.Value;
                        break;
                    case nameof(OSAutoDiscovered):
                        OSAutoDiscovered = (bool)property.Value;
                        break;
                    case nameof(ProviderType):
                        ProviderType = (string)property.Value;
                        break;
                    case nameof(SettableBaudRate):
                        SettableBaudRate = (bool)property.Value;
                        break;
                    case nameof(SettableDataBits):
                        SettableDataBits = (bool)property.Value;
                        break;
                    case nameof(SettableFlowControl):
                        SettableFlowControl = (bool)property.Value;
                        break;
                    case nameof(SettableParity):
                        SettableParity = (bool)property.Value;
                        break;
                    case nameof(SettableParityCheck):
                        SettableParityCheck = (bool)property.Value;
                        break;
                    case nameof(SettableRLSD):
                        SettableRLSD = (bool)property.Value;
                        break;
                    case nameof(SettableStopBits):
                        SettableStopBits = (bool)property.Value;
                        break;
                    case nameof(Supports16BitMode):
                        Supports16BitMode = (bool)property.Value;
                        break;
                    case nameof(SupportsDTRDSR):
                        SupportsDTRDSR = (bool)property.Value;
                        break;
                    case nameof(SupportsElapsedTimeouts):
                        SupportsElapsedTimeouts = (bool)property.Value;
                        break;
                    case nameof(SupportsIntTimeouts):
                        SupportsIntTimeouts = (bool)property.Value;
                        break;
                    case nameof(SupportsParityCheck):
                        SupportsParityCheck = (bool)property.Value;
                        break;
                    case nameof(SupportsRLSD):
                        SupportsRLSD = (bool)property.Value;
                        break;
                    case nameof(SupportsRTSCTS):
                        SupportsRTSCTS = (bool)property.Value;
                        break;
                    case nameof(SupportsSpecialCharacters):
                        SupportsSpecialCharacters = (bool)property.Value;
                        break;
                    case nameof(SupportsXOnXOff):
                        SupportsXOnXOff = (bool)property.Value;
                        break;
                    case nameof(SupportsXOnXOffSet):
                        SupportsXOnXOffSet = (bool)property.Value;
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
            new PnPEntityToList { Name = nameof(Binary), Value = Binary },
            new PnPEntityToList { Name = nameof(MaximumInputBufferSize), Value = MaximumInputBufferSize },
            new PnPEntityToList { Name = nameof(MaximumOutputBufferSize), Value = MaximumOutputBufferSize },
            new PnPEntityToList { Name = nameof(OSAutoDiscovered), Value = OSAutoDiscovered },
            new PnPEntityToList { Name = nameof(ProviderType), Value = ProviderType },
            new PnPEntityToList { Name = nameof(SettableBaudRate), Value = SettableBaudRate },
            new PnPEntityToList { Name = nameof(SettableDataBits), Value = SettableDataBits },
            new PnPEntityToList { Name = nameof(SettableFlowControl), Value = SettableFlowControl },
            new PnPEntityToList { Name = nameof(SettableParity), Value = SettableParity },
            new PnPEntityToList { Name = nameof(SettableParityCheck), Value = SettableParityCheck },
            new PnPEntityToList { Name = nameof(SettableRLSD), Value = SettableRLSD },
            new PnPEntityToList { Name = nameof(SettableStopBits), Value = SettableStopBits },
            new PnPEntityToList { Name = nameof(Supports16BitMode), Value = Supports16BitMode },
            new PnPEntityToList { Name = nameof(SupportsDTRDSR), Value = SupportsDTRDSR },
            new PnPEntityToList { Name = nameof(SupportsElapsedTimeouts), Value = SupportsElapsedTimeouts },
            new PnPEntityToList { Name = nameof(SupportsIntTimeouts), Value = SupportsIntTimeouts },
            new PnPEntityToList { Name = nameof(SupportsParityCheck), Value = SupportsParityCheck },
            new PnPEntityToList { Name = nameof(SupportsRLSD), Value = SupportsRLSD },
            new PnPEntityToList { Name = nameof(SupportsRTSCTS), Value = SupportsRTSCTS },
            new PnPEntityToList { Name = nameof(SupportsSpecialCharacters), Value = SupportsSpecialCharacters },
            new PnPEntityToList { Name = nameof(SupportsXOnXOff), Value = SupportsXOnXOff },
            new PnPEntityToList { Name = nameof(SupportsXOnXOffSet), Value = SupportsXOnXOffSet },
        ];
        return filedsToList;
    }


}
