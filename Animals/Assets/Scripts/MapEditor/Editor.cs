using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    private LevelLoad _levelLoad;
    private GameEnd _gameEnd;

    private void Awake()
    {
        _levelLoad = (LevelLoad)FindObjectOfType(typeof(LevelLoad));
        _gameEnd = (GameEnd)FindObjectOfType(typeof(GameEnd));
    }

    void Start()
    {
        _levelLoad.DoesntNeedLoadLevel();
        _gameEnd.LoseFlagChange();
    }
}
