using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : Entity
{
    public Entity player;
    public float FrictionForce = 0.80f;


    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        // Debug.Log(player.transform.position);
        // GoTo(player.transform.position);
        Friction();
    }
    
    public void GoTo(Vector3 point)
    {
        Vector3 movementVector = point - transform.position;
        var velocityVector = movementVector.normalized * (movementSpeed * Time.deltaTime);
        _rb.velocity += velocityVector;
    }
    
    
    private void Friction()
    {
        var velocity = _rb.velocity;
        var frictionVector = velocity * -FrictionForce;
        velocity += frictionVector;
        _rb.velocity = velocity;
    }
}
