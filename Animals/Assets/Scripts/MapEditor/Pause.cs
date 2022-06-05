using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button pause;
    public static event Action Shoot;
    public static bool GlobalPause { get; private set; }

    private void Start()
    {
        OnOff();
        pause.onClick.AddListener(OnOff);
    }

    public void OnOff()
    {
        GlobalPause = !GlobalPause;
        Shoot?.Invoke();
    }
}
