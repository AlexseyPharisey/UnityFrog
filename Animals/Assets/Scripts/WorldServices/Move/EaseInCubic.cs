using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseInCubic : IEasing
{
    [Range(0f, 1f)]
    private float _speedMultiplier;
    private float _speedChangeStep;

    public EaseInCubic(float speedChangeStep)
    {
        _speedMultiplier = 0;
        _speedChangeStep = speedChangeStep;
    }

    public float Step()
    {
        _speedMultiplier += _speedChangeStep;
        return _speedMultiplier * _speedMultiplier;
    }
}
