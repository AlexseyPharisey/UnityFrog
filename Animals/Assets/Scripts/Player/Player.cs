using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlatformsPassed { get; private set; }
    //public bool InSwamp { get; private set; }

    public string StandingOn { get; private set; }

    private int _score;
    private UIHandler _uIHandler;

    private void Awake()
    {
        _uIHandler = (UIHandler)FindObjectOfType(typeof(UIHandler));
    }

    void Start()
    {
        PlatformsPassed = 0;
    }
    public void IncresePlatformsPassed()
    {
        PlatformsPassed++;
    }

    public void ChangeScore(int score)
    {
        _score += score;
        _uIHandler.UpdateScore(_score);
    }

    public void ÑhangeStandingOn(string standingOn)
    {
        StandingOn = standingOn;
        //Debug.Log("còîèì íà " + StandingOn);
    }
}
