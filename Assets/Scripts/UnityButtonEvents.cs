using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnityEventHelper))]
public class UnityButtonEvents : MonoBehaviour
{
    public string buttonName = "Fire1";
    public UnityEvent buttonUpEvents;
    public UnityEvent buttonDownEvents;
    public UnityEvent buttonEvents;

    public void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            if (buttonDownEvents != null)
            {
                buttonDownEvents.Invoke();
            }
        }
        if (Input.GetButtonUp(buttonName))
        {
            if (buttonUpEvents != null)
            {
                buttonUpEvents.Invoke();
            }
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetButton(buttonName))
        {
            if (buttonEvents != null)
            {
                buttonEvents.Invoke();
            }
        }
    }
}