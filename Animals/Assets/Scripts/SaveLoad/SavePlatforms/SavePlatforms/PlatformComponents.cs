using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformComponents
{
    public readonly TriggeredPlatform BasePlatform;
    public readonly OscillatingEntity OscillatingEntity;

    public PlatformComponents(TriggeredPlatform basePlatform, OscillatingEntity oscillatingEntity)
    {
        BasePlatform = basePlatform;
        OscillatingEntity = oscillatingEntity;
    }
}
