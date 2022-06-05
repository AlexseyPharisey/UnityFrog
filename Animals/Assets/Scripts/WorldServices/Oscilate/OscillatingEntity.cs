using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingEntity : Entity
{
    public float Speed;// { get; private set; }
    public Vector3 StartPoint;// { get; private set; }
    public Vector3 EndPoint;// { get; private set; }
    public bool _direction { get; private set; }
    public void SetUp(float speed, Vector3 startPoint, Vector3 endPoint)
    {
        Speed = speed;
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public void ChangeDirection()
    {
        _direction = !_direction;
    }

    protected override void StorageInit()
    {
        //EntityUser oscillator = (Oscillator)FindObjectOfType(typeof(Oscillator));
        Oscillator oscillator = Oscillator.Instance;
        _storage = oscillator.GetStorage();
    }
}
