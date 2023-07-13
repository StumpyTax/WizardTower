using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SphereCollider))]
public class RangeTrigger : MonoBehaviour
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

    public void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (OnEnter is not null) OnEnter.Invoke(other);
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (OnStay is not null && other.tag == "item") 
            OnStay.Invoke(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (OnExit is not null && other.tag == "item") 
            OnExit.Invoke(other);
    }
}