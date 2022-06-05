using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class SavePlatformData
{
    //private PlatformDataList _platformDataList;
    //private PlatformListConverter _platformListConverter;

    public bool TrySavePlatformData(string levelName)
    {
        PlatformComponentsListCreator allPlatformListCreator = new PlatformComponentsListCreator();
        List<PlatformComponents> allPlatformComponents = allPlatformListCreator.Create();
        PlatformListConverter converter = new PlatformListConverter();
        PlatformDataList platformDataList = new PlatformDataList(converter.Convert(allPlatformComponents));



        //_platformListConverter = new PlatformListConverter();
        //Debug.Log("try save platform data");
        //_platformDataList = new PlatformDataList(_platformListConverter.Create());

        BinaryFormatter formatter = new BinaryFormatter();
        string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + levelName + ".platf";

        if (System.IO.File.Exists(pathAndName) == false)
        {
            FileStream stream = new FileStream(pathAndName, FileMode.Create);

            formatter.Serialize(stream, platformDataList);
            stream.Close();

            //тесты, удалить в чистовой версии
            Debug.Log("path " + pathAndName);
            foreach (PlatformData platformData in platformDataList.AllPlatformsData)
            {
                Debug.Log("type " + platformData.Type);
                Debug.Log("number " + platformData.ExtNumber);
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
