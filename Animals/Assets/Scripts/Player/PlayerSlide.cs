using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoPausable
{
    private float _slideSpeed;

    void Update()
    {
        if(_pause == false)
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, Time.deltaTime * _slideSpeed);
    }

    public void SetSlideSpeed(float slideSpeed)
    {
        _slideSpeed = slideSpeed;
    }
}
