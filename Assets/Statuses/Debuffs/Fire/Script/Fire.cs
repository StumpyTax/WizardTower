using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Fire : Status
{
    public override void Init()
    {
        // status.OnTick += (entity) => { 
        //     entity.Hp -= dmgInTick;
        //  };
        // status.OnGet += (entity) => Burning(entity);
    }

    public async void Burning(Entity entity)
    {
        // bool flg = true;
        // TimeManager.instance.AddAction(
        //     () =>
        //     {
        //         flg = false;
        //     },
        //     status.duration);
        // while (flg)
        // {
        //     bool flg2 = true;
        //     TimeManager.instance.AddAction(
        //         () =>
        //         {
        //             flg2 = false;
        //             status.OnTick.Invoke(entity);
        //             Debug.Log("TICK");
        //         },
        //         status.intervalBetweenTicks);
        //     while (flg2) Task.Yield();
        // } 
        // status.OnEnd.Invoke(entity);
    }
    
    // public void Fire()
    // {
    //     projectile.start = casterEntity.transform.position + projectile.direction * indent;
    //     projectile.start.z = 0f;
    //     Instantiate(projectile, projectile.start,
    //         Quaternion.Euler(0f,0f,0f));
    // }
}
