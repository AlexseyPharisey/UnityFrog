using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage
{
    private List<IEntity> _entities;

    public Storage()
    {
        _entities = new List<IEntity>();
    }

    public void AddToStorage(IEntity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveFromStorage(IEntity entity)
    {
        _entities.Remove(entity);
    }

    public List<IEntity> GetList()
    {
        return _entities;
    }
}
