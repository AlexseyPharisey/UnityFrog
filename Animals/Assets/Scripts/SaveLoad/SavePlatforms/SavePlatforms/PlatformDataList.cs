using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlatformDataList
{
    public List<PlatformData> AllPlatformsData;

    public PlatformDataList(List<PlatformData> somePlatformDataList)
    {
        AllPlatformsData = somePlatformDataList;
    }
}
