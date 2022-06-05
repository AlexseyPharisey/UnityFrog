using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreator : MonoBehaviour
{
    [SerializeField]private GameObject[] TrapPrefabs;

    public void Create(int type, int platformIndex)
    {
        if (type >= 0 && type < TrapPrefabs.Length)
        {
            var trap = Instantiate(TrapPrefabs[type]).GetComponent<Trap>();
            trap.Initialization(platformIndex);
            //Debug.Log("type " + type);
        }
    }
}
