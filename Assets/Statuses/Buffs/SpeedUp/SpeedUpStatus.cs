using System.Collections;
using UnityEngine;

public class SpeedUpStatus : Status
{
    public override void Init()
    {
        
        OnGet += (entity) => StartCoroutine(Speed(entity));
        OnEnd += (entity) => entity.movementSpeed = entity.movementSpeed / (status.msChange + 1);
    }

    public IEnumerator Speed(Entity entity)
    {
        entity.movementSpeed = 
            (status.msChange + 1) * entity.movementSpeed;
        yield return new WaitForSeconds(status.duration);
        OnEnd.Invoke(entity);
    }
}
