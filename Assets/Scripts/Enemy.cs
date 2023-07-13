using System;
using System.Collections.Generic;
using UnityEngine;
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
        entity.team = "enemy";
    }
    public void dropEdge()
    {
        Debug.Log("drop edge");
        if (edges.Count > 0)
        {
            var edge = edges[0];
            Instantiate(edge.edgeItem, entity.transform.position, entity.transform.rotation);
        }
    }
    
    public void OnMouseDown()
    {
        player.devour.targetEntity = entity;
        player.devour.Start();
    }
}
