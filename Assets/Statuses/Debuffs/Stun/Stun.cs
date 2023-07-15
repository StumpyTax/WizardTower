using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Stun : Status
{
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

            //Wait(entity);
            StartCoroutine(Routine(entity));
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

    public void Wait(Entity e)
    {
        
        //TimeManager.instance.AddAction(() => {status.OnEnd.Invoke(e);}, status.duration);
    }

    public IEnumerator Routine(Entity entity)
    {
        while (curDur < status.duration)
        {
            curDur += Time.deltaTime;
            yield return null;
        }
        OnEnd.Invoke(entity);
    }
}
