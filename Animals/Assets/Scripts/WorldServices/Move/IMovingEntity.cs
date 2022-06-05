using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovingEntity
{
    void SetUp(float speed, bool useEasing, float speedStepUp);
    void SetMoveTo(Vector3 moveToPoint, float lerpPrecent);
    void SetMoveTo(Vector3 moveToPoint);
    void SetMoveTo(ITarget target);
    void SetMoveTo(Vector3 moveToPoint, IEasing easing);
    void SetMoveTo(ITarget target, IEasing easing);

    void SetActive(bool value);
}
