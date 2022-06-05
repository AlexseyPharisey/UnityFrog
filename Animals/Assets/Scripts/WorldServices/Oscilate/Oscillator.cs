using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : Singleton<Oscillator>
{
    private void Move(OscillatingEntity entity, Vector3 targetPoint)
    {
        entity.transform.position = Vector3.MoveTowards
        (
            entity.transform.position,
            targetPoint,
            Time.deltaTime * entity.Speed
        );
        if (Vector3.Distance(entity.transform.position, targetPoint) <= 0.05f)
        {
            entity.ChangeDirection();
        }
    }
    public override void Update()
    {
        foreach (OscillatingEntity entity in _entities)
        {
            Move(entity, entity._direction ? entity.StartPoint : entity.EndPoint);
        }
    }
}
