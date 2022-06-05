using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinePlatform : TriggeredPlatform
{
    //private 

    public TrampolinePlatform(int extentNumb) : base(extentNumb)
    {

    }

    protected override void Awake()
    {
        base.Awake();
        //_playerSlide = Player.GetComponent<PlayerSlide>();
        //test
        /*_pd = new PlatformData(this, GetComponent<MovingPlatform>(), 1);
        _pd.Test();*/
    }
    protected override void OnCollisionAction()
    {
        Player.ÑhangeStandingOn(PlatformTypes.TRAMPOLINE);
    }

    protected override void OnCollisionExitAction()
    {

    }
}
