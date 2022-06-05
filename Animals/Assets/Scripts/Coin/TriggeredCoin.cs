using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinMain))]
public class TriggeredCoin : MonoBehaviour
{
    private CoinMain _coinMain;
    private TakeCoinBox _takeCoinBox;
    private CoinCountUI _coinCountUI;

    private bool _touchedByPlayer;

    private void Awake()
    {
        _takeCoinBox = (TakeCoinBox)FindObjectOfType(typeof(TakeCoinBox));
        _coinCountUI = (CoinCountUI)FindObjectOfType(typeof(CoinCountUI));
    }

    private void Start()
    {
        _coinMain = GetComponent<CoinMain>();
    }

    private void ResetCoin()
    {
        _coinMain.FreeingCoin();
        _touchedByPlayer = false;
        _coinMain.Main = false;
        _coinMain.StopMove();
        _coinMain.SetContainerPosition(new Vector3(-20f, -20f, -20f));
        _coinMain.AnimatorSwitch(false);
        //_coinMain.SetAnimationState(CoinAnimatorState.FLY, false);
        //gameObject.SetActive(false);
        _coinCountUI.UpdateCoinCount();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HasComponent.Check<Player>(collision.gameObject)
            && _coinMain.Main
            && _touchedByPlayer == false)
        {
            _coinMain.SetAnimationState(CoinAnimatorState.JUMP, true);
            _touchedByPlayer = true;
            if (_coinMain.Rich)
            {
                NewCoinSpawner coinSpawner = NewCoinSpawner.Instance;
                coinSpawner.SpawnAdditionalCoins(_coinMain);
            }
        }

        if (HasComponent.Check<TakeCoinBox>(collision.gameObject))
        {
            ResetCoin();
        }
    }

    /// <summary>
    /// Запускается аниматором при окончании анимции "CoinJump"
    /// </summary>
    public void FlyBegins()
    {
        _coinMain.SetAnimationState(CoinAnimatorState.JUMP, false);
        _coinMain.SetAnimationState(CoinAnimatorState.FLY, true);
        _coinMain.NewMovement(_takeCoinBox, new EaseInCubic(LevelSettings.singleton.CoinSpeedUpStep()));
    }

}
