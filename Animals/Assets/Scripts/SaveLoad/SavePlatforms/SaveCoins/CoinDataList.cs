using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableCoinDataList
{ 
    public List<CoinData> AllCoinsData;

    public SerializableCoinDataList(List<CoinData> someCoinDataList)
    {
        AllCoinsData = someCoinDataList;
    }
}
