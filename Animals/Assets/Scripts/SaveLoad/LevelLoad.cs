using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    private bool _needLoad = true;
    private Load _load;
    //временно публичная, потом будем это из playerprefs
    public string levelName;
    private void Awake()
    {
        _load = (Load)FindObjectOfType(typeof(Load));
    }

    public void DoesntNeedLoadLevel()
    {
        _needLoad = false;
    }
    private void Start()
    {
        if(_needLoad)
            _load.TryLoadExternal(levelName);
    }

}
