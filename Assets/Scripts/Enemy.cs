using System;
using UnityEngine;
[RequireComponent(typeof(Entity))]
public class Enemy : MonoBehaviour
{
    public Entity entity;
    public Player player;
    
    public Caster _caster { get; protected set; }
    public MovementControl _movementControl { get; protected set; }

    public void Start()
    {
        entity = GetComponent<Entity>();
        entity.team = "enemy";
    }
}
