using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class rotationAnim : MonoBehaviour
{
    public float velocity;
    
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.angularVelocity = new Vector3(0, 0, velocity);
    }
}
