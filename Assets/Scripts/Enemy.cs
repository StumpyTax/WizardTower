using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Entity))]
public class Enemy : MonoBehaviour
{
    public Entity entity;
    public Player player;
    public List<Edge> edges;
  
    public Caster _caster { get; protected set; }
    public MovementControl _movementControl { get; protected set; }

    public void Start()
    {
        entity = GetComponent<Entity>();
        entity.Hp = entity.maxHp;
        entity.team = "enemy";
    }
    public void dropEdge()
    {
        Debug.Log("drop edge");
        if (edges.Count > 0)
        {
            var edge = edges[Random.Range(0, edges.Count)];
            Instantiate(edge.edgeItem, entity.transform.position, entity.transform.rotation);
        }
    }
    
    public void OnMouseDown()
    {
        player.caster.targetEntity = entity;
        player.caster.Cast(player.caster.spells[2]);
    }
}
