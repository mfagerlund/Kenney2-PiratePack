using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnityEventHelper))]
public class UnityPhysicsEvents : MonoBehaviour
{
    public UnityEvent onCollisionEnter2DEvents;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (onCollisionEnter2DEvents != null)
        {
            onCollisionEnter2DEvents.Invoke();
        }
    }
}