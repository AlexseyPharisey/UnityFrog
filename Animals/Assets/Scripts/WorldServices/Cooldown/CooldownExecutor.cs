using System.Linq;

public class CooldownExecutor : Singleton<CooldownExecutor>
{
    public override void Update()
    {
        foreach (Cooldown cooldown in _entities.ToList())
            cooldown.Update();
    }
}
