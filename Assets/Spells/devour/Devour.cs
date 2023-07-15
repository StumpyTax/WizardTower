using System;
using System.Collections;
using UnityEngine;
public class Devour : Spell
{
    public void Start()
    {
        StartCoroutine(SimpleRoutine());
    }

    public IEnumerator SimpleRoutine()
    {
        casterEntity.AddNewStatuses(statuses);
        targetEntity.AddNewStatuses(statuses);
        yield return new WaitForSeconds(4);
        Enemy enemy;
        if (targetEntity.TryGetComponent<Enemy>(out enemy))
        {
            enemy.dropEdge();
        }
        
        targetEntity.Hp = -1;
    }
}
