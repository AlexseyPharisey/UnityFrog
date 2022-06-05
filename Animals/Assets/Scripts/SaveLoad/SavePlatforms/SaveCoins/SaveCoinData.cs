using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveCoinData 
{
    private SerializableCoinDataList _coinDataList;
    private CoinListConverter _coinListConverter;

    public bool TrySaveCoinData(string levelName)
    {
        _coinListConverter = new CoinListConverter();
        _coinDataList = new SerializableCoinDataList(_coinListConverter.Create());

        BinaryFormatter formatter = new BinaryFormatter();
        string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + levelName + ".coin";

        if (System.IO.File.Exists(pathAndName) == false)
        {
            FileStream stream = new FileStream(pathAndName, FileMode.Create);

            formatter.Serialize(stream, _coinDataList);
            stream.Close();

            //тесты, удалить в чистовой версии
            Debug.Log("path " + pathAndName);
            foreach (CoinData coinData in _coinDataList.AllCoinsData)
            {
                Debug.Log("type " + coinData.RichOrNot);
                //Debug.Log("number " + platformData.ExtNumber);
            }
            //тесты, конец

            return true;
        }
        else
        {
            Debug.Log("exist");

            return false;
        }
    }
}
