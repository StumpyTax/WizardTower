using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Status
{
    public override void Init()
    {
        OnTick += (entity) => { 
            entity.Hp -= dmgInTick;
         };
        OnGet += (entity)=> StartCoroutine(Burning(entity));
        OnEnd += (entity) => Destroy(gameObject);
    }

    private IEnumerator Burning(Entity entity)
    {
        while (curDur < duration)
        {
            yield return new WaitForSeconds(intervalBetweenTicks);
            OnTick.Invoke(entity);
            curDur += intervalBetweenTicks + Time.deltaTime;
        }
        OnEnd.Invoke(entity);
    }
}
