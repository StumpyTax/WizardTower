using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackTrigger : MonoBehaviour
{
    public float radius;
    
    public Action OnEnter;
    public Action OnStay;
    public Action OnExit;


    private SphereCollider _collider;
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (OnEnter is not null && other.tag == "Player") OnEnter.Invoke();
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (OnStay is not null && other.tag == "Player") OnStay.Invoke();
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (OnExit is not null && other.tag == "Player") OnExit.Invoke();
    }
}
