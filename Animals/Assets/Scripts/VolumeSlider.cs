using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("SaveVolume");
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SaveVolume");
    }

    public void Volume(float value)
    {
        Debug.Log(value);
        GetComponent<AudioSource>().volume = value;
        PlayerPrefs.SetFloat("SaveVolume", value);
    }
}