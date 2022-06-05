using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCoin : Singleton<PoolCoin>
{
    private CoinCreator _coinCreator;

    protected override void OnStart()
    {
        DoNotNeedUpdate = true;
        base.OnStart();
        _coinCreator = (CoinCreator)MonoBehaviour.FindObjectOfType(typeof(CoinCreator));
    }

    //нужен poolInit дабы при первом вызове не было просадок фпс
    public List<CoinMain> GetAllMainCoins()
    {
        List<CoinMain> coins = new List<CoinMain>();
        foreach (CoinMain coin in _entities)
            if (coin.Main)
                coins.Add(coin);
        return coins;
    }

    public List<CoinMain> GetFreeCoins(int count)
    {
        List<CoinMain> _freeCoins = new List<CoinMain>();
        int FindedCoinCount = 0;

        foreach (CoinMain coin in _entities)
        {
            if (coin.FreeState == true)
            {
                coin.DoNotFreeCoin();
                coin.AnimatorSwitch(true);
                coin.SetAnimationState(CoinAnimatorState.FLY, true);
                _freeCoins.Add(coin);
                FindedCoinCount++;

                if (FindedCoinCount == count)
                    return _freeCoins;
            }
        }
        if (FindedCoinCount < count)
        {
            _freeCoins.AddRange(createListNewCoins(count - FindedCoinCount));
            return _freeCoins;
        }

        return _freeCoins;
    }

    private List<CoinMain> createListNewCoins(int needMoreCount)
    {
        List<CoinMain> newCoins = new List<CoinMain>();

        for (int i = 0; i < needMoreCount; i++)
        {
            CoinData coinData = new CoinData(false, 0, 0, new Vector3(-20f, -20f, -20f));
            newCoins.Add(_coinCreator.CreateNew(coinData, false, false));
        }

        return newCoins;
    }
}
