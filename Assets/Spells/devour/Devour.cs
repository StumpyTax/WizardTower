using System;
using UnityEngine;
public class Devour : Spell
{
    public void Start()
    {
        targetEntity.Hp = -1;
        Enemy enemy;
        if (targetEntity.TryGetComponent<Enemy>(out enemy))
        {
            enemy.dropEdge();
        }
    }
}
