using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BlastWave : Projectile
{
    private Vector3 end;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start = rb.position;


        rb.AddForce(direction * speed);
        
        end = start;
        end.Scale(new Vector3(range,range, 0f));
    }
    
    void Update()
    {
        if ((start.x - rb.position.x) * (start.x - rb.position.x) +
            (start.y - rb.position.y)*(start.y - rb.position.y) >= range * range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var rb = other.GetComponent<Rigidbody>();
            other.GetComponent<Entity>().Hp -= spell.CalculateDamage();
            rb.AddForce(direction * pushForce);
        }
        if (other.tag == "Wall")
        {
            Destroy (gameObject);
        }
    }
}
