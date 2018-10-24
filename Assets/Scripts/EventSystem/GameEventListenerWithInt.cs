using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventListenerWithInt : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventWithInt Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEventWithInt Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(int n)
    {
        Response.Invoke(n);
    }
}
