using System.Windows;
using System.Windows.Input;
using USBDevicesLibrary;
using static USBDevicesLibrary.USBDevicesInitialCollections;

namespace USBDeviceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = this;
            USBDevicesCollections = new();
            Loaded -= MainWindow_Loaded;
            Loaded += MainWindow_Loaded;
            
        }

        private  void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            USBDevicesCollections.InitialCollectionsComplete += USBDevicesCollections_InitialCollectionsComplete;
            trvMain.SelectedItemChanged += TrvMain_SelectedItemChanged;
            USBDevicesCollections.InitialCollections();
            //trvMain.MouseDoubleClick += TrvMain_MouseDoubleClick;
            USBDevicesCollection.CollectionChanged += USBDevicesCollection_CollectionChanged;
            USBDevicesCollections.DeviceChanged += USBDevicesCollections_DeviceChanged;
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

        private void TrvMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            trvMain.Items.Refresh();
        }

        private void TrvMain_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            List<PnPEntityToList> filedsToList = [.. ((CIM_BaseClass)e.NewValue).FiledsToList().OrderBy(x => x.Name)];
            itemPNP.ItemsSource = filedsToList;
        }

        private void USBDevicesCollections_InitialCollectionsComplete(object? sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                brdWait.Visibility = Visibility.Collapsed;
                if (USBDevicesCollections != null)
                    trvMain.ItemsSource = USBDevicesCollection.Values;
                trvMain.Items.Refresh();
            });


        }

        public USBDevices USBDevicesCollections { get; set; }

    }
}