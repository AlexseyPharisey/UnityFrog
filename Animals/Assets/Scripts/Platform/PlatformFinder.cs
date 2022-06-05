using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlatformFinder 
{
    public static Transform FindTransformByNumber(int number)
    {
        var plat = MonoBehaviour.FindObjectsOfType<TriggeredPlatform>();

        foreach (TriggeredPlatform platform in plat)
        {
            if (platform.ExtensionNumber == number)
            {
                return platform.transform;
            }
        }
        return null;
    }
    
}
