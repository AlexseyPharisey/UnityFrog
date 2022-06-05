using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelData : MonoBehaviour
{
    public int LevelNumber;
    public int Seed;
    public int PlatformQuantity;

    public int[] PlatformTypesWeights = new int[GeneratorConst.PLATFORM_TYPES_COUNT];
    public PlatformSpeed[] PlatformsSpeed = new PlatformSpeed[GeneratorConst.PLATFORM_TYPES_COUNT];
    [Range(1, 10)]
    public int[] PlatformSpeedDisplacement = new int[GeneratorConst.PLATFORM_TYPES_COUNT]; //смещение результата для генератора скорости платформ. Чем ближе к 0 тем чаще выпадает минимальное значение скорости.
    public float[] PlatformAdditionalData = new float[GeneratorConst.PLATFORM_TYPES_COUNT];

    public int[] TrapsCountForType = new int[GeneratorConst.TRAP_TYPES_COUNT]; //{spike, doublespike, shuriken, laser}

    public float[] ShurikenSpeed = new float[2];
    [Range(1, 10)]
    //public int ShurikenSpeedDisplacement;

    public float[] LaserSpeed = new float[2];
    public float[] LaserDelayBetweenShoots = new float[2];
    public float[] LaserThiknesChangeSpeed = new float[2];

    public int CoinsNumber;
    [Range(1, 100)]
    public int RichCoinChance;
    [Range(1, 10)]
    public int AdditionalCoins;
    public int KeysNumber;
    public int ChestNumbers;

    /*public int[] TrapsTypes = new int[GeneratorConst.TRAP_TYPES_COUNT];
public int[] TrapsMinCount = new int[GeneratorConst.TRAP_TYPES_COUNT];
public float[] TrapsMoveSpeed = new float[GeneratorConst.TRAP_TYPES_COUNT];*/
}
