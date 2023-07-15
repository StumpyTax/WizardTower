using System.Collections;
using UnityEngine;

public class Fire : Status
{
    public override void Init()
    {
        OnTick += (entity) => { 
            entity.Hp -= status.dmgInTick;
         };
        OnGet += (entity) => StartCoroutine(Burning(entity));
    }

    public IEnumerator Burning(Entity entity)
    {
        curDur = status.duration;
        while (curDur > 0)
        {
            var t = 0f;
            while (t < status.intervalBetweenTicks)
            {
                t += Time.deltaTime;
                yield return null;
            }

            curDur -= t;
            Debug.Log("TICK");
            OnTick?.Invoke(entity);
        }
        OnEnd?.Invoke(entity);
    }
    
    // public void Fire()
    // {
    //     projectile.start = casterEntity.transform.position + projectile.direction * indent;
    //     projectile.start.z = 0f;
    //     Instantiate(projectile, projectile.start,
    //         Quaternion.Euler(0f,0f,0f));
    // }
}
