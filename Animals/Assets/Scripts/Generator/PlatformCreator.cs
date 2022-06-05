using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject BasePlatformPrefab;
    public GameObject[] PlatformsPrefabs;

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

    public void Create(int number, int type, float speed, float xStartCord, float additionalData)
    {
        GameObject temporaryPlatform;
        Vector3 newPosition = new Vector3(0f, 0f, 0f);
        OscillatingEntity oscillatingPlatform;

        temporaryPlatform = Instantiate(BasePlatformPrefab);
        temporaryPlatform.transform.SetParent(_platformContainer.transform, false);

        newPosition = temporaryPlatform.transform.position;
        newPosition.x = xStartCord;
        newPosition.y = LevelSettings.singleton.DistanceBetweenPlatforms() * number + LevelSettings.singleton.FirstPlatformOffset();

        temporaryPlatform.transform.position = newPosition;

        oscillatingPlatform = temporaryPlatform.AddComponent<OscillatingEntity>();
        oscillatingPlatform.SetUp
        (
            speed,
            new Vector3(GeneratorConst.PLATFORM_X_BORDER * -1, newPosition.y, newPosition.z),
            new Vector3(GeneratorConst.PLATFORM_X_BORDER, newPosition.y, newPosition.z)
        );

        TriggeredPlatform platform = AddPlatformComponent(type, temporaryPlatform);
        platform.InitializationAfterLoad(additionalData);
        platform.SetExtensionNumber(number);

    }

    private TriggeredPlatform AddPlatformComponent(int type, GameObject platform)
    {
        InstatiateBody(PlatformsPrefabs[type], platform.transform);
        if (type <= 0)
        {
            return platform.AddComponent<GrassPlatform>();
        }
        if (type == 1)
        {
            return platform.AddComponent<IcePlatform>();
        }
        if (type == 2)
        {
            return platform.AddComponent<SwampPlatform>();
        }
        if (type == 3)
        {
            return platform.AddComponent<CloudPlatform>();
        }
        if (type == 4)
        {
            return platform.AddComponent<TrampolinePlatform>();
        }

        return null;
    }
}
