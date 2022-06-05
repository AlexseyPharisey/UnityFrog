using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformData
{
    //берется из BasePlatform
    public string Type;
    public int ExtNumber;
    public float[] Position;
    public float[] Scale;
    //OscilatingEntity
    public float Speed;
    public float[] StartPoint;
    public float[] EndPoint;

    //У каждого вида платформ это свое поле или его вообще нет
    public float NonInheritedData;

    public PlatformData(string type, int extNumber, float positionX, float positionY, float positionZ, float[] scale, float speed, /*float rightBorder, float leftBorder, bool canMove,*/ float nonInheritedData, Vector3 startPoint, Vector3 endPoint)
    {
        Type = type;
        ExtNumber = extNumber;

        Position = new float[3];
        Position[0] = positionX;
        Position[1] = positionY;
        Position[2] = positionZ;

        Scale = new float[3];
        Scale[0] = scale[0];
        Scale[1] = scale[1];
        Scale[2] = scale[2];

        Speed = speed;

        //RightBorder = rightBorder;
        //LeftBorder = leftBorder;
        //CanMove = canMove;

        NonInheritedData = nonInheritedData;

        StartPoint = new float[3];
        StartPoint[0] = startPoint.x;
        StartPoint[1] = startPoint.y;
        StartPoint[2] = startPoint.z;

        EndPoint = new float[3];
        EndPoint[0] = endPoint.x;
        EndPoint[1] = endPoint.y;
        EndPoint[2] = endPoint.z;
    }
    /*public PlatformData(BasePlatform platform, MovingPlatform movingPlatform)
    {
        //Debug.Log("wat? " + platform);
        //Debug.Log("wat2? " + movingPlatform);
        //Debug.Log("num? " + movingPlatform);
        ExtNumber = platform.ExtensionNumber;
        Type = platform.GetType().Name;

        Position = new float[3];
        Position[0] = platform.transform.position.x;
        Position[1] = platform.transform.position.y;
        Position[2] = platform.transform.position.z;

        Scale = new float[3];
        Scale[0] = platform.transform.localScale.x;
        Scale[1] = platform.transform.localScale.y;
        Scale[2] = platform.transform.localScale.z;

        Speed = movingPlatform.Speed;
        RightBorder = movingPlatform.RightBorder;
        LeftBorder = movingPlatform.LeftBorder;
        //CanMove = movingPlatform.CanMove;

        NonInheritedData = platform.NonInheritedData<float>();
    }*/

    public PlatformData(TriggeredPlatform platform, OscillatingEntity oscillatingEntity)
    {
        //Debug.Log("wat? " + platform);
        //Debug.Log("wat2? " + movingPlatform);
        //Debug.Log("num? " + movingPlatform);
        ExtNumber = platform.ExtensionNumber;
        Type = platform.GetType().Name;

        Position = new float[3];
        Position[0] = platform.transform.position.x;
        Position[1] = platform.transform.position.y;
        Position[2] = platform.transform.position.z;

        Scale = new float[3];
        Scale[0] = platform.transform.localScale.x;
        Scale[1] = platform.transform.localScale.y;
        Scale[2] = platform.transform.localScale.z;

        Speed = oscillatingEntity.Speed;

        StartPoint = new float[3];
        StartPoint[0] = oscillatingEntity.StartPoint.x;
        StartPoint[1] = oscillatingEntity.StartPoint.y;
        StartPoint[2] = oscillatingEntity.StartPoint.z;

        EndPoint = new float[3];
        EndPoint[0] = oscillatingEntity.EndPoint.x;
        EndPoint[1] = oscillatingEntity.EndPoint.y;
        EndPoint[2] = oscillatingEntity.EndPoint.z;
        //CanMove = movingPlatform.CanMove;

        NonInheritedData = platform.NonInheritedData<float>();
    }
}
