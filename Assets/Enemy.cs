using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : Entity
{
    public Entity player;
    public float FrictionForce = 0.80f;
    
    
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

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
