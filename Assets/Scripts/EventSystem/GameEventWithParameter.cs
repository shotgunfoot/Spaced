using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventWithParameter: ScriptableObject
{
    public GameObject objectToPass;

    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListenerWithParameter> eventListeners =
        new List<GameEventListenerWithParameter>();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(objectToPass);
    }

    public void RegisterListener(GameEventListenerWithParameter listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerWithParameter listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
