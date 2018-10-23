using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerWithParameter : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventWithParameter Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEventWithParameter Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(GameObject obj)
    {
        Response.Invoke(obj);
    }
}
