
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Stun : Status
{
    public Stun(float duration) : base(duration, 0, 0, 0)
    {
    }

    public override void Init()
    {
        OnGet += (entity) =>
        {
            Enemy enemy;
            if (entity.TryGetComponent<Enemy>(out enemy))
            {
                enemy._caster.isEnable = false;
                enemy._movementControl.isEnable = false;
            }
            Player player;
            if (entity.TryGetComponent<Player>(out player))
            {
                player.caster.isEnable = false;
                player.movementControl.isEnable = false;
            }

            Wait(entity);
        };
        OnEnd += entity => 
        {
            Enemy enemy;
            if (entity.TryGetComponent<Enemy>(out enemy))
            {
                enemy._caster.isEnable = true;
                enemy._movementControl.isEnable = true;
            }
            Player player;
            if (entity.TryGetComponent<Player>(out player))
            {
                player.caster.isEnable = true;
                player.movementControl.isEnable = true;
            }
        };
    }

    public async void Wait(Entity e)
    {
        while (curDur < duration)
        {
            curDur += Time.deltaTime;
            await Task.Yield();
        }
        OnEnd.Invoke(e);
    }
}
