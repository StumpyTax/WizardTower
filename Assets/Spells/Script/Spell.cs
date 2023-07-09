using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = Unity.Mathematics.Random;

public class Spell : MonoBehaviour
{
    private String _name;
    private String _description;
    private Sprite _icon;
    public Vector3 targetDir;

    public float dmg;
    public Entity casterEntity;

    public float CalculateDamage()
    {
        return dmg * casterEntity.mastery * CalculateCrit();
    }
    private float CalculateCrit()
    {
        return 1;
    }
}
