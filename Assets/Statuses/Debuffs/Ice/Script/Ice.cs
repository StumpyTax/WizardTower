using System.Collections;
using UnityEngine;

public class Ice : Status
{

    public override void Init()
    {
        
        OnGet += (entity) => StartCoroutine(Slow(entity));
        OnEnd += (entity) => entity.movementSpeed/=status.msChange;
    }

    public IEnumerator Slow(Entity entity)
    {
        entity.movementSpeed *= status.msChange;
        yield return new WaitForSeconds(status.duration);
        OnEnd.Invoke(entity);
    }
}
