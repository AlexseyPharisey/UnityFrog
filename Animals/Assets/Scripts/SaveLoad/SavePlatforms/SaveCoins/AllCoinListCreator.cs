using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllCoinListCreator : MonoBehaviour
{
    private PoolCoin _poolCoin;
    private void InitCoinManager()
    {
        _poolCoin = PoolCoin.Instance;//(PoolCoin)FindObjectOfType(typeof(PoolCoin));
    }
    public List<CoinMain> Create()
    {
        InitCoinManager();
        List<CoinMain> onlyMainCoins = _poolCoin.GetAllMainCoins();

        return onlyMainCoins;
    }
}
