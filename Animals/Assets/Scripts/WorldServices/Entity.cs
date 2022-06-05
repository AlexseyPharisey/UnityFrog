using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    protected Storage _storage;
    protected void Start()
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
