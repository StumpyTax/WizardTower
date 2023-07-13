using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Ice : Status
{

    public float slowDown;
    public Ice() : base(10, 10, 0, 2)
    {
        slowDown = 0;
    }


    public override void Init()
    {
        
        OnGet += (entity) => Slow(entity);
        OnEnd += (entity) => entity.movementSpeed/=slowDown;
    }

    public async void Slow(Entity entity)
    {
        entity.movementSpeed *= slowDown;
        while (curDur < duration)
        {
            curDur += intervalBetweenTicks + Time.deltaTime;
            await Task.Yield();
        }
        OnEnd.Invoke(entity);
    }
}
