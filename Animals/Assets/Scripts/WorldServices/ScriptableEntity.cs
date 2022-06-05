using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableEntity : ScriptableObject, IEntity
{
    protected Storage _storage;

    public ScriptableEntity()
    {
        StorageInit();
        _storage.AddToStorage(this);
    }

    protected abstract void StorageInit();

    protected void OnDisable()
    {
        if (_storage != null)
            _storage.RemoveFromStorage(this);
    }

    protected void OnEnable()
    {
        if (_storage != null)
            _storage.AddToStorage(this);
    }
}
