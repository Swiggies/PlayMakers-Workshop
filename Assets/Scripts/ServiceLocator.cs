﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameService { }

public class ServiceLocator
{
    public static ServiceLocator Current { get; private set; }

    private readonly Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();

    private ServiceLocator()
    {
        Register(new ScoreManager());
        Register(new PlayerManager());
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Current = new ServiceLocator();
        Debug.Log("Service Locator Initialized");
    }

    public void Register<T>(T service) where T : IGameService
    {
        string key = typeof(T).Name;
        if (services.ContainsKey(key))
        {
            Debug.Log($"{key} has already been registered.");
            throw new InvalidOperationException();
        }

        services.Add(key, service);
        Debug.Log($"{key} has been registered.");
    }

    public T Get<T>() where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.Log($"{key} has not been registered as a service.");
            throw new InvalidOperationException();
        }

        return (T)services[key];
    }

    public void Unregister<T>(T service) where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.Log($"{key} has not been registered as a service.");
            throw new InvalidOperationException();
        }

        services.Remove(key);
        Debug.Log($"{key} has been unregistered.");
    }
}
