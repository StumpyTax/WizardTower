using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public Entity entity;
    
    public float angleRight=60;
    public float angleLeft=60;

    public float FrictionForce = 0.5f;
    public Animator animator;

    public bool isEnable;
    [SerializeField]private Rigidbody rb;

    void Start()
    {
        isEnable = true;
        entity = GetComponent<Entity>();
        if (TryGetComponent<Animator>(out animator))
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        var dir = (CasterPlayer.GetMousePosition()-transform.position).normalized;
        var angle =Mathf.Atan2(dir.y,dir.x)*180/Mathf.PI;
    
        if (angle >= -angleRight / 2 && angle < angleRight / 2)
            dir = new Vector3(1, 0, 0);
        else if (angle > angleRight / 2 && angle <= 180 - angleLeft / 2)
            dir = new Vector3(0, 1, 0);
        else if (angle > angleLeft / 2 || angle < -180 + angleLeft / 2)
            dir = new Vector3(-1, 0, 0);
        else
            dir = new Vector3(0, -1, 0);

        if (animator is not null)
        {
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Horizontal", dir.x);   
        }
    }
    public void FixedUpdate() 
    {
        FrictionLogic();
        if (animator is not null)
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

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        var velocityVector = new Vector3(moveHorizontal * entity.movementSpeed, moveVertical * entity.movementSpeed, 0f);
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
