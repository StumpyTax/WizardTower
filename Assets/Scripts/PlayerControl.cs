using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public Animator animator;
  public float speedStart = 10;
  public float FrictionForce = 0.5f;
  public float angleRight=60;
  public float angleLeft=60;
    
  [SerializeField]private Rigidbody rb;
   
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        speedStart = GetComponent<Entity>().movementSpeed;
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

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);


    }
    void FixedUpdate() 
    {
      MovementLogic();
      FrictionLogic();
      animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void MovementLogic()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      animator.SetFloat("X",moveHorizontal);
      animator.SetFloat("Y",moveVertical);

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
