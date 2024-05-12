using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;
namespace USBDevicesLibrary;

public class ThreadSafeDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>, INotifyCollectionChanged where TKey : notnull
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public ThreadSafeDictionary() : base()
    {
        
    }

    public new bool TryAdd(TKey key, TValue value)
    {
        bool response = base.TryAdd(key, value);
        if (response) 
        {
            OnCollectionChanged(action: NotifyCollectionChangedAction.Add, changedItem: new KeyValuePair<TKey, TValue?>(key, value));
        }
        return response;
    }

    public new bool TryRemove(KeyValuePair<TKey, TValue> item)
    {
        bool response = base.TryRemove(item: item);
        if (response)
        {
            OnCollectionChanged(action: NotifyCollectionChangedAction.Remove, changedItem: new KeyValuePair<TKey, TValue?>(item.Key, item.Value));
        }
        return response;
    }

    public new bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        bool response = base.TryRemove(key, out value);
        if (response)
        {
            OnCollectionChanged(action: NotifyCollectionChangedAction.Remove, changedItem: new KeyValuePair<TKey, TValue?>(key, value));
        }
        return response;
    }

    // https://codereview.stackexchange.com/questions/202663/simple-observabledictionary-implementation

    private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue?> changedItem)
    {
        var handler = CollectionChanged;
        Application.Current.Dispatcher.Invoke(() =>
        handler?.Invoke(this, new NotifyCollectionChangedEventArgs(action: action, changedItem: changedItem)));
    }

   

}
