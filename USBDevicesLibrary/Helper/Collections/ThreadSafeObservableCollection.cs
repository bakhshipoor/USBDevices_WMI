using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace USBDevicesLibrary;

public class ThreadSafeObservableCollection<T> : ConcurrentBag<T>/*, INotifyCollectionChanged*/
{
    //public ThreadSafeObservableCollection()
    //{
    //}

    //public event NotifyCollectionChangedEventHandler? CollectionChanged;

    //public void Remove(T? item)
    //{
    //    if (TryTake(out item))
    //    {
    //        if (CollectionChanged != null) 
    //        {
    //            Application.Current.Dispatcher.Invoke(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)));
    //        }
    //    }
    //}

    //public new void Add(T item)
    //{
    //    base.Add(item);
    //    Application.Current.Dispatcher.Invoke(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, Count - 1)));
    //}


}
