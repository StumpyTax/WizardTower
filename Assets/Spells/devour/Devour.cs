using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Devour : Spell
{
    public void Start()
    {
        StartCoroutine(SimpleRoutine());
    }

    public IEnumerator SimpleRoutine()
    {
        yield return new WaitForSeconds(4);
        Enemy enemy;
        if (targetEntity.TryGetComponent<Enemy>(out enemy))
        {
            enemy.dropEdge();
        }
        
        targetEntity.Hp = -1;
    }
}
