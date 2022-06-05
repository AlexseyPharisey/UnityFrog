using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountUI : MonoBehaviour
{
    private Text _coinText;
    private int _coinCount = 0;

    private void Awake()
    {
        _coinText = GetComponent<Text>();
    }
    public void UpdateCoinCount()
    {
        _coinCount++;
        _coinText.text = _coinCount.ToString();
    }
}
