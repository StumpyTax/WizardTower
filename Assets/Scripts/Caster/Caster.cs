using UnityEngine;

public abstract class Caster : MonoBehaviour
{
    
    
    public Spell[] spells;
    public Vector3 direction;

    public abstract void Cast(Spell spell);
}
