using System.Windows.Input;
using System.Windows.Threading;
using static USBDevicesLibrary.EventTypesEnum;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesUpdateCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;


namespace USBDevicesLibrary;

public class USBDevicesEventManager
{
    public USBDevicesEventManager(USBDevices usbdevices)
    {
        UsbDevices = usbdevices;
        dispatcherTimer = new DispatcherTimer
        {
            Interval = new TimeSpan(0, 0, 0, 0, 500)
        };
        dispatcherTimer.Tick -= DispatcherTimer_Tick;
        dispatcherTimer.Tick += DispatcherTimer_Tick;
        dispatcherTimer.Start();
    }

    private USBDevices UsbDevices { get; set; }
    private readonly DispatcherTimer dispatcherTimer;

    private void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        DispatcherTimer? dispatcherTimer = (DispatcherTimer?)sender;
        ThreadSafeObservableCollection<MY_USBDevice> connectedDevices = [];
        ThreadSafeObservableCollection<MY_USBDevice> disconnectedDevices = [];
        if (dispatcherTimer != null)
        {
            if (UsbDevices.InitialCompleted)
            {
                UpdateWMICollection_MY_USBDevices();
                UpdateCollection_MY_USBDevices();
                foreach (MY_USBDevice itemNew in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
                {
                    bool find = false;
                    foreach (MY_USBDevice itemOld in Collection[ClassName.MY_USBDevices_OLD].Cast<MY_USBDevice>())
                    {
                        if (itemNew.DeviceID == itemOld.DeviceID)
                        {
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        connectedDevices.Add(itemNew);
                    }
                }
                foreach (MY_USBDevice itemOld in Collection[ClassName.MY_USBDevices_OLD].Cast<MY_USBDevice>())
                {
                    bool find = false;
                    foreach (MY_USBDevice itemNew in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
                    {
                        if (itemOld.DeviceID == itemNew.DeviceID)
                        {
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        disconnectedDevices.Add(itemOld);
                    }
                }
                if (connectedDevices.Count > 0) sdddd(connectedDevices);
                if (disconnectedDevices.Count > 0) OnDevice_Disconnected(disconnectedDevices);
            }
        }
    }

    private async void sdddd(ThreadSafeObservableCollection<MY_USBDevice> connectedDevices)
    {
        await OnDevice_Connected(connectedDevices); ;
    }

    private async Task OnDevice_Connected(ThreadSafeObservableCollection<MY_USBDevice> connectedDevices)
    {
        await Task.Run(UpdateCollections);
        await Task.Run(() =>
        {
            foreach (MY_USBDevice item in connectedDevices)
                UsbDevices.OnDeviceChanged(new USBDevicesEventArgs(AddUSBDeviceToCollection(item), EventTypeEnum.Connected));
        });
    }

    private void OnDevice_Disconnected(ThreadSafeObservableCollection<MY_USBDevice> disconnectedDevices)
    {
        foreach (MY_USBDevice item in disconnectedDevices)
        {
            MY_USBDevice? devic = FindDevice(item.DeviceID);
            if (devic != null)
            {
                bool res = USBDevicesCollection.TryRemove(new KeyValuePair<MY_USBDevice, MY_USBDevice>(devic, devic));
                UsbDevices.OnDeviceChanged(new USBDevicesEventArgs(devic, EventTypeEnum.Disconnected));

            }
        }
    }

    public MY_USBDevice? FindDevice(string? deviceID)
    {
        MY_USBDevice response = [];
        foreach (MY_USBDevice item in USBDevicesCollection.Values)
        {
            if (item.DeviceID == deviceID)
            {
                response = item;
                break;
            }
        }
        if (!string.IsNullOrEmpty(response.DeviceID))
            return response;
        return null;
    }
}
