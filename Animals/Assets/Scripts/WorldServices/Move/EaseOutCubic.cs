using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseOutCubic : IEasing
{
    [Range(0f, 1f)]
    private float _speedMultiplier;
    private float _speedChangeStep;

    public EaseOutCubic(float speedChangeStep)
    {
        _speedMultiplier = 1f;
        _speedChangeStep = speedChangeStep;
    }
    public float Step()
    {
        _speedMultiplier -= _speedChangeStep;
        if (_speedMultiplier < 0.05f)
            _speedMultiplier = 0.05f;
        return 1 - Mathf.Pow(1 - _speedMultiplier, 3);
    }
}
