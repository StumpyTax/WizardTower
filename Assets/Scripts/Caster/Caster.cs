using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Caster : MonoBehaviour
{
    //Мы должны хранить геймобджекты спеллов
    private Spell _spell;
    public List<SpellStorable> spells;
    
    public Vector3 direction;
    public List<Entity> enemies;
    public Entity casterEntity;

    public bool isEnable = true;
    public void Start()
    {
        isEnable = true;
        casterEntity = GetComponent<Entity>();
        spells[0] = Instantiate(spells[0]);
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

    public void Cooldown(SpellStorable spell)
    {
        // var index = spells.IndexOf(spell);
        // spell = Instantiate(spell);
        // spells[index] = spell;
        
        spell.curCooldown = spell.cooldown;

        IEnumerator Routine()
        {
            while (spell.curCooldown > 0)
            {
                spell.curCooldown -= Time.deltaTime;
                yield return null;
            }
        }
        StartCoroutine(Routine());
    }
    public void Cast(SpellStorable spell)
    {
        Debug.Log(spell.curCooldown);
        var spell1 = spell.Cast();
        if (spell1 == null) return;
        spell1.targetDir = direction;
        spell1.targetDir.z = 0;
        spell1.casterEntity = casterEntity;
        spell1.targets = enemies;
        Cooldown(spell);
        // GetComponent<Animator>().SetBool("Cast", true);
        // OnCastEnd();
    }
}
