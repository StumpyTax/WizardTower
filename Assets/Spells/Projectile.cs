using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float range;
    public float pushForce;
    
    public Vector3 start;
    public Vector3 direction;

    protected Rigidbody rb;
    private GameObject _gm;
    private Collider collider;
    
    public Spell spell;
    public List<StatusStorable> statuses;


    public void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
