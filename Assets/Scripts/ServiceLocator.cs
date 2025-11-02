using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _singletonServices = new();
    private static readonly Dictionary<Type, object> _scopedServices = new();
    private static readonly Dictionary<Type, Func<object>> _transientServices = new();

    public static void RegisterSingleton<T>(T service) where T : class
    {
        var type = typeof(T);
        if (IsRegistered(type)) return;
        _singletonServices[type] = service;
    }

    public static void RegisterScoped<T>(T service) where T : class
    {
        var type = typeof(T);
        if (IsRegistered(type)) return;
        _scopedServices[type] = service;
    }

    public static void RegisterTransient<T>(Func<T> factory) where T : class
    {
        var type = typeof(T);
        if (IsRegistered(type)) return;
        _transientServices[type] = factory;
    }

    public static T Get<T>() where T : class
    {
        var type = typeof(T);
        if (_singletonServices.TryGetValue(type, out var singletonService))
        {
            return singletonService as T;
        }

        if (_scopedServices.TryGetValue(type, out var scopedService))
        {
            return scopedService as T;
        }

        if (_transientServices.TryGetValue(type, out var transientService))
        {
            var service = transientService as Func<T>;
            return service!();
        }

        Debug.LogError($"Service of type {type} is not registered");
        return null;
    }
    
    public static void ClearScopedServices()
    {
        _scopedServices.Clear();
    }

    private static bool IsRegistered(Type type)
    {
        var isRegistered = _singletonServices.ContainsKey(type)
                           || _scopedServices.ContainsKey(type)
                           || _transientServices.ContainsKey(type);
        if (isRegistered)
        {
            Debug.LogWarning($"Type {type} is already registered");
        }

        return isRegistered;
    }
}