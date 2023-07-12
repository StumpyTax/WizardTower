using System.Collections;
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
    
    public void Fire()
    {
        projectile.start = casterEntity.transform.position + projectile.direction * indent;
        projectile.start.z = 0f;
        Instantiate(projectile, projectile.start,
            Quaternion.Euler(0f,0f,0f));
    }
}
