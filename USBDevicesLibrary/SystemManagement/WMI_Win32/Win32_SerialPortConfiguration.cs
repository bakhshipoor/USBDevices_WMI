using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;

namespace USBDevicesLibrary;

public class Win32_SerialPortConfiguration : CIM_Setting
{
    public Win32_SerialPortConfiguration()
    {
    
    }

    public Win32_SerialPortConfiguration(Win32_SerialPortConfiguration win32_SerialPortConfiguration) : this()
    {
        RetrieveValues(win32_SerialPortConfiguration);
    }

    public Win32_SerialPortConfiguration(ManagementObject managementObject) : this()
    {
        RetrieveValues(managementObject);
    }

    public bool? AbortReadWriteOnError { get; set; }
    public UInt32? BaudRate { get; set; }
    public bool? BinaryModeEnabled { get; set; }
    public UInt32? BitsPerByte { get; set; }
    public bool? ContinueXMitOnXOff { get; set; }
    public bool? CTSOutflowControl { get; set; }
    public bool? DiscardNULLBytes { get; set; }
    public bool? DSROutflowControl { get; set; }
    public bool? DSRSensitivity { get; set; }
    public string? DTRFlowControlType { get; set; }
    public UInt32? EOFCharacter { get; set; }
    public UInt32? ErrorReplaceCharacter { get; set; }
    public bool? ErrorReplacementEnabled { get; set; }
    public UInt32? EventCharacter { get; set; }
    public bool? IsBusy { get; set; }
    public string? Name { get; set; }
    public string? Parity { get; set; }
    public bool? ParityCheckEnabled { get; set; }
    public string? RTSFlowControlType { get; set; }
    public string? StopBits { get; set; }
    public UInt32? XOffCharacter { get; set; }
    public UInt32? XOffXMitThreshold { get; set; }
    public UInt32? XOnCharacter { get; set; }
    public UInt32? XOnXMitThreshold { get; set; }
    public UInt32? XOnXOffInFlowControl { get; set; }
    public UInt32? XOnXOffOutFlowControl { get; set; }

    public override void RetrieveValues(object managementClass)
    {
        base.RetrieveValues(managementClass);
        Win32_SerialPortConfiguration win32_SerialPortConfiguration = (Win32_SerialPortConfiguration)managementClass;
        AbortReadWriteOnError = win32_SerialPortConfiguration.AbortReadWriteOnError;
        BaudRate = win32_SerialPortConfiguration.BaudRate;
        BinaryModeEnabled = win32_SerialPortConfiguration.BinaryModeEnabled;
        BitsPerByte = win32_SerialPortConfiguration.BitsPerByte;
        ContinueXMitOnXOff = win32_SerialPortConfiguration.ContinueXMitOnXOff;
        CTSOutflowControl = win32_SerialPortConfiguration.CTSOutflowControl;
        DiscardNULLBytes = win32_SerialPortConfiguration.DiscardNULLBytes;
        DSROutflowControl = win32_SerialPortConfiguration.DSROutflowControl;
        DSRSensitivity = win32_SerialPortConfiguration.DSRSensitivity;
        DTRFlowControlType = win32_SerialPortConfiguration.DTRFlowControlType;
        EOFCharacter = win32_SerialPortConfiguration.EOFCharacter;
        ErrorReplaceCharacter = win32_SerialPortConfiguration.ErrorReplaceCharacter;
        ErrorReplacementEnabled = win32_SerialPortConfiguration.ErrorReplacementEnabled;
        EventCharacter = win32_SerialPortConfiguration.EventCharacter;
        IsBusy = win32_SerialPortConfiguration.IsBusy;
        Name = win32_SerialPortConfiguration.Name;
        Parity = win32_SerialPortConfiguration.Parity;
        ParityCheckEnabled = win32_SerialPortConfiguration.ParityCheckEnabled;
        RTSFlowControlType = win32_SerialPortConfiguration.RTSFlowControlType;
        StopBits = win32_SerialPortConfiguration.StopBits;
        XOffCharacter = win32_SerialPortConfiguration.XOffCharacter;
        XOffXMitThreshold = win32_SerialPortConfiguration.XOffXMitThreshold;
        XOnCharacter = win32_SerialPortConfiguration.XOnCharacter;
        XOnXMitThreshold = win32_SerialPortConfiguration.XOnXMitThreshold;
        XOnXOffInFlowControl = win32_SerialPortConfiguration.XOnXOffInFlowControl;
        XOnXOffOutFlowControl = win32_SerialPortConfiguration.XOnXOffOutFlowControl;
        if (ParentUSBDevice != null)
        {
            if (!ParentUSBDevice.Interfaces.ContainsKey(InterfaceName.SerialPortConfiguration))
                ParentUSBDevice.Interfaces.TryAdd(InterfaceName.SerialPortConfiguration, []);
            string config = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Name, BaudRate, BitsPerByte, Parity, StopBits, RTSFlowControlType);
            ParentUSBDevice.Interfaces[InterfaceName.SerialPortConfiguration].Add(config);
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
                switch(property.Name)
                {
                    case nameof(AbortReadWriteOnError):
                        AbortReadWriteOnError = (bool)property.Value;
                        break;
                    case nameof(BaudRate):
                        BaudRate = (UInt32)property.Value;
                        break;
                    case nameof(BinaryModeEnabled):
                        BinaryModeEnabled = (bool)property.Value;
                        break;
                    case nameof(BitsPerByte):
                        BitsPerByte = (UInt32)property.Value;
                        break;
                    case nameof(ContinueXMitOnXOff):
                        ContinueXMitOnXOff = (bool)property.Value;
                        break;
                    case nameof(CTSOutflowControl):
                        CTSOutflowControl = (bool)property.Value;
                        break;
                    case nameof(DiscardNULLBytes):
                        DiscardNULLBytes = (bool)property.Value;
                        break;
                    case nameof(DSROutflowControl):
                        DSROutflowControl = (bool)property.Value;
                        break;
                    case nameof(DSRSensitivity):
                        DSRSensitivity = (bool)property.Value;
                        break;
                    case nameof(DTRFlowControlType):
                        DTRFlowControlType = (string)property.Value;
                        break;
                    case nameof(EOFCharacter):
                        EOFCharacter = (UInt32)property.Value;
                        break;
                    case nameof(ErrorReplaceCharacter):
                        ErrorReplaceCharacter = (UInt32)property.Value;
                        break;
                    case nameof(ErrorReplacementEnabled):
                        ErrorReplacementEnabled = (bool)property.Value;
                        break;
                    case nameof(EventCharacter):
                        EventCharacter = (UInt32)property.Value;
                        break;
                    case nameof(IsBusy):
                        IsBusy = (bool)property.Value;
                        break;
                    case nameof(Name):
                        Name = (string)property.Value;
                        break;
                    case nameof(Parity):
                        Parity = (string)property.Value;
                        break;
                    case nameof(ParityCheckEnabled):
                        ParityCheckEnabled = (bool)property.Value;
                        break;
                    case nameof(RTSFlowControlType):
                        RTSFlowControlType = (string)property.Value;
                        break;
                    case nameof(StopBits):
                        StopBits = (string)property.Value;
                        break;
                    case nameof(XOffCharacter):
                        XOffCharacter = (UInt32)property.Value;
                        break;
                    case nameof(XOffXMitThreshold):
                        XOffXMitThreshold = (UInt32)property.Value;
                        break;
                    case nameof(XOnCharacter):
                        XOnCharacter = (UInt32)property.Value;
                        break;
                    case nameof(XOnXMitThreshold):
                        XOnXMitThreshold = (UInt32)property.Value;
                        break;
                    case nameof(XOnXOffInFlowControl):
                        XOnXOffInFlowControl = (UInt32)property.Value;
                        break;
                    case nameof(XOnXOffOutFlowControl):
                        XOnXOffOutFlowControl = (UInt32)property.Value;
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
            new PnPEntityToList { Name = nameof(AbortReadWriteOnError), Value = AbortReadWriteOnError },
            new PnPEntityToList { Name = nameof(BaudRate), Value = BaudRate },
            new PnPEntityToList { Name = nameof(BinaryModeEnabled), Value = BinaryModeEnabled },
            new PnPEntityToList { Name = nameof(BitsPerByte), Value = BitsPerByte },
            new PnPEntityToList { Name = nameof(ContinueXMitOnXOff), Value = ContinueXMitOnXOff },
            new PnPEntityToList { Name = nameof(CTSOutflowControl), Value = CTSOutflowControl },
            new PnPEntityToList { Name = nameof(DiscardNULLBytes), Value = DiscardNULLBytes },
            new PnPEntityToList { Name = nameof(DSROutflowControl), Value = DSROutflowControl },
            new PnPEntityToList { Name = nameof(DSRSensitivity), Value = DSRSensitivity },
            new PnPEntityToList { Name = nameof(DTRFlowControlType), Value = DTRFlowControlType },
            new PnPEntityToList { Name = nameof(EOFCharacter), Value = EOFCharacter },
            new PnPEntityToList { Name = nameof(ErrorReplaceCharacter), Value = ErrorReplaceCharacter },
            new PnPEntityToList { Name = nameof(ErrorReplacementEnabled), Value = ErrorReplacementEnabled },
            new PnPEntityToList { Name = nameof(EventCharacter), Value = EventCharacter },
            new PnPEntityToList { Name = nameof(IsBusy), Value = IsBusy },
            new PnPEntityToList { Name = nameof(Name), Value = Name },
            new PnPEntityToList { Name = nameof(Parity), Value = Parity },
            new PnPEntityToList { Name = nameof(ParityCheckEnabled), Value = ParityCheckEnabled },
            new PnPEntityToList { Name = nameof(RTSFlowControlType), Value = RTSFlowControlType },
            new PnPEntityToList { Name = nameof(StopBits), Value = StopBits },
            new PnPEntityToList { Name = nameof(XOffCharacter), Value = XOffCharacter },
            new PnPEntityToList { Name = nameof(XOffXMitThreshold), Value = XOffXMitThreshold },
            new PnPEntityToList { Name = nameof(XOnCharacter), Value = XOnCharacter },
            new PnPEntityToList { Name = nameof(XOnXMitThreshold), Value = XOnXMitThreshold },
            new PnPEntityToList { Name = nameof(XOnXOffInFlowControl), Value = XOnXOffInFlowControl },
            new PnPEntityToList { Name = nameof(XOnXOffOutFlowControl), Value = XOnXOffOutFlowControl },
        ];
        return filedsToList;
    }
}
