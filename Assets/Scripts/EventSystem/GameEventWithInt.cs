using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventWithInt", menuName = "Events/GameEventWithInt")]
public class GameEventWithInt : ScriptableObject
{    
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListenerWithInt> eventListeners =
        new List<GameEventListenerWithInt>();

    public void Raise(int param)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(param);
    }

    public void RegisterListener(GameEventListenerWithInt listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerWithInt listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
