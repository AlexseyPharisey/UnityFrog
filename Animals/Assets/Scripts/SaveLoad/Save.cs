using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(Button))]
public class Save : MonoBehaviour
{
    public Text FileName;
    private Button _saveButton;
    private LevelData _levelData;

    private void Start()
    {
        _saveButton = GetComponent<Button>();
        //_saveButton.onClick.AddListener(TrySave);
        //новый сейв   
        _levelData = (LevelData)FindObjectOfType(typeof(LevelData));
        _saveButton.onClick.AddListener(TryNewSave);
    }

    private void TryNewSave()
    {
       // _levelData.Save();
        if (DataCheck())
        {
            string jsonDataString = JsonUtility.ToJson(this, true);
            Debug.Log("res " + jsonDataString);

            string pathAndName = Application.persistentDataPath + LevelSettings.singleton.PathToLevel() + _levelData.LevelNumber + ".l";

            if (File.Exists(pathAndName) == true)
            {
                if (_saveButton.GetComponent<Image>().color == Color.red)
                {
                    Debug.Log("path " + pathAndName);
                    File.WriteAllText(pathAndName, jsonDataString);
                    _saveButton.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    _saveButton.GetComponent<Image>().color = Color.red;
                    Debug.Log("Уже существует. Перезаписать? " + pathAndName);
                }
            }
            else 
            {
                Debug.Log("path " + pathAndName);
                File.WriteAllText(pathAndName, jsonDataString);
                //_saveButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    private bool DataCheck()
    {
        int tmpWeight = 0;
        foreach (int weight in _levelData.PlatformTypesWeights)
        {
            tmpWeight += weight;
        }

        if (tmpWeight != 100)
        {
            Debug.Log("Суммарный вес платформ должен быть равен 100");
            return false;
        }
        return true;
    }
    /*private void TrySave()
    {
        Debug.Log("filename " + FileName.text);

        SavePlatformData savePlatformData = new SavePlatformData();
        SaveCoinData saveCoinData = new SaveCoinData();
        savePlatformData.TrySavePlatformData(FileName.text);
        saveCoinData.TrySaveCoinData(FileName.text);
    }*/
}
