using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AddPlatform : MonoBehaviour
{
    private Button _addPlatform;

    [SerializeField] private InputField _positionAndNumber;
    [SerializeField] private InputField _type;
    [SerializeField] private InputField _leftBorder;
    [SerializeField] private InputField _rightBorder;
    [SerializeField] private InputField _speed;
    [SerializeField] private InputField _nonInheritedData;
    [SerializeField] private InputField _positionX;
    [SerializeField] private Toggle _canMovie;

    private const float STARTPOS_Z = 0;
    private PlatformData _platformData;
    
    private void Start()
    {
        _addPlatform = GetComponent<Button>();
        _addPlatform.onClick.AddListener(Do);       
    }

    private void Do()
    {
        _platformData = new PlatformData(
            _type.text,
            int.Parse(_positionAndNumber.text),
            float.Parse(_positionX.text),
            LevelSettings.singleton.DistanceBetweenPlatforms() * int.Parse(_positionAndNumber.text) + LevelSettings.singleton.FirstPlatformOffset(),
            STARTPOS_Z,
            new float[3] {1,1,1},
            float.Parse(_speed.text),
            //float.Parse(_rightBorder.text),
            //float.Parse(_leftBorder.text),
            //_canMovie.isOn,
            float.Parse(_nonInheritedData.text),
            new Vector3(
                float.Parse(_leftBorder.text),
                LevelSettings.singleton.DistanceBetweenPlatforms() * int.Parse(_positionAndNumber.text) + LevelSettings.singleton.FirstPlatformOffset(),
                STARTPOS_Z
                ),
            new Vector3(
                float.Parse(_rightBorder.text),
                LevelSettings.singleton.DistanceBetweenPlatforms() * int.Parse(_positionAndNumber.text) + LevelSettings.singleton.FirstPlatformOffset(),
                STARTPOS_Z
                )
            );

        PlatformsCreator platformsCreator = (PlatformsCreator)FindObjectOfType(typeof(PlatformsCreator)); 
        platformsCreator.RecreateOnePlatform(_platformData);
    }
}
