using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Windows;

namespace USBDevicesLibrary;

public class ThreadSafeQueue<T> : ConcurrentQueue<T>, INotifyCollectionChanged
{
    public ThreadSafeQueue()
    {

    }
    public event EventHandler? AddedToQueue;
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public new void Enqueue(T item)
    {
        base.Enqueue(item);
        Application.Current.Dispatcher.Invoke(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item)));
    }

    public T? Dequeue()
    {
        TryDequeue(out T? item);
        Application.Current.Dispatcher.Invoke(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,item)));
        return item;
    }


}
