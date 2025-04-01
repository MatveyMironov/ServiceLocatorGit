using System;
using System.Collections.Generic;

public class ServiceLocator : IServiceLocator
{
    private readonly Dictionary<Type, object> _services = new(); 

    public bool TryAddService<T>(T service)
    {
        return _services.TryAdd(typeof(T), service);
    }

    public bool RemoveService<T>()
    {
        return _services.Remove(typeof(T));
    }

    public bool TryGetService<T>(out T service)
    {
        service = default(T);

        if (_services.TryGetValue(typeof(T), out object obj))
        {
            if (obj is T)
            {
                service =(T)obj;

                return true;
            }
        }

        return false;
    }
}
