using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spell : MonoBehaviour
{
    private String _name;
    private String _description;
    private Sprite _icon;

    public float dmg;
    public Vector3 targetDir;
    public Entity casterEntity;
    public Status[] statuses;

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
