using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public List<Sprite> skins;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skins[Random.Range(0, skins.Count)];
    }
}
