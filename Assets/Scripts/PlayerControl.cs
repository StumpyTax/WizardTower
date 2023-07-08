using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  [SerializeField]
  public Animator animator;
  public float speedStart = 10;
  public float FrictionForce = 0.5f;
  [SerializeField]
  private Vector3 direction;
  [SerializeField]
  private Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
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
    }

    private void MovementLogic()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");

      float moveVertical = Input.GetAxis("Vertical");
  
      Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

      var velocityVector = new Vector3(moveHorizontal * speedStart, moveVertical * speedStart, 0f);
      rb.velocity += velocityVector;
    }

    private void FrictionLogic()
    {
      var velocity = rb.velocity;
      var frictionVector = velocity * -FrictionForce;
      velocity += frictionVector;
      rb.velocity = velocity;
    }
    
    // private void SpeedBound()
    // {
    //   if (rb.velocity.magnitude > speedMax)
    //   {
    //     rb.velocity = rb.velocity.normalized * speedMax;
    //   }
    //}
}
