using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }
}
