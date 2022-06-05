using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampPlatform : TriggeredPlatform
{
    public SwampPlatform(int extentNumb) : base(extentNumb)
    {

    }

    protected override void OnCollisionAction()
    {
        Player.�hangeStandingOn(PlatformTypes.SWAMP);
        //Player.InSwampStateChange();
        Debug.Log("�����");
    }
    protected override void OnCollisionExitAction()
    {
        //Player.InSwampStateChange();
        Debug.Log("����� 2");
    }
}
