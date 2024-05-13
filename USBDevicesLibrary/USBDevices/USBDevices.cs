using static USBDevicesLibrary.EventTypesEnum;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesUpdateCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public class USBDevices : ThreadSafeDictionary<MY_USBDevice, MY_USBDevice>
{
    public event EventHandler? InitialCollectionsComplete;
    public event EventHandler<USBDevicesEventArgs>? DeviceChanged;

    public USBDevices()
    {
        Clear();

        EnableConnectedEvents();
        EnableDisconnectedEvents();
        EnableModifiedEvents();
        DisableFilterDevice();

        Collection = [];
        Init_Collection_Dictionary();

        WMI_Query = [];
        WMI_Searcher = [];
        WMI_Collection = [];
        Init_WMI_Dictionary();

        InitialCompleted = false;
        UsbDevicesEventManager = new(this);
    }

    private USBDevicesEventManager UsbDevicesEventManager;
    internal bool InitialCompleted;

    public async void Start()
    {
        UpdateWMICollectionByName(ClassName.MY_USBDevices);
        UpdateCollection_MY_USBDevices();
        await UpdateUSBDevicesAsync();
        OnInitialCollectionsComplete(EventArgs.Empty);
        InitialCompleted = true;
    }

    private async Task UpdateUSBDevicesAsync()
    {
        await UpdateCollectionsAsync();
        await Task.Run(() =>
        {
            Clear();
            foreach (MY_USBDevice item in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
            {
                MY_USBDevice usbDevice = new(item);
                TryAdd(usbDevice, usbDevice);
                OnDeviceChanged(new USBDevicesEventArgs(usbDevice, EventTypeEnum.Connected));
            }
        });
    }

    public void EnableConnectedEvents()
    {
        ConnectedEventStatus = true;
    }

    public void DisableConnectedEvents()
    {
        ConnectedEventStatus = false;
    }

    public void EnableDisconnectedEvents()
    {
        DisconnectedEventStatus = true;
    }

    public void DisableDisconnectedEvents()
    {
        DisconnectedEventStatus = false;
    }

    public void EnableModifiedEvents()
    {
        ModifiedEventStatus = true;
    }

    public void DisableModifiedEvents()
    {
        ModifiedEventStatus = false;
    }

    public void EnableFilterDevice()
    {
        FilterDeviceStatus = true;
    }

    public void DisableFilterDevice()
    {
        FilterDeviceStatus = false;
    }

    public bool AddDeviceToFilter(string vid, string pid)
    {
        USBDevicesFilter devicesFilter = new();
        bool find = false;
        foreach (USBDevicesFilter item in USBDevicesFilterList)
            if (item.VID == vid && item.PID == pid)
            {
                find = true;
                break;
            }
        if (!find)
            USBDevicesFilterList.Add(new USBDevicesFilter{ VID = vid, PID = pid});
        return find;
    }

    public bool RemoveDeviceFromFilter(string vid, string pid)
    {
        USBDevicesFilter devicesFilter = new();
        bool find = false;
        foreach (USBDevicesFilter item in USBDevicesFilterList)
            if (item.VID == vid && item.PID == pid)
            {
                find = true;
                devicesFilter = item;
                break;
            }
        if (find)
            USBDevicesFilterList.Remove(devicesFilter);
        return find;
    }

    protected virtual void OnInitialCollectionsComplete(EventArgs e)
    {
        InitialCollectionsComplete?.Invoke(this, e);
    }

    internal virtual void OnDeviceChanged(USBDevicesEventArgs e)
    {
        DeviceChanged?.Invoke(this, e);
    }
}
