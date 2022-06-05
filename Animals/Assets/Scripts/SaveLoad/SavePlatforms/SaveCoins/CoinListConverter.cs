using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinListConverter
{ 
    public List<CoinData> Create()
    {
        AllCoinListCreator allCoinListCreator = new AllCoinListCreator();
        return FormingCoinDataList(allCoinListCreator.Create());
    }

    private List<CoinData> FormingCoinDataList(List<CoinMain> coins)
    {

        CoinData coinData;
        List<CoinData> coinDataList = new List<CoinData>();
        foreach (CoinMain coin in coins)
        {
            coinData = new CoinData(coin);
            coinDataList.Add(coinData);
        }

        return coinDataList;
    }
}
