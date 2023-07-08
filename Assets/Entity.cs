using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public readonly List<Tags> tags;
}

public enum Tags
{
    Enemy,
    Projectile,
    ConstVelocity,
}

