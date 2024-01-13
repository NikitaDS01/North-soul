using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private readonly Dictionary<System.Type, IService> _services;
    public ServiceLocator()
    {
        _services = new Dictionary<System.Type, IService>();
    }

    private static ServiceLocator _current = null;
    public static ServiceLocator Singleton => _current;
    public static void Init()
    {
        if( _current == null )
            _current = new ServiceLocator();
    }
    public T Get<T>() where T : IService
    {
        var type = typeof(T);
        if (this.ContainType<T>())
            return (T)_services[type];

        Debug.LogError($"Ключ {type.Name} не существует");
        throw new System.Exception();
    }
    public void Register<T>(T service) where T : IService
    {
        var type = typeof(T);
        if (this.ContainType<T>())
            Debug.LogError($"Ключ {type.Name} существует");
        _services.Add(type, service);
    }
    public void Unregister<T>() where T : IService
    {
        var type = typeof(T);
        if (!this.ContainType<T>())
            Debug.LogError($"Ключ {type.Name} не существует");
        _services.Remove(type);        
    }
    public bool ContainType<T>()
    {
        return _services.ContainsKey(typeof(T));
    }
}
