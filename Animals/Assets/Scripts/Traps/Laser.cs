using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LaserShoot)), RequireComponent(typeof(OscillatingEntity))]
public class Laser : Trap, ICooldownable, ILaserShooter
{
    [SerializeField] private GameObject _beamPart;
    [SerializeField] private float _delayBetweenStrike;
    [SerializeField] private float _strikeThicknessChangeSpeed;
    [SerializeField] private float _strikeThicknessMax;
    private LevelData _levelData;
    private LevelSettings _levelSettings;
    private Player _player;
    private LaserShoot _laserShoot;

    protected override void Awake()
    {
        base.Awake();
        _laserShoot = GetComponent<LaserShoot>();
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
        _levelSettings = (LevelSettings)FindObjectOfType(typeof(LevelSettings));
        _player = (Player)FindObjectOfType(typeof(Player));
        StartShooting();
    }

    public override void Initialization(int myPlatformNumber)
    {
        _delayBetweenStrike = Random.Range(_levelData.LaserDelayBetweenShoots[0], _levelData.LaserDelayBetweenShoots[1]);
        _strikeThicknessChangeSpeed = Random.Range(_levelData.LaserThiknesChangeSpeed[0], _levelData.LaserThiknesChangeSpeed[1]);
        
        var oscilatingTrap = GetComponent<OscillatingEntity>();
        Vector3 laserStartPoint = new Vector3(0, 0, 0);
        Vector3 laserEndPoint = new Vector3(0, 0, 0);
        laserStartPoint.y = myPlatformNumber * _levelSettings.DistanceBetweenPlatforms() + _levelSettings.FirstPlatformOffset() + _player.GetComponent<BoxCollider2D>().size.y * _player.transform.localScale.y * 1.5f;
        laserEndPoint.y = (myPlatformNumber + 1) * _levelSettings.DistanceBetweenPlatforms() + _levelSettings.FirstPlatformOffset() - _player.GetComponent<BoxCollider2D>().size.y * _player.transform.localScale.y;
        transform.position = laserStartPoint;

        oscilatingTrap.SetUp(
            Random.Range(_levelData.LaserSpeed[0], _levelData.LaserSpeed[1]),
            laserStartPoint,
            laserEndPoint);
    }
    /*public void LaserInit(float delay, float thiknessChangeSpeed)
    {
        _delayBetweenStrike = delay;
        _strikeThicknessChangeSpeed = thiknessChangeSpeed;
    }*/

    public void CooldownStart()
    {
        new Cooldown(this, _delayBetweenStrike);
    }

    public void CooldownEnd()
    {        
        StartShooting();
    }

    public void StartShooting()
    {
        _beamPart.SetActive(true);
        _laserShoot.StartNewShoot(_strikeThicknessChangeSpeed, _strikeThicknessMax, _beamPart, this);
    }

    public void EndShooting()
    {
        _beamPart.SetActive(false);
        CooldownStart();
    }




    //стартуем
    //запускаем отсчет до выстрела
    //старт выстрела
    //размеры beamPart увеличиваются со _strikeSpeed
    //дошли до максимума размера
    //уменьшаем beamPart с скоростью _strikeSpeed
    //если размеры меньше 0.15, то ставим beamPart в disable
    //запускаем отсчет до выстрела
}
