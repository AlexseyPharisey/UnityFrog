using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchCameraMode : MonoBehaviour
{
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private CameraMove _cameraMove;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Do);
    }

    public void Do()
    {
        _cameraFollow.enabled = !_cameraFollow.enabled;
        _cameraMove.enabled = !_cameraMove.enabled;
    }
}
