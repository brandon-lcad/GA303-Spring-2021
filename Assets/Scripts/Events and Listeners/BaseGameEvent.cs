using System.Collections.Generic;
using UnityEngine;

//abstract: whatever it's called on can't be used directly to create anything
//only it's children can
//Using <T> means "generic". The children that inherit can be of any type
public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

    public void Raise(T item)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(item);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }
    
    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}