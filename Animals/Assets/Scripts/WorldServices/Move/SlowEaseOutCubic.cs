using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEaseOutCubic : IEasing
{
    [Range(0f, 1f)]
    private float _speedMultiplier;
    private float _speedChangeStep;

    public SlowEaseOutCubic(float speedChangeStep)
    {
        _speedMultiplier = 1f;
        _speedChangeStep = speedChangeStep * 0.1f;
    }
    public float Step()
    {
        _speedMultiplier -= _speedChangeStep;
        if (_speedMultiplier < 0.05f)
            _speedMultiplier = 0.05f;
        return 1 - Mathf.Pow(1 - _speedMultiplier, 3); ;
    }
}
