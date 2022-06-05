using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings singleton { get; private set; }
    /// <summary>
    /// Заготовка, пока не функционирует
    /// </summary>
    [SerializeField] private float _playerScale;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _distanceBetweenPlatformns;
    [SerializeField] private float _coinStartSpeed;
    [SerializeField] private float _coinSpeedUpStep;
    [SerializeField] private string _pathToLevel;
    [SerializeField] private float _firstPlatformOffset;
    [SerializeField] private float _trampolineAddedJumpStrenght;
    [SerializeField] private float _additionalCoinRange;
    private ITarget _coinTarget;

    private void Awake()
    {
        singleton = this;
        _pathToLevel = "/";
        _coinTarget = (ITarget)FindObjectOfType(typeof(TakeCoinBox));
    }

    public ITarget CoinTarget()
    {
        return _coinTarget;
    }
    public float AdditionalCoinRange()
    {
        return _additionalCoinRange;
    }

    public float TrampolineAddedJumpStrenght()
    {
        return _trampolineAddedJumpStrenght;
    }
    public string PathToLevel()
    {
        return _pathToLevel;
    }
    public float PlayerScale()
    {
        return _playerScale;
    }
    public float JumpStrenght()
    {
        return _jumpStrength;
    }

    public float DistanceBetweenPlatforms()
    {
        return _distanceBetweenPlatformns;
    }

    public float FirstPlatformOffset()
    {
        return _firstPlatformOffset;
    }
    public float CoinStartSpeed()
    {
        return _coinStartSpeed;
    }
    public float CoinSpeedUpStep()
    {
        return _coinSpeedUpStep;
    }
}
