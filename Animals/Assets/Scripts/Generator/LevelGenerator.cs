using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private LevelData _levelData;
    private PlatformCreator _platformCreator;
    private TrapCreator _trapCreator;
    private CoinCreator _coinCreator;

    private void Awake()
    {
        _platformCreator = (PlatformCreator)FindObjectOfType(typeof(PlatformCreator));
        _trapCreator = (TrapCreator)FindObjectOfType(typeof(TrapCreator));
        _coinCreator = (CoinCreator)FindObjectOfType(typeof(CoinCreator));
    }
    void Start()
    {
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
        Generate();
    }

    public void Generate()
    {
        int tmpType;
        //float tmpSpeed;
        //float tmpX;
        for (int i = 1; i < _levelData.PlatformQuantity; i++)
        {
            UnityEngine.Random.InitState(_levelData.Seed + i);
            tmpType = TypeSelection();
            _platformCreator.Create(i, tmpType, SpeedSelection(tmpType), XCordinateSelection(), _levelData.PlatformAdditionalData[tmpType]);
            
        }

        for (int i = 0; i < _levelData.TrapsCountForType.Length; i++)
        {
            TrapSpawner(i);
        }

        for (int i = 0; i < _levelData.CoinsNumber; i++)
        {
            UnityEngine.Random.InitState(_levelData.Seed + i * 3  + 10);
            _coinCreator.Create(UnityEngine.Random.Range(1, _levelData.PlatformQuantity));
        }
        //вычисляем шанс спавна для сущности
        //проходим все платформы пытаясь заспавнить с шансом, если не заспавнили, проходим еще раз пока не заспавним
        //вызываем спавнер
    }

    private void TrapSpawner(int type)
    {
        List<int> platformNumbers = new List<int>();
        int tmpPlatformNumber;
        int seedChanger = 1000;
        for (int i = 0; i < _levelData.TrapsCountForType[type]; i++)
        {
            UnityEngine.Random.InitState(_levelData.Seed + i*2 + type*2 + seedChanger++);
            tmpPlatformNumber = UnityEngine.Random.Range(1, _levelData.PlatformQuantity);
            while (TrapIndexComprasion(platformNumbers, tmpPlatformNumber))
            {
                UnityEngine.Random.InitState(_levelData.Seed + i * 2 + seedChanger++);
                tmpPlatformNumber = UnityEngine.Random.Range(1, _levelData.PlatformQuantity);
            }

            _trapCreator.Create(type, tmpPlatformNumber);
        }
    }

    private bool TrapIndexComprasion(List<int> platformNumbers, int currentNumber)
    {
        for (int i = 0; i < platformNumbers.Count; i++)
        {
            if (platformNumbers[i] == currentNumber)
            {
                return true;
            }
        }
        return false;
    }

    private float XCordinateSelection()
    {
        return UnityEngine.Random.Range(GeneratorConst.PLATFORM_X_BORDER * -1, GeneratorConst.PLATFORM_X_BORDER);
    }

    private float SpeedSelection(int type)
    {
        int repeatNumbers = _levelData.PlatformSpeedDisplacement[type] - GeneratorConst.PLATFORM_SPEED_DISPLACEMENT_MAX / 2;
        float displacementResult;
        float tmpResult;

        if (repeatNumbers > 0)
        {
            displacementResult = 0;
            for (int i = 0; i < repeatNumbers; i++)
            {
                tmpResult = UnityEngine.Random.Range(_levelData.PlatformsSpeed[type].Min, _levelData.PlatformsSpeed[type].Max);
                if (displacementResult < tmpResult)
                {
                    displacementResult = tmpResult;
                }
            }
            return displacementResult;
        }
        else
        {
            displacementResult = _levelData.PlatformsSpeed[type].Max;
            for (int i = 0; i < Mathf.Abs(repeatNumbers); i++)
            {
                tmpResult = UnityEngine.Random.Range(_levelData.PlatformsSpeed[type].Min, _levelData.PlatformsSpeed[type].Max);
                if (displacementResult > tmpResult)
                {
                    displacementResult = tmpResult;                   
                }
            }
            return displacementResult;
        }
    }

    private int TypeSelection()
    {
        int random = UnityEngine.Random.Range(1,100);
        int baseWeight = 0; 
        for (int i = 0; i < _levelData.PlatformTypesWeights.Length; i++)
        {
            baseWeight += _levelData.PlatformTypesWeights[i];
            if (random <= baseWeight)
            {
                return i;
            }
        }
        return 1;
    }
}
