using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using static USBDevicesLibrary.WMIClassesNameEnum;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesInterfacesEnum;

namespace USBDevicesLibrary;

internal static class USBDevicesInterfaces
{
    public static void Win32_PnPEntity_GetChilds(Win32_PnPEntity pnpEntity)
    {
        if (pnpEntity.ParentUSBDevice != null)
        {
            if (!string.IsNullOrEmpty(pnpEntity.PNPClass) && !string.IsNullOrEmpty(pnpEntity.DeviceID))
            {
                if (pnpEntity.PNPClass == "Net")
                    pnpEntity.Add(UpdateInterfaces(pnpEntity.PNPClass, pnpEntity.DeviceID, pnpEntity.ParentUSBDevice));
            }
            foreach (var item in UpdateChilds(pnpEntity.ParentUSBDevice, pnpEntity.ChildDevicesID))
                pnpEntity.Add(item);
        }
    }

    public static string GetDevicePNPClassByDeviceID(string deviceID)
    {
        string pnpClass = string.Empty;
        string path = string.Format("Win32_PnPEntity.DeviceID='{0}'", deviceID);
        ManagementObject pnpObject = new(path);
        pnpObject.Get();
        string? response = pnpObject["PNPClass"] as string;
        if (!string.IsNullOrEmpty(response))
            pnpClass = response;

        return pnpClass;
    }

    public static CIM_BaseClass UpdateChilds(MY_USBDevice parentUSBDevice, List<string> childDevicesID)
    {
        List<ChildsPNPClass> childpnpclasses = [];
        CIM_BaseClass pnpEntity = [];
        foreach (string child in childDevicesID)
        {
            childpnpclasses.Add(new ChildsPNPClass { DeviceID = child, PNPClass = GetDevicePNPClassByDeviceID(child), });
        }
        foreach (ChildsPNPClass childsPNPClass in childpnpclasses)
        {
            pnpEntity.Add(UpdateInterfaces(childsPNPClass.PNPClass, childsPNPClass.DeviceID, parentUSBDevice));
        }
        return pnpEntity;
    }

    public static CIM_BaseClass UpdateInterfaces(string pnpClass, string deviceID, MY_USBDevice parentUSBDevice)
    {
        CIM_BaseClass pnpEntity = [];
        if (pnpClass == InterfaceName.DiskDrive.ToString())
        {
            Win32_DiskDrive? win32_DiskDrive = (Win32_DiskDrive?)GetWin32InterfaceByDeviceID(ClassName.Win32_DiskDrive, deviceID, parentUSBDevice);
            if (win32_DiskDrive != null)
                pnpEntity = win32_DiskDrive;
        }
        else if (pnpClass == InterfaceName.Net.ToString())
        {
            Win32_NetworkAdapter? win32_NetworkAdapter = (Win32_NetworkAdapter?)GetWin32InterfaceByDeviceID(ClassName.Win32_NetworkAdapter, deviceID, parentUSBDevice);
            if (win32_NetworkAdapter != null)
                pnpEntity = win32_NetworkAdapter;
        }
        else if (pnpClass == InterfaceName.Ports.ToString())
        {
            Win32_SerialPort? win32_SerialPort = (Win32_SerialPort?)GetWin32InterfaceByDeviceID(ClassName.Win32_SerialPort, deviceID, parentUSBDevice);
            if (win32_SerialPort != null)
                pnpEntity = win32_SerialPort;
        }
        else
        {
            Win32_PnPEntity? win32_PnPEntity = (Win32_PnPEntity?)GetWin32InterfaceByDeviceID(ClassName.Win32_PnPEntity,deviceID,parentUSBDevice);
            if (win32_PnPEntity != null)
                pnpEntity = win32_PnPEntity;
        }
        return pnpEntity;
    }

    public static object? GetWin32InterfaceByDeviceID(ClassName className, string deviceID, MY_USBDevice parentUSBDevice)
    {
        object? win32_interface = new();
        Type? type = Type.GetType($"USBDevicesLibrary.{className}, USBDevicesLibrary");
        if (type == null) return null;
        foreach (var item in Collection[className])
        {
            string? itemPNPDeviceID = GetClassPropertyValye(item, "PNPDeviceID") as string;
            if (!string.IsNullOrEmpty(itemPNPDeviceID)) 
            {
                if (itemPNPDeviceID == deviceID)
                {
                    SetClassPropertyValye(item, "ParentUSBDevice", parentUSBDevice);
                    win32_interface = Activator.CreateInstance(type, new object[] { item });
                }
            }
        }
        if (win32_interface != null)
        {
            string? devid = GetClassPropertyValye(win32_interface, "DeviceID") as string;
            if (!string.IsNullOrEmpty(devid))
            {
                return win32_interface;
            }
        }
        return null;
    }

    public static object? GetClassPropertyValye(object obj, string propertyName)
    {
        var objProp = obj.GetType().GetProperty(propertyName);
        if (objProp != null)
        {
            return objProp.GetValue(obj, null);
        }
        return null;
    }

    public static void SetClassPropertyValye(object obj, string propertyName, object value)
    {
        var objProp = obj.GetType().GetProperty(propertyName);
        objProp?.SetValue(obj, value, null);
    }

    public struct ChildsPNPClass
    {
        public string DeviceID;
        public string PNPClass;
    }
}
