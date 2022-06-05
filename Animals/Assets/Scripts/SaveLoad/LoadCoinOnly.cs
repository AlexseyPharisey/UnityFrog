using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCoinOnly : MonoBehaviour
{
    public Text FileName;
    private Button _loadButton;

    private void Start()
    {
        _loadButton = GetComponent<Button>();
        _loadButton.onClick.AddListener(TryLoad); ;
    }
    private void TryLoad()
    {
        Debug.Log("filename " + FileName.text);

        //LoadPlatformData loadPlatformData = new LoadPlatformData();
        //loadPlatformData.TryLoadPlatformData(FileName.text);
        LoadCoins loadCoins = new LoadCoins();
        loadCoins.TryLoadCoinData(FileName.text);
    }
}
