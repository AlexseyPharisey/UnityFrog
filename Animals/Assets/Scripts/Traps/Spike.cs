using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    public int PlatformNumberToAttach { get; private set; }

    public override void Initialization(int myPlatformNumber)
    {
        if (myPlatformNumber >= 0)
        {
            PlatformNumberToAttach = myPlatformNumber;
            TryAttach();
        }
    }

    private void TryAttach()
    {

        Transform platform = PlatformFinder.FindTransformByNumber(PlatformNumberToAttach); 
        Vector3 temporaryPosition = new Vector3(0, 0, 0);

        if (platform != null)
        {
            transform.SetParent(platform);
            temporaryPosition.x = Random.Range(-0.9f, 0.9f) * platform.GetComponent<BoxCollider2D>().size.x * platform.transform.localScale.x / 2;
            transform.localPosition = temporaryPosition;
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
}
