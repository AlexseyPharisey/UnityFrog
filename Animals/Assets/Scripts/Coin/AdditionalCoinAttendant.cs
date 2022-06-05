using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//в идеале их можно пулить, мб сделать
public class AdditionalCoinAttendant : ScriptableEntity
{
    public List<CoinMain> AdditionaCoins { get; private set; }
    public float ExpectedDistance { get; private set; }
    public ITarget Target { get; private set; }
    public Vector3 SpawnPosition { get; private set; }

    public AdditionalCoinAttendant(List<CoinMain> additionaCoins, float expectedDistance, ITarget target, Vector3 spawnPosition)
    {
        AdditionaCoins = additionaCoins;
        ExpectedDistance = expectedDistance;
        Target = target;
        SpawnPosition = spawnPosition;
    }
    protected override void StorageInit()
    {
        AttendantsWork attendantsWork = AttendantsWork.Instance;
        _storage = attendantsWork.GetStorage();
    }

    public void Destr()
    {
        Destroy(this);
    }
}
