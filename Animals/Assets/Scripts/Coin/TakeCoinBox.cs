using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoinBox : MonoBehaviour, ITarget
{
    public Vector3 myWorldPos;
    private float cameraOffset;
    void Start()
    {
        cameraOffset = 0.3f; //сделать динамический пересчет
    }

    public Vector3 WorldPosition()
    {
        myWorldPos = transform.position;
        myWorldPos.y -= cameraOffset;
        return myWorldPos;
    }
}
