using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spell : MonoBehaviour
{
    private String _name;
    private String _description;
    private Sprite _icon;

    public float dmg;
    public float cooldown;
    public float curCooldown = 0;

    public Vector3 targetDir;
    public Entity casterEntity;
    public Entity targetEntity;
    public List<Status> statuses;

    public async void Cooldown()
    {
        curCooldown = cooldown;
        while (curCooldown > 0)
        {
            curCooldown -= Time.deltaTime;
            await Task.Yield();
        }
    }

    public bool isReady()
    {
        return curCooldown <= 0;
    }
    public float CalculateDamage()
    {
        return dmg * casterEntity.mastery * CalculateCrit();
    }

    private float CalculateCrit()
    {
        int res = 1;

        if (Random.value <= casterEntity.critChance)
            res = 2;
        return res;
    }
}
