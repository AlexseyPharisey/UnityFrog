using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float speed = 5f;

    private void Update()
    {
        Vector3 tmpPos = transform.position;

        if (Input.GetKey("w"))
        {
            tmpPos.y += speed * Time.deltaTime; 
        }

        if (Input.GetKey("s"))
        {
            tmpPos.y -= speed * Time.deltaTime;
        }

        transform.position = tmpPos;
    }
}
