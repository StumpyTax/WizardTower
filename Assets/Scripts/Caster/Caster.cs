using System;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public Spell[] spells;
    public Vector3 direction;
    public Entity casterEntity;

    public void Start()
    {
        casterEntity = GetComponent<Entity>();
    }

    public void Cast(Spell spell)
    {
        spell.casterEntity = casterEntity;
        spell.targetDir = direction;
        spell.targetDir.z = 0;
        Instantiate(spell);
    }
}
