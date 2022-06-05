using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Singleton<Mover>
{
    private void Move(MovingEntity entity, Vector3 targetPoint, float speedMultiplier)
    {
        entity.transform.position = Vector3.MoveTowards
        (
            entity.transform.position,
            targetPoint,
            Time.deltaTime * entity.Speed * speedMultiplier
        );
    }

    private void LerpMove(MovingEntity entity, Vector3 targetPoint, float lerpPrecent)
    {
        entity.transform.position = Vector3.Lerp
        (
            entity.transform.position,
            targetPoint,
            lerpPrecent
        );
    }

    private void MoveToTarget(MovingEntity entity, ITarget target, float speedMultiplier)
    {
        entity.transform.position = Vector3.MoveTowards
        (
            entity.transform.position,
            target.WorldPosition(),
            Time.deltaTime * entity.Speed * speedMultiplier
        );
    }

    public override void Update()
    {
        foreach (MovingEntity entity in _entities)
        {
            if (entity.LerpMove)
                LerpMove(entity, entity.PointToMove, entity.LerpPrecent);
            else if (entity.MoveToTarget)
                MoveToTarget(entity, entity.Target, entity.UseEasing ? entity.Easing.Step() : 1f);
            else
                Move(entity, entity.PointToMove, entity.UseEasing ? entity.Easing.Step() : 1f);            
        }
    }
}
