using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnityEventHelper))]
public class UnityMainEvents : MonoBehaviour
{
    public UnityEvent onStartEvents;
    public UnityEvent onDestroyEvents;
    public UnityEvent onAfterWaitEvents;

    public float waitTime=1; // waits one second 

    void Start()
    {
        onStartEvents.Invoke();
    }

    void OnDestroy()
    {
        onDestroyEvents.Invoke();
    }
}