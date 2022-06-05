using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinData
{
    public bool RichOrNot;
    public int MinimumCoinInside;
    public int MaximumCoinInside;

    public float[] Position;

    public CoinData(CoinMain coin)
    {
        RichOrNot = coin.Rich;
        MinimumCoinInside = coin.AdditionalCoins;
        //MaximumCoinInside = coin.MaxAdditionalCoins;

        Position = new float[3];
        Position[0] = coin.transform.position.x;
        Position[1] = coin.transform.position.y;
        Position[2] = coin.transform.position.z;
    }

    public CoinData(bool rich, int minAddedCoin, int maxAddedCoin, Vector3 position)
    {
        RichOrNot = rich;
        MinimumCoinInside = minAddedCoin;
        MaximumCoinInside = maxAddedCoin;

        Position = new float[3];
        Position[0] = position.x;
        Position[1] = position.y;
        Position[2] = position.z;
    }
}
