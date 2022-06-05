using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : TriggeredPlatform
{
    public StartPlatform(int extentNumb) : base(extentNumb)
    {

    }

    protected override void OnCollisionAction()
    {
        Player.ÑhangeStandingOn(PlatformTypes.START);
    }
    protected override void OnCollisionExitAction()
    {

    }
}
