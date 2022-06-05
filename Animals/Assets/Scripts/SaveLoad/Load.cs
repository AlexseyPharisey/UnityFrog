using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(Button))]
public class Load : MonoBehaviour
{
    public Text FileName;
    private Button _loadButton;
    private LevelData _levelData;

    private void Start()
    {
        _loadButton = GetComponent<Button>();
        _loadButton.onClick.AddListener(TryLoad);
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
    }

    /*private void TryLoad()
    {
        Debug.Log("filename " + FileName.text);

        LoadPlatformData loadPlatformData = new LoadPlatformData();
        loadPlatformData.TryLoadPlatformData(FileName.text);
        LoadCoins loadCoins = new LoadCoins();
        loadCoins.TryLoadCoinData(FileName.text);
    }*/

    private void TryLoad()
    {
        //_levelData.Load(int.Parse(FileName.text));
        string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + FileName.text + ".l";
        //Debug.Log("load " + pathAndName);
        if (File.Exists(pathAndName) == true)
        {
            string jsonDataString = File.ReadAllText(pathAndName);
            JsonUtility.FromJsonOverwrite(jsonDataString, _levelData);
        }
    }


    public bool TryLoadExternal(string name)
    {
        Debug.Log("filename " + name);

        LoadPlatformData loadPlatformData = new LoadPlatformData();
        LoadCoins loadCoins = new LoadCoins();
        loadCoins.TryLoadCoinData(name);
        return loadPlatformData.TryLoadPlatformData(name);
    }
}
