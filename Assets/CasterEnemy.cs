using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Entity))]

public class CasterEnemy : Caster
{
    private void Start()
    {
        entity = GetComponent<Entity>();
        StartCoroutine(CastPlasmaField());
    }
    

    public IEnumerator CastPlasmaField()
    {
        while (true)
        {
            Cast(spells[0]);
            yield return new WaitForSeconds(10f);
        }
    }

    public override void Cast(Spell spell)
    {
        spell.casterEntity = entity;
        Instantiate(spell);
    }
}