using System;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public Entity entity;
    
    public float angleRight=60;
    public float angleLeft=60;

    public float FrictionForce = 0.5f;
    public Animator animator;

    private AudioSource _source;


    public bool isEnable;
    private Rigidbody rb;

    public void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        _source = GetComponent<AudioSource>();
        isEnable = true;
        entity = GetComponent<Entity>();
        TryGetComponent<Animator>(out animator);
    }

    
    public void FixedUpdate() 
    {
        FrictionLogic();
        if (animator != null)
        {
            animator?.SetFloat("Speed", rb.velocity.magnitude);
        }
    }
    
    public void MoveTo(Vector3 pointFromEntity)
    {
        if (!isEnable) return;
        pointFromEntity = pointFromEntity.normalized;
        float moveHorizontal = pointFromEntity.x;
        float moveVertical = pointFromEntity.y;
        if (animator is not null)
        {
            animator.SetFloat("X", moveHorizontal);
            animator.SetFloat("Y", moveVertical);
        }

        var velocityVector = pointFromEntity * entity.movementSpeed;
        rb.velocity += velocityVector;
    }

    public Vector3 GetMoveVector(Vector3 from, Vector3 to)
    {
        return (to - from);
    }
    
    private void FrictionLogic()
    {
        var velocity = rb.velocity;
        var frictionVector = velocity * -FrictionForce;
        velocity += frictionVector;
        rb.velocity = velocity;
    }
}
