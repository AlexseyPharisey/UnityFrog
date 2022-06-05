using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttendantsWork : Singleton<AttendantsWork>
{
    private void Do(AdditionalCoinAttendant attendant)
    {
        foreach (CoinMain coin in attendant.AdditionaCoins.ToList())
        {
            if (Vector3.Distance(coin.GetContainerTransform().position, attendant.SpawnPosition) >= attendant.ExpectedDistance)
            {
                coin.NewMovement(attendant.Target, new EaseInCubic(LevelSettings.singleton.CoinSpeedUpStep()));
                attendant.AdditionaCoins.Remove(coin);
            }
            if (attendant.AdditionaCoins.Count == 0)
            {
                //Destroy(attendant);
                attendant.Destr();
            }
        }
    }

    public override void Update()
    {
        foreach (AdditionalCoinAttendant attendant in _entities)
        {
            if (attendant != null)
                Do(attendant);
            //проходимся по его списку, для каждого из списка проверяем дистанс, если равен или больше задаем движение к таргету
        }
    }
}
