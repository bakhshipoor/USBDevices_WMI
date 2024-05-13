using System.Windows.Input;
using System.Windows.Threading;
using static USBDevicesLibrary.EventTypesEnum;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesUpdateCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;


namespace USBDevicesLibrary;

internal class USBDevicesEventManager
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

    private readonly USBDevices UsbDevices;
    private readonly DispatcherTimer dispatcherTimer;
    private bool isProcessingConnectedDevices = false;
    private bool isProcessingDisconnectedDevices = false;
    private bool isProcessingModifiedDevices = false;

    private async void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        DispatcherTimer? dispatcherTimer = (DispatcherTimer?)sender;
        ThreadSafeObservableCollection<MY_USBDevice> connectedDevices = [];
        ThreadSafeObservableCollection<MY_USBDevice> disconnectedDevices = [];
        if (dispatcherTimer != null)
        {
            dispatcherTimer.Stop();
            if (UsbDevices.InitialCompleted)
            {
                await Task.Run(() => {
                    UpdateWMICollectionByName(ClassName.MY_USBDevices);
                    UpdateCollection_MY_USBDevices();
                    // Check For Connected
                    if (ConnectedEventStatus)
                    {
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
                        if (connectedDevices.Count > 0)
                        {
                            isProcessingConnectedDevices = true;
                            OnDevice_Connected(connectedDevices);
                        }
                    }
                    // Check For Disconnected
                    if (DisconnectedEventStatus)
                    {
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
                        if (disconnectedDevices.Count > 0)
                        {
                            isProcessingDisconnectedDevices = true;
                            OnDevice_Disconnected(disconnectedDevices);
                        }
                    }
                    // Check For Modified
                    if (ModifiedEventStatus)
                    {
                        if (connectedDevices.Count == 0 && disconnectedDevices.Count == 0 && !isProcessingConnectedDevices && !isProcessingDisconnectedDevices && !isProcessingModifiedDevices)
                        {
                            isProcessingModifiedDevices = true;
                            RunCheckForModifiedAsync();
                        }
                    }
                });
            }
            dispatcherTimer.Start();
        }
    }

    private async void RunCheckForModifiedAsync()
    {
        await CheckForModified();
        isProcessingModifiedDevices = false;
    }

    private async Task CheckForModified()
    {
        await UpdateCollectionsAsync();
        List<ChildsCount> newChildsCount = [];
        List<ChildsCount> oldChildsCount = [];
        List<string> modifiedDevicesID = [];
        Task[] tasks =
        [
            Task.Run(() =>
            {
                foreach (MY_USBDevice item in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
                {
                    MY_USBDevice device = new(item);
                    newChildsCount.Add(new() { Count = device.GetTotlaChilds(), DeviceID = device.DeviceID });
                }
            }),
            Task.Run(() =>
            {
                foreach (MY_USBDevice item in UsbDevices.Values)
                {
                    oldChildsCount.Add(new() { Count = item.GetTotlaChilds(), DeviceID = item.DeviceID });
                }
            }),
        ];
        await Task.WhenAll(tasks);

        await Task.Run(() =>
        {
            foreach (ChildsCount itemNew in newChildsCount)
            {
                foreach (ChildsCount itemOld in oldChildsCount)
                {
                    if (!string.IsNullOrEmpty(itemNew.DeviceID) && !string.IsNullOrEmpty(itemOld.DeviceID))
                    {
                        if (itemNew.DeviceID == itemOld.DeviceID)
                        {
                            if (itemNew.Count != itemOld.Count)
                                modifiedDevicesID.Add(itemNew.DeviceID);
                        }
                    }
                }
            }
        });

        await Task.Run(() =>
        {
            foreach (string item in modifiedDevicesID)
            {
                OnDevice_Modified(item);
            }
        });
    }

    private async void OnDevice_Connected(ThreadSafeObservableCollection<MY_USBDevice> connectedDevices)
    {
        await UpdateCollectionsAsync();
        foreach (MY_USBDevice item in connectedDevices)
        {
            MY_USBDevice usbDevice = new(item);
            UsbDevices.TryAdd(usbDevice, usbDevice);
            UsbDevices.OnDeviceChanged(new USBDevicesEventArgs(usbDevice, EventTypeEnum.Connected));
        }
        isProcessingConnectedDevices = false;
    }
    
    private void OnDevice_Disconnected(ThreadSafeObservableCollection<MY_USBDevice> disconnectedDevices)
    {
        foreach (MY_USBDevice item in disconnectedDevices)
        {
            MY_USBDevice? devic = FindDevice(item.DeviceID);
            if (devic != null)
            {
                UsbDevices.TryRemove(new KeyValuePair<MY_USBDevice, MY_USBDevice>(devic, devic));
                UsbDevices.OnDeviceChanged(new USBDevicesEventArgs(devic, EventTypeEnum.Disconnected));
            }
        }
        isProcessingDisconnectedDevices = false;
    }

    private async void OnDevice_Modified(string deviceID)
    {
        await Task.Run(() =>
        {
            foreach (MY_USBDevice item in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
            {
                MY_USBDevice device = new(item);
                if (device.DeviceID == deviceID)
                {
                    MY_USBDevice? findedDevic = FindDevice(device.DeviceID);
                    if (findedDevic != null)
                    {
                        UsbDevices.TryRemove(new KeyValuePair<MY_USBDevice, MY_USBDevice>(findedDevic, findedDevic));
                        UsbDevices.TryAdd(device, device);
                        UsbDevices.OnDeviceChanged(new USBDevicesEventArgs(device, EventTypeEnum.Modified));
                    }
                }
            }
        });
    }

    public MY_USBDevice? FindDevice(string? deviceID)
    {
        MY_USBDevice response = [];
        foreach (MY_USBDevice item in UsbDevices.Values)
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

    public struct ChildsCount
    {
        public int Count;
        public string? DeviceID;
    }


}
