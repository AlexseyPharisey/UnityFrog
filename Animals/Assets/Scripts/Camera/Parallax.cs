using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float _parallaxPower;
    private float _startPos;
    [SerializeField]
    private GameObject _cam;
    private float dist;
    private ParallaxMove _parallaxMove;

    private void Awake()
    {
        _parallaxMove = (ParallaxMove)FindObjectOfType(typeof(ParallaxMove));
        _parallaxMove.AddParallax(this);
    }

    void Start()
    {
        _startPos = transform.position.y;
    }


    public void ParallaxMove()
    {
        dist = (_cam.transform.position.y * _parallaxPower);
        transform.position = new Vector3(transform.position.x, _startPos + dist, transform.position.z);
    }
}
