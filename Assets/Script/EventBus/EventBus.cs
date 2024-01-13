using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventBus : IService
{
    private const int PRIORITY_DEFAULT = -1;
    private readonly Dictionary<System.Type, List<CallbackWithPriority>> _events;
    private readonly bool _isEnablePriority;
    public EventBus(bool isPriority = false)
    {
        _events = new Dictionary<Type, List<CallbackWithPriority>>();
        _isEnablePriority = isPriority;
    }
    public void Subscribe<T>(Action<T> action, int priority = PRIORITY_DEFAULT)
    {
        var type = typeof(T);
        var callback = new CallbackWithPriority(action, priority);
        if (this.ContainType<T>())
            _events[type].Add(callback);
        else
            _events.Add(type, new List<CallbackWithPriority>() { callback });

        if (this._isEnablePriority)
            _events[type] = _events[type].OrderByDescending(c => c.Priority).ToList();
    }
    public void Unsubcribe<T>(Action<T> action)
    {
        var type = typeof(T);
        if (this.ContainType<T>())
        {
            var callbackToDelete = _events[type].FirstOrDefault(
                c => c.Callback.Equals(action));
            if(callbackToDelete != null)
                _events[type].Remove(callbackToDelete);
        }
        else
            Debug.LogError($"События c сигналом {type.Name} не существует");
    }
    public void Invoke<T>(T signal)
    {
        var type = typeof(T);
        if (this.ContainType<T>())
        {
            foreach(var obj in _events[type])
            {
                var callback = obj.Callback as Action<T>;
                callback?.Invoke(signal);
            }
        }
    }
    public bool ContainType<T>()
    {
        return _events.ContainsKey(typeof(T));
    }
}
