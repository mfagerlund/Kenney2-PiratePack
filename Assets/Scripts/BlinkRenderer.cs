using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkRenderer : MonoBehaviour
{
    private float _startTime = 0;
    public Renderer Renderer;
    public float blinkDuration = 2;
    public float blinkFrequency = 2;
    void Start()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        if (Renderer == null)
        {
            return;
        }
        float elapsed = Time.time - _startTime;
        if (elapsed > blinkDuration)
        {
            Renderer.enabled = true;
            enabled = false;
        }
        Renderer.enabled = ((elapsed * blinkFrequency) % 1) < 0.5;
    }
}
