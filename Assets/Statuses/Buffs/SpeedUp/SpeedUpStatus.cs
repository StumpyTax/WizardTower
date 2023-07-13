using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpeedUpStatus : Status
{
    public float speedBonus;
    
    public SpeedUpStatus() : base(5, 0, 0, 0)
    {
        speedBonus = 1;
    }

    public override void Init()
    {
        OnGet += entity => { Speed(entity); };
        OnEnd += entity =>
        {
            entity.movementSpeed = entity.movementSpeed / (speedBonus + 1);
        };
    }
    
    public async void Speed(Entity entity)
    {
        entity.movementSpeed = 
            (speedBonus + 1) * entity.movementSpeed;
        while (curDur < duration)
        {
            curDur += intervalBetweenTicks + Time.deltaTime;
            await Task.Yield();
        }
        OnEnd.Invoke(entity);
    }
}
