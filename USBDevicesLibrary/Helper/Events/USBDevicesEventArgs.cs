using static USBDevicesLibrary.EventTypesEnum;

namespace USBDevicesLibrary;

public class USBDevicesEventArgs : EventArgs
{
    public USBDevicesEventArgs(MY_USBDevice my_USBDevice, EventTypeEnum eventType)
    {
        Device = my_USBDevice;
        EventType = eventType;
    }

    public MY_USBDevice Device { get; set; }
    public EventTypeEnum EventType {  get; set; }
}
