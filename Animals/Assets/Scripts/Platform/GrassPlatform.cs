using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlatform : TriggeredPlatform
{
    private MoverLeafParticleSystem _moverLeafParticleSystem;
    private float _halfOfPlatformColliderSize;
    //test
    //private PlatformData _pd;
    //test
    public GrassPlatform(int extentNumb) : base(extentNumb)
    {

    }
    protected override void Awake()
    {
        base.Awake();
        _moverLeafParticleSystem = (MoverLeafParticleSystem)FindObjectOfType(typeof(MoverLeafParticleSystem));
        _halfOfPlatformColliderSize = GetComponent<BoxCollider2D>().size.x / 2f;
        //test
        /*_pd = new PlatformData(this, GetComponent<MovingPlatform>(), 0);
        _pd.Test();*/
    }

    private Vector3 FindPointForLeafs()
    {
        Vector3 tmpLPSPos;
        tmpLPSPos = Player.transform.position;
        tmpLPSPos.y = transform.position.y;
        if (tmpLPSPos.x > transform.position.x + _halfOfPlatformColliderSize)
        {
            tmpLPSPos.x = transform.position.x + _halfOfPlatformColliderSize;
        }
        else if (tmpLPSPos.x < transform.position.x - _halfOfPlatformColliderSize)
        {
            tmpLPSPos.x = transform.position.x - _halfOfPlatformColliderSize;
        }
        return tmpLPSPos;
    }

    protected override void OnCollisionAction()
    {
        Player.ÑhangeStandingOn(PlatformTypes.GRASS);
        //_moverLeafParticleSystem.PlaceAtPoint(FindPointForLeafs());
        LeafParticleSystem _leafParticleSystem;
        _leafParticleSystem = _moverLeafParticleSystem.PlaceAtPoint(FindPointForLeafs());
        if (_leafParticleSystem != null)
        {
            _leafParticleSystem.StartUsing();
        }
    }

    protected override void OnCollisionExitAction()
    {

    }
}
