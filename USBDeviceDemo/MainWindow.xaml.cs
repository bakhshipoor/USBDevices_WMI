using System.Windows;
using USBDevicesLibrary;

namespace USBDeviceDemo
{
    public partial class MainWindow : Window
    {
        public USBDevices USBDevicesCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            USBDevicesCollection = new();

            //USBDevicesCollection.EnableFilterDevice();
            //USBDevicesCollection.AddDeviceToFilter("E2B7", "0811");

            USBDevicesCollection.InitialCollectionsComplete += USBDevicesCollections_InitialCollectionsComplete;
            USBDevicesCollection.CollectionChanged += USBDevicesCollection_CollectionChanged;
            USBDevicesCollection.DeviceChanged += USBDevicesCollections_DeviceChanged;

            Loaded -= MainWindow_Loaded;
            Loaded += MainWindow_Loaded;
        }

        private  void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            trvMain.SelectedItemChanged += TrvMain_SelectedItemChanged;
            
            USBDevicesCollection.Start();
        }

        private void USBDevicesCollections_DeviceChanged(object? sender, USBDevicesEventArgs e)
        {
            List<string> interfaces = [];
            foreach (var item in e.Device.Interfaces)
            {
                interfaces.Add(item.Key + " : \r\n\t" + string.Join("\r\n\t", item.Value));
            }
            string msg = "Event Type: " + e.EventType.ToString() + "\r\n\r\n\r\n" + string.Join("\r\n", interfaces); 
            MessageBox.Show(msg, "USB Device",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void USBDevicesCollection_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            trvMain.ItemsSource = USBDevicesCollection.Values;
        }

        private void TrvMain_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            List<PnPEntityToList> filedsToList = [.. ((CIM_BaseClass)e.NewValue).FiledsToList().OrderBy(x => x.Name)];
            itemPNP.ItemsSource = filedsToList;
        }

        private void USBDevicesCollections_InitialCollectionsComplete(object? sender, EventArgs e)
        {
            brdWait.Visibility = Visibility.Collapsed;
            if (USBDevicesCollection != null)
                trvMain.ItemsSource = USBDevicesCollection.Values;
            trvMain.Items.Refresh();
        }
    }
}