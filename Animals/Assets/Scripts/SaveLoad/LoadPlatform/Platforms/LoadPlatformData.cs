using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadPlatformData : MonoBehaviour
{
    private PlatformDataList _platformDataList;
    private PlatformsCreator _platformsCreator;

    public bool TryLoadPlatformData(string levelName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + levelName + ".platf";
        Debug.Log("путь " + pathAndName);

        if (System.IO.File.Exists(pathAndName) == true)
        {
            FileStream stream = new FileStream(pathAndName, FileMode.Open);

            _platformDataList = formatter.Deserialize(stream) as PlatformDataList;
            stream.Close();

            _platformsCreator = (PlatformsCreator)FindObjectOfType(typeof(PlatformsCreator));           
            _platformsCreator.RecreatePlatforms(_platformDataList.AllPlatformsData);

            return true;
        }
        else
        {
            Debug.Log("did not exist");

            return false;
        }
    }
}
