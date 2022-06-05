using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _toOff;
    [SerializeField] private Canvas _toOn;
    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Do);
    }
    public void Do()
    {
        _toOff.gameObject.SetActive(false);
        _toOn.gameObject.SetActive(true);
    }
}
