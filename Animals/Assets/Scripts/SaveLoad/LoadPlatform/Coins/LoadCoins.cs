using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadCoins : MonoBehaviour
{
    private SerializableCoinDataList _dataList;
    private CoinCreator _creator;

    public bool TryLoadCoinData(string levelName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + levelName + ".coin";

        if (System.IO.File.Exists(pathAndName) == true)
        {
            FileStream stream = new FileStream(pathAndName, FileMode.Open);

            _dataList = formatter.Deserialize(stream) as SerializableCoinDataList;
            stream.Close();

            _creator = (CoinCreator)FindObjectOfType(typeof(CoinCreator));
            _creator.RecreateCoins(_dataList.AllCoinsData);

            return true;
        }
        else
        {
            //pathAndName
            Debug.Log(pathAndName);
            Debug.Log("did not exist");

            return false;
        }
    }
}
