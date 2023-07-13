using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackTrigger : MonoBehaviour
{
    public float radius;
    
    public Action<Collider> OnEnter;
    public Action<Collider> OnStay;
    public Action<Collider> OnExit;


    private SphereCollider _collider;
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (OnEnter is not null && other.tag == "Player") OnEnter.Invoke(other);
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (OnStay is not null && other.tag == "Player") OnStay.Invoke(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (OnExit is not null && other.tag == "Player") OnExit.Invoke(other);
    }
}
