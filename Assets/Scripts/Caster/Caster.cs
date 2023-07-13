using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Caster : MonoBehaviour
{
    private Spell _spell;


    public Spell[] spells;
    public Vector3 direction;
    public Entity casterEntity;

    public void Start()
    {
        casterEntity = GetComponent<Entity>();
    }
    public void OnCastEnd()
    {
        GetComponent<Animator>().SetBool("Cast", false);
        _spell.casterEntity = casterEntity;
        _spell.targetDir = direction;
        _spell.targetDir.z = 0;

        Instantiate(_spell);
    }
    public void Cast(Spell spell)
    {
        _spell = spell;
        GetComponent<Animator>().SetBool("Cast", true);
    }
  
}
