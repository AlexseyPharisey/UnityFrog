using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : EntityUser where T : class, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
    protected override void ClearInstance()
    {
        base.ClearInstance();
        _instance = null;        
    }
}
