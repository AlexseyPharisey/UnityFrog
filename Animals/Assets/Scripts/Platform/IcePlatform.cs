using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IcePlatform : TriggeredPlatform
{
    [SerializeField]
    private float _slideSpeed;
    private PlayerSlide _playerSlide;

    public IcePlatform(int extentNumb) : base(extentNumb)
    {

    }

    protected override void Awake()
    {
        base.Awake();
        _playerSlide = Player.GetComponent<PlayerSlide>();
    }
    public override T NonInheritedData<T>()
    {
        return (T) Convert.ChangeType(_slideSpeed, typeof(T));
    }

    public override void InitializationAfterLoad(float slideSpeed)
    {
        _slideSpeed = slideSpeed;
    }
    //public void Sliding()
    //{
        
    //}
    protected override void OnCollisionAction()
    {
        Player.ÑhangeStandingOn(PlatformTypes.ICE);
        _playerSlide.enabled = true;
        _playerSlide.SetSlideSpeed(_slideSpeed);
    }
    protected override void OnCollisionExitAction()
    {
        _playerSlide.enabled = false;
        if (JumpPlayer.InJump == false)
        {
            _playerSlide.GetComponent<Lose>().Checking();
        }
    }
}
