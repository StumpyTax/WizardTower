using System;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private Spell _spell;


    public Spell[] spells;
    public Vector3 direction;
    public List<Entity> enemies;
    public Entity casterEntity;

    public bool isEnable = true;
    public void Start()
    {
        isEnable = true;
        casterEntity = GetComponent<Entity>();
    }
    public void OnCastEnd()
    {
        GetComponent<Animator>().SetBool("Cast", false);
        _spell.casterEntity = casterEntity;
        _spell.targets = enemies;
        _spell.targetDir = direction;
        _spell.targetDir.z = 0;

        Instantiate(_spell);
        _spell.Cooldown();
    }
    public void Cast(Spell spell)
    {
        if (!isEnable || !spell.isReady())
        {
            Debug.Log(spell.curCooldown);
            return;
        }
        _spell = spell;
        GetComponent<Animator>().SetBool("Cast", true);
        OnCastEnd();
    }
  
}
