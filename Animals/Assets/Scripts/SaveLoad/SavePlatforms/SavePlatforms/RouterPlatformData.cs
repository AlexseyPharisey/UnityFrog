using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouterPlatformData
{ 
    public PlatformData ConvertToPlatformData(TriggeredPlatform basePlatform, OscillatingEntity oscillatingEntity)
    {
        PlatformData pd = new PlatformData(basePlatform, oscillatingEntity);
        return pd;
    }
}
