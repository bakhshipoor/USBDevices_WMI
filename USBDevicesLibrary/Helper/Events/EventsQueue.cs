using static USBDevicesLibrary.EventTypesEnum;

namespace USBDevicesLibrary;

public class EventsQueue
{
    public EventsQueue()
    {
        EventType = EventTypeEnum.NONE;
        EventCollection = new();
        NewCollection = new();
        OldCollection = new();
    }

    public EventsQueue(EventTypeEnum eventType, ThreadSafeObservableCollection<object> eventCollection, ThreadSafeObservableCollection<object> newCollection, ThreadSafeObservableCollection<object> oldCollection) : this()
    {
        EventType = eventType;
        EventCollection = eventCollection;
        NewCollection = newCollection;
        OldCollection = oldCollection;
    }

    public EventTypeEnum EventType { get; set; }
    public ThreadSafeObservableCollection<object> EventCollection { get; set; }
    public ThreadSafeObservableCollection<object> NewCollection { get; set; }
    public ThreadSafeObservableCollection<object> OldCollection { get; set; }

}
