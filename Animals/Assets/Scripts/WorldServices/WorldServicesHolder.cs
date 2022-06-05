using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WorldServicesHolder : MonoPausable
{
    public static event Action EndWork;
    private List<IEntityUser> _entityUsersForUpdate = new List<IEntityUser>();
    private new void OnEnable()
    {
        base.OnEnable();
        EntityUser.NewSingletonEntityUserBorn += AddNewEntityUser;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        EntityUser.NewSingletonEntityUserBorn -= AddNewEntityUser;
        EndWork?.Invoke();
    }

    private void AddNewEntityUser(IEntityUser singletonEntityUser)
    {
        _entityUsersForUpdate.Add(singletonEntityUser);
    }

    private void Update()
    {
        if (_pause == false)
        {
            foreach (IEntityUser user in _entityUsersForUpdate.ToList())
            {
                user.Update();
            }
        }
    }
}
