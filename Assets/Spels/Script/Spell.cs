using System;
using UnityEngine;

public abstract partial class Spell : MonoBehaviour
{
    private String _name;
    private String _description;
    private Sprite _icon;

    public Caster caster;
}
