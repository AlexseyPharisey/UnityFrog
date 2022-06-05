using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLasersShooter : Singleton<AllLasersShooter>
{
    public override void Update()
    {
        foreach (LaserShoot entity in _entities)
        {
            if (entity.NowIsAShot == true)
            {
                entity.ChangeThikness();
                entity.CheckThikness();
            }
        }
    }
}
