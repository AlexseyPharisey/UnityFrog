using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : Entity
{
    private GameObject _beamPart;
    public bool NowIsAShot { get; private set; }
    public bool Increases { get; private set; }
    public float StrikeThicknessChangeSpeed { get; private set; }
    public float StrikeThicknessMax { get; private set; }

    private float sign;
    private ILaserShooter _laserShooter;

    public void StartNewShoot(float strikeThicknessChangeSpeed, float strikeThicknessMax, GameObject beamPart, ILaserShooter laserShooter)
    {
        if (NowIsAShot == false)
        {
            NowIsAShot = true;
            StrikeThicknessChangeSpeed = strikeThicknessChangeSpeed;
            StrikeThicknessMax = strikeThicknessMax;
            _laserShooter = laserShooter;
            sign = 1;
            Increases = true;
            if (_beamPart == null)
            {
                _beamPart = beamPart;
            }
        }
    }

    public void ChangeThikness()
    {
        Vector3 updatedScale = _beamPart.transform.localScale;
        updatedScale.y += StrikeThicknessChangeSpeed * Time.deltaTime * sign;
        _beamPart.transform.localScale = updatedScale;
        //Debug.Log("updatedScale " + updatedScale);
    }

    public void CheckThikness()
    {
        if (_beamPart.transform.localScale.y >= StrikeThicknessMax)
        {
            Increases = false;
            sign = -1;
        }
        if (_beamPart.transform.localScale.y <= 0.15f)
        {
            _laserShooter.EndShooting();
            NowIsAShot = false;
        }
    }

    protected override void StorageInit()
    {
        AllLasersShooter cooldownExecutor = AllLasersShooter.Instance;
        _storage = cooldownExecutor.GetStorage();
    }
}
