using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : Entity
{
  public Animator animator;
  public float FrictionForce = 0.5f;
  [SerializeField]private Vector3 direction;
  [SerializeField]private Rigidbody rb;
    void Start()
    {
      rb=GetComponent<Rigidbody>();
        movementSpeed = GetComponent<Entity>().movementSpeed;

        OnDeath += () => { animator.Play("Death"); };
    }

    void Update()
    {
      direction.x=Input.GetAxisRaw("Horizontal");
      direction.y=Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal",direction.x);
      animator.SetFloat("Vertical",direction.y);
    }
    void FixedUpdate() 
    {
      MovementLogic();
      FrictionLogic();
      rb.MovePosition(rb.position+direction*movementSpeed);
    }
    private void MovementLogic()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");

      float moveVertical = Input.GetAxis("Vertical");
  
      Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

      var velocityVector = new Vector3(moveHorizontal * movementSpeed, moveVertical * movementSpeed, 0f);
      rb.velocity += velocityVector;
    }

    private void FrictionLogic()
    {
      var velocity = rb.velocity;
      var frictionVector = velocity * -FrictionForce;
      velocity += frictionVector;
      rb.velocity = velocity;
    }
}
