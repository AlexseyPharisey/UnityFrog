using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsCreator : MonoBehaviour
{
    //Обьеденить в массив, кошда будут готовы все префабы
    public GameObject BasePlatformPrefab;
    public GameObject IcePlatformBody;
    public GameObject GrassPlatformBody;
    public GameObject SwampPlatformBody;
    public GameObject CloudPlatformBody;

    private Transform _platformContainer;

    private void Awake()
    {
        _platformContainer = GameObject.FindGameObjectWithTag("PlatformContainer").GetComponent<Transform>();
    }

    private void InstatiateBody(GameObject fill, Transform parent)
    {
        GameObject filling;
        filling = Instantiate(fill);
        filling.transform.SetParent(parent.transform, false);
    }

    private void Creation(PlatformData platformData)
    {
        GameObject temporaryPlatform;
        Vector3 Union = new Vector3(0f, 0f, 0f);
        OscillatingEntity oscillatingPlatform;

        temporaryPlatform = Instantiate(BasePlatformPrefab);
        temporaryPlatform.transform.SetParent(_platformContainer.transform, false);

        Union.x = platformData.Position[0];
        Union.y = platformData.Position[1];
        Union.z = platformData.Position[2];
        temporaryPlatform.transform.position = Union;

        Union.x = platformData.Scale[0];
        Union.y = platformData.Scale[1];
        Union.z = platformData.Scale[2];
        temporaryPlatform.transform.localScale = Union;

        oscillatingPlatform = temporaryPlatform.AddComponent<OscillatingEntity>();
        oscillatingPlatform.SetUp
        (
            platformData.Speed,
            new Vector3(platformData.StartPoint[0], platformData.StartPoint[1], platformData.StartPoint[2]),
            new Vector3(platformData.EndPoint[0], platformData.EndPoint[1], platformData.EndPoint[2])
        );

        if (platformData.Type == PlatformTypes.START)
        {
            temporaryPlatform.gameObject.SetActive(false);
        }

        if (platformData.Type == PlatformTypes.TRAMPOLINE)
        {
            TrampolinePlatform trampolinePlatform;

            trampolinePlatform = temporaryPlatform.AddComponent<TrampolinePlatform>();
            trampolinePlatform.SetExtensionNumber(platformData.ExtNumber);
            InstatiateBody(IcePlatformBody, oscillatingPlatform.transform);
        }

        if (platformData.Type == PlatformTypes.ICE)
        {
            IcePlatform icePlatform;

            icePlatform = temporaryPlatform.AddComponent<IcePlatform>();
            icePlatform.InitializationAfterLoad(platformData.NonInheritedData);
            icePlatform.SetExtensionNumber(platformData.ExtNumber);
            InstatiateBody(IcePlatformBody, oscillatingPlatform.transform);
        }

        if (platformData.Type == PlatformTypes.CLOUD)
        {
            CloudPlatform cloudPlatform;

            cloudPlatform = temporaryPlatform.AddComponent<CloudPlatform>();
            cloudPlatform.InitializationAfterLoad(platformData.NonInheritedData);
            cloudPlatform.SetExtensionNumber(platformData.ExtNumber);
            InstatiateBody(CloudPlatformBody, oscillatingPlatform.transform);
        }

        if (platformData.Type == PlatformTypes.GRASS)
        {
            GrassPlatform grassPlatform;

            grassPlatform = temporaryPlatform.AddComponent<GrassPlatform>();
            grassPlatform.SetExtensionNumber(platformData.ExtNumber);
            InstatiateBody(GrassPlatformBody, oscillatingPlatform.transform);
        }

        if (platformData.Type == PlatformTypes.SWAMP)
        {
            SwampPlatform swampPlatform;

            swampPlatform = temporaryPlatform.AddComponent<SwampPlatform>();
            swampPlatform.SetExtensionNumber(platformData.ExtNumber);
            InstatiateBody(SwampPlatformBody, oscillatingPlatform.transform);
        }
    }

    public void RecreatePlatforms(List<PlatformData> platformDatas)
    {

        foreach (PlatformData platformData in platformDatas)
        {
            Creation(platformData);
        }
    }

    public void RecreateOnePlatform(PlatformData platformData)
    {
        Creation(platformData);
    }
}
