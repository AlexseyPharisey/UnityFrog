using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OscillatingEntity))]
public class Shuriken : Trap
{
    const float ROTATION_SPEED = 500;
    private float rotation = 0;
    private LevelData _levelData;
    private LevelSettings _levelSettings;
    protected override void Awake()
    {
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
        _levelSettings = (LevelSettings)FindObjectOfType(typeof(LevelSettings));
    }

    public override void Initialization(int myPlatformNumber)
    {
        var oscilatingTrap = GetComponent<OscillatingEntity>();
        Vector3 StartPoint = new Vector3(0, myPlatformNumber * _levelSettings.DistanceBetweenPlatforms(), 0);
        Vector3 EndPoint = new Vector3(0, myPlatformNumber * _levelSettings.DistanceBetweenPlatforms(), 0);
        StartPoint.x = GeneratorConst.PLATFORM_X_BORDER * -1;
        EndPoint.x = GeneratorConst.PLATFORM_X_BORDER;
        oscilatingTrap.SetUp(Random.Range(_levelData.ShurikenSpeed[0], _levelData.ShurikenSpeed[1]), StartPoint, EndPoint);

        transform.position = StartPoint;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0 ,0 , rotation += ROTATION_SPEED * Time.deltaTime);
    }
}
