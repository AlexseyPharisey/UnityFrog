using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaserData
{
    public float DelayBetweenStrikes;
    public float StrikeThicknessChangeSpeed;
    public float StrikeThiknessMax;
    public float[] Position;
    //OscilatingEntity
    public float Speed;
    public float[] StartPoint;
    public float[] EndPoint;

    public LaserData (Laser laser, OscillatingEntity oscillatingEntity)
    {
        Position = new float[3];
        Position[0] = laser.transform.position.x;
        Position[1] = laser.transform.position.y;
        Position[2] = laser.transform.position.z;

        Speed = oscillatingEntity.Speed;

        StartPoint = new float[3];
        StartPoint[0] = oscillatingEntity.StartPoint.x;
        StartPoint[1] = oscillatingEntity.StartPoint.y;
        StartPoint[2] = oscillatingEntity.StartPoint.z;

        EndPoint = new float[3];
        EndPoint[0] = oscillatingEntity.EndPoint.x;
        EndPoint[1] = oscillatingEntity.EndPoint.y;
        EndPoint[2] = oscillatingEntity.EndPoint.z;
    }
}
