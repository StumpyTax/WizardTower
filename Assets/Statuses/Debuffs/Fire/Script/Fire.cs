using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Fire : Status
{
    public Fire() : base(10, 10, 0, 2)
    {
    }
    
    
    public override void Init()
    {
        OnTick += (entity) => { 
            entity.Hp -= dmgInTick;
         };
        OnGet += (entity) => Burning(entity);
    }

    public async void Burning(Entity entity)
    {
        while (curDur < duration)
        {
            var t = 0f;
            while (t < intervalBetweenTicks)
            {
                t += Time.deltaTime;
                await Task.Yield();
            }
            t = 0f;
            OnTick.Invoke(entity);
            curDur += intervalBetweenTicks + Time.deltaTime;
        }
        OnEnd.Invoke(entity);
    }
    
    // public void Fire()
    // {
    //     projectile.start = casterEntity.transform.position + projectile.direction * indent;
    //     projectile.start.z = 0f;
    //     Instantiate(projectile, projectile.start,
    //         Quaternion.Euler(0f,0f,0f));
    // }
}
