using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    private Vector3 _newScale;
    private void Start()
    {
        _newScale = new Vector3(LevelSettings.singleton.PlayerScale(), LevelSettings.singleton.PlayerScale(),1);
        transform.localScale = _newScale;
    }
}
