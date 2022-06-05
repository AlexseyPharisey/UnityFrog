using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CloudPlatform : TriggeredPlatform
{
    [SerializeField]
    private float _fadeSpeed;

    public CloudPlatform(int extentNumb) : base(extentNumb)
    {

    }
    public override T NonInheritedData<T>()
    {
        return (T)Convert.ChangeType(_fadeSpeed, typeof(T));
    }
    public override void InitializationAfterLoad(float fadeSpeed)
    {
        _fadeSpeed = fadeSpeed;
    }
    protected override void OnCollisionAction()
    {
        Player.ÑhangeStandingOn(PlatformTypes.CLOUD);
        CloudFading cloudFading = gameObject.AddComponent(typeof(CloudFading)) as CloudFading;
        cloudFading.SetFadeSpeed(_fadeSpeed);
        cloudFading.SetPlayer(Player);
    }
    protected override void OnCollisionExitAction()
    {
    }
}
