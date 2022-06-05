using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformListConverter
{
    public List<PlatformData> Convert(List<PlatformComponents> list)
    {
        //PlatformComponentsListCreator _allPlatformListCreator = new PlatformComponentsListCreator();
        //Debug.Log("Create");
        return FormingPlatformDataList(list);
    }


    private List<PlatformData> FormingPlatformDataList(List<PlatformComponents> basePlatformList)
    {
        List<PlatformData> platformDataList = new List<PlatformData>();
        RouterPlatformData _routerPlatformData = new RouterPlatformData();
        PlatformData _platformData;
        Debug.Log("number " + basePlatformList.Count);
        foreach (PlatformComponents baseP in basePlatformList)
        {
            if (baseP.BasePlatform.GetType().ToString() != PlatformTypes.START)
            {
                _platformData = _routerPlatformData.ConvertToPlatformData(baseP.BasePlatform, baseP.OscillatingEntity);
                platformDataList.Add(_platformData);
            }
        }

        return platformDataList;
    }
}
