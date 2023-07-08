using UnityEngine;
public class Caster : MonoBehaviour
{
    public Spell[] spells;
    
    private void Cast(Spell spell)
    {
        spell.casterPlayer = this;
        Instantiate(spell);
    }
}