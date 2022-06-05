using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformComponentsListCreator
{ 
    public List<PlatformComponents> Create()
    {
        List<PlatformComponents> PlatformComponentsList = new List<PlatformComponents>();

        //BasePlatformsListInit();
        var platforms = MonoBehaviour.FindObjectsOfType<TriggeredPlatform>();

        foreach (TriggeredPlatform basePlatform in platforms)
        {
            Debug.Log("");
            PlatformComponents platComp = new PlatformComponents(basePlatform, basePlatform.GetComponent<OscillatingEntity>());
            PlatformComponentsList.Add(platComp);
        }

        return PlatformComponentsList;
    }
}
