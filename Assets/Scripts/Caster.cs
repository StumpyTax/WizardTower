using UnityEngine;

public abstract class Caster : MonoBehaviour
{
    public Spell[] spells;
    public Vector3 direction;
    public Entity entity;

    public abstract void Cast(Spell spell);
}
