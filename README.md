# USB Devices Library
Detect And Event All USB Changes and Filter Devices


- Using System.Management Nuget package
- All data get from WMI in system management
- Using Concurrent Collections (System.Collections.Concurrent) : ConcurrentBag, ConcurrentDictionary
- Using << setupapi.dll >> for finding device parent and childs. so you cant use this library remotely such as WMI instructions.
- .Net Core 8.0
- Windows Desktop 
- List of USB Devices in pc
- List all of USB device childs
- Supported interfaces:
  - Disk Drive
  - Disk Partition
  - Logical Disk
  - Serial Port
  - Serial Port Configuration
  - Network Adapter
  - Network Adapter Configuration
- Event Types:
  - Connected
  - Disconnected
  - Modified

## Usage
 1. Create new instance of class `USBDevices`
    ```sh
    public USBDevices USBDevicesCollection { get; set; }
    ```

    ```sh
    USBDevicesCollection = new();
    ```

2. By default Connected, Disconnected and Modified events is enabled if you want you can disable each of them by:
    ```sh
   USBDevicesCollection.DisableConnectedEvents();
   USBDevicesCollection.DisableDisconnectedEvents();
   USBDevicesCollection.DisableModifiedEvents();
   ```
    or you can enable them by:
     ```sh
     USBDevicesCollection.EnableConnectedEvents();
     USBDevicesCollection.EnableDisconnectedEvents();
     USBDevicesCollection.EnableModifiedEvents();
     ```

3. You can set filter list to usb devices monitoring. In this case you should enable the filter status by: 
   ```sh
   USBDevicesCollection.EnableFilterDevice();
   ```
   you can diables filter status by:
   ```sh
   USBDevicesCollection.DisableFilterDevice();
   ```
   after enabled that add VID and PID to filter list. You can fill both of VID & PID or only VID or PID. Such as `AddDeviceToFilter("xxxx", "yyyy")` or `AddDeviceToFilter("xxxx", string.Empty)` or `AddDeviceToFilter(string.Empty, "yyyy")`
   ```sh
   USBDevicesCollection.AddDeviceToFilter("xxxx", "yyyy");
   ```
   you can remove from list of filtered devices by `RemoveDeviceFromFilter(vid, pid)`:
   ```sh
   USBDevicesCollection.RemoveDeviceFromFilter("xxxx", "yyyy");
   ```

4. Add Events :
   ```sh
   USBDevicesCollection.InitialCollectionsComplete += USBDevicesCollections_InitialCollectionsComplete;
   USBDevicesCollection.CollectionChanged += USBDevicesCollection_CollectionChanged;
   USBDevicesCollection.DeviceChanged += USBDevicesCollections_DeviceChanged;
   ```

5. After initial `USBDevices` class you should start the monitiring by `Start()`:
   ```sh
   USBDevicesCollection.Start();
   ```

6. `USBDevices` class inherited from `Concurrent Dictionary`. You can access devices list by `USBDevicesCollection.Values`.

For more information study the codes or contact with me.
   

## Demo video (GIF)
![0001](https://github.com/bakhshipoor/USBDevices/assets/2270529/83101ddb-78b7-4058-ae7e-deccb00da5b2)


![Screenshot 2024-05-10 204352](https://github.com/bakhshipoor/USBDevices/assets/2270529/21bf7b55-b777-4a98-8733-d4eed521830f)

![Screenshot 2024-05-10 204937](https://github.com/bakhshipoor/USBDevices/assets/2270529/3693d8f3-e864-4a16-9281-e712f52c4fe8)
