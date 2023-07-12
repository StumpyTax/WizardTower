using System;
using UnityEngine;
[RequireComponent(typeof(Entity))]
public class Enemy : MonoBehaviour
{
    public Entity entity;
    public Player player;

    private void Start()
    {
        entity = GetComponent<Entity>();
        entity.team = "enemy";
    }
}
