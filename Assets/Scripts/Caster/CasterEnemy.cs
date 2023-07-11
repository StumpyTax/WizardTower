using UnityEngine;
[RequireComponent(typeof(Enemy))]

public class CasterEnemy : Caster
{
    public Enemy entity;
    public void Start()
    {
        entity = GetComponent<Enemy>();
        //StartCoroutine(CastPlasmaField());
    }

    public void Cast(Spell spell)
    {
        spell.casterEntity = entity;
        Instantiate(spell);
    }
}