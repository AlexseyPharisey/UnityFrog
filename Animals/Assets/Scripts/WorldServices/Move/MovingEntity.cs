using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : Entity, IMovingEntity
{

    //moveSequency? list<ComplexMovement> class ComplexMovement, private Vector3 target, private Easing easing
    public float Speed;// { get; private set; }
    public float SpeedStepUp; // { get; private set; }
    public float LerpPrecent { get; private set; }
    public Vector3 PointToMove { get; private set; }
    public ITarget Target { get; private set; }
    public IEasing Easing { get; private set; }

    public bool UseEasing; // { get; private set; }
    public bool MoveToTarget { get; private set; }
    public bool LerpMove { get; private set; }

    public void SetUp(float speed, bool useEasing, float speedStepUp)
    {
        Speed = speed;
        UseEasing = useEasing;
        SpeedStepUp = speedStepUp;
    }

    public void SetMoveTo(Vector3 moveToPoint, float lerpPrecent)
    {
        PointToMove = moveToPoint;
        MoveToTarget = false;
        UseEasing = false;
        LerpMove = true;
        LerpPrecent = lerpPrecent;
    }
    public void SetMoveTo(Vector3 moveToPoint)
    {
        PointToMove = moveToPoint;
        MoveToTarget = false;
        UseEasing = false;
        LerpMove = false;
    }
    public void SetMoveTo(ITarget target)
    {
        Target = target;
        MoveToTarget = true;
        UseEasing = false;
        LerpMove = false;
    }
    public void SetMoveTo(Vector3 moveToPoint, IEasing easing)
    {
        PointToMove = moveToPoint;
        MoveToTarget = false;
        UseEasing = true;
        Easing = easing;
        LerpMove = false;
    }
    public void SetMoveTo(ITarget target, IEasing easing)
    {
        Target = target;
        MoveToTarget = true;
        UseEasing = true;
        Easing = easing;
        LerpMove = false;
    }

    protected override void StorageInit()
    {
        Mover mover = Mover.Instance;
        _storage = mover.GetStorage();
    }

    public void SetActive(bool value) => enabled = value;
}
