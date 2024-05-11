using static USBDevicesLibrary.EventTypesEnum;
using static USBDevicesLibrary.USBDevicesInitialCollections;
using static USBDevicesLibrary.USBDevicesUpdateCollections;
using static USBDevicesLibrary.WMIClassesNameEnum;

namespace USBDevicesLibrary;

public partial class USBDevices
{
    public event EventHandler? InitialCollectionsComplete;
    public event EventHandler<USBDevicesEventArgs>? DeviceChanged;

    public USBDevices()
    {
        USBDevicesCollection = [];

        Collection = [];
        Init_Collection_Dictionary();

        WMI_Query = [];
        WMI_Searcher = [];
        WMI_Collection = [];
        Init_WMI_Dictionary();

        InitialCompleted = false;
        UsbDevicesEventManager = new(this);


    }
    private USBDevicesEventManager UsbDevicesEventManager { get; set; }
    public bool InitialCompleted;

    public async void InitialCollections()
    {
        UpdateWMICollection_MY_USBDevices();
        UpdateCollection_MY_USBDevices();
        await UpdateUSBDevicesAsync();
        OnInitialCollectionsComplete(EventArgs.Empty);
        InitialCompleted = true;
    }

    private async Task UpdateUSBDevicesAsync()
    {
        await UpdateCollections();
        await Task.Run(() =>
        {
            USBDevicesCollection.Clear();
            foreach (MY_USBDevice item in Collection[ClassName.MY_USBDevices].Cast<MY_USBDevice>())
                OnDeviceChanged(new USBDevicesEventArgs(AddUSBDeviceToCollection(item), EventTypeEnum.Connected));
        });
    }

    

    protected virtual void OnInitialCollectionsComplete(EventArgs e)
    {
        InitialCollectionsComplete?.Invoke(this, e);
    }

    internal virtual void OnDeviceChanged(USBDevicesEventArgs e)
    {
        DeviceChanged?.Invoke(this, e);
    }

    /*
    private void test()
    {
        ObjectQuery query = new(@"SELECT * FROM  Win32_Keyboard ");
        ManagementObjectSearcher searcher = new(query);
        Debug.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        int counter = 0;
        foreach (ManagementObject wmi_HD in searcher.Get().Cast<ManagementObject>())
        {
            counter++;
            foreach (PropertyData property in wmi_HD.Properties)
            {
                Debug.WriteLine($"{property.Name} = {property.Value}");
            }
            Debug.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
    //*/

}
