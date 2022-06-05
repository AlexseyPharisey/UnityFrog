using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCoinSpawner //: MonoBehaviour
{
    private List<CoinMain> _additionalCoins;
    private PoolCoin _pool;

    private static NewCoinSpawner _instance;

    public static NewCoinSpawner Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new NewCoinSpawner();
            }
            return _instance;
        }
    }
    private NewCoinSpawner()
    {
        Init();
    }

    private void Init()
    {
        if (_pool == null)
            _pool = PoolCoin.Instance;//(PoolCoin)MonoBehaviour.FindObjectOfType(typeof(PoolCoin));
    }
    public void SpawnAdditionalCoins(CoinMain coin/*Vector3 spawnPosition, int count*/)
    {
        Vector3 additionalCoinTarget;
        Vector3 spawnPosition = coin.GetContainerTransform().position;
        int count = coin.AdditionalCoins;//Random.Range(coin.MinAdditionalCoins, coin.MaxAdditionalCoins);

        _additionalCoins = _pool.GetFreeCoins(count);
        foreach (CoinMain addedcoin in _additionalCoins)
        {
            additionalCoinTarget = RandomPointAroundPosition(spawnPosition);
            //addedcoin.transform.position = spawnPosition;
            addedcoin.SetContainerPosition(spawnPosition);
            addedcoin.NewMovement(additionalCoinTarget, 0.2f);
        }

        AdditionalCoinAttendant additionalCoinAttendant = new AdditionalCoinAttendant
            (
                _additionalCoins,
                LevelSettings.singleton.AdditionalCoinRange(),
                LevelSettings.singleton.CoinTarget(),
                spawnPosition
            );
        //вызывает нечто, что принимает список доп монеток и следит как далеко монетки от spawnPosition. и как только монетка достаточно далеко от spawnPosition, переключает её движение на takecoin
    }

    private Vector3 RandomPointAroundPosition(Vector3 position)
    {
        float tmpRad = Random.Range(0f, Mathf.PI * 2);
        float range = LevelSettings.singleton.AdditionalCoinRange() * 1.1f;
        Vector3 RandomPoint = new Vector3(range * Mathf.Cos(tmpRad) + position.x, range * Mathf.Sin(tmpRad) + position.y, 0f);

        return RandomPoint;
    }
}
