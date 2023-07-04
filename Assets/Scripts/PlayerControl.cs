using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  [SerializeField]
  public Animator animator;
  public float speed;
  [SerializeField]
  private Vector2 direction;
  [SerializeField]
  private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      direction.x=Input.GetAxisRaw("Horizontal");
      direction.y=Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal",direction.x);
      animator.SetFloat("Vertical",direction.y);
    }
    void FixedUpdate() 
    {
      rb.MovePosition(rb.position+direction*speed);
    }
}
