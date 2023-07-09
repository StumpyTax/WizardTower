using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract partial class Spell : MonoBehaviour
{
    private String _name;
    private String _description;
    private Sprite _icon;
    public Vector3 targetDir;

    public float dmg;
    public Entity casterEntity;
}
