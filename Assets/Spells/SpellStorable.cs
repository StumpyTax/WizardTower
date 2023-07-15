using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellStorable", menuName = "SpellStorable")]
public class SpellStorable : ScriptableObject
{
    public Sprite icon;
    
    public float dmg;
    public float cooldown;
    public float curCooldown;

    public Spell spell;
    
    public Spell Cast()
    {
        if (curCooldown <= 0)
            return Instantiate(spell);
        return null;
    }
    
    public SpellStorable Get()
    {
        return Instantiate(this);
    }
}
