using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityUser : IEntityUser
{
    public static event Action<IEntityUser> NewSingletonEntityUserBorn;
    public bool DoNotNeedUpdate { get; protected set; }
    protected List<IEntity> _entities;
    protected Storage _storage;

    public EntityUser()
    {
        _storage = new Storage();
        _entities = _storage.GetList();
        OnStart();
    }

    public Storage GetStorage() => _storage;

    public virtual void Update() { }

    protected virtual void OnStart()
    {
        if(DoNotNeedUpdate == false)
            NewSingletonEntityUserBorn?.Invoke(this);

        WorldServicesHolder.EndWork += ClearInstance;
    }
    protected void OnEnd() 
    {
        WorldServicesHolder.EndWork -= ClearInstance;
    }
    protected virtual void ClearInstance()
    {
        OnEnd();
    }

}

