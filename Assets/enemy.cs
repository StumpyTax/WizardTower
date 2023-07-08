using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float FrictionForce = 0.80f;
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Friction();
    }
    
    private void Friction()
    {
        var _frictionVector = _rb.velocity;
        _frictionVector.Scale(new Vector3(-FrictionForce, 0, -FrictionForce));
        _rb.AddForce(_frictionVector);
    }
}
