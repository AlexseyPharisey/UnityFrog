using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPausable : MonoBehaviour
{
    protected bool _pause;

    protected void OnEnable()
    {
        _pause = Pause.GlobalPause;
        Pause.Shoot += TakeNewPauseState;
    }

    protected void OnDisable()
    {
        Pause.Shoot -= TakeNewPauseState;
    }
    protected void TakeNewPauseState()
    {
        _pause = Pause.GlobalPause;
    }
}
