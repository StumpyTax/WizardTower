using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using Unity.VisualScripting;

public class FireBallProjectile : Projectile
{
    private Vector3 _end;
    void Start()
    {
        rb=GetComponent<Rigidbody>();

        rb.AddForce(direction*speed, ForceMode.VelocityChange);
        _end = direction * range;
    }
    void Update()
    {
        if (_end.magnitude < (transform.position-start).magnitude)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var victim = other.GetComponent<Entity>();
            if (victim != null)
            {
                var casterStats = spell.casterEntity.GetComponent<Entity>();
                var damage= spell.CalculateDamage();

                victim.Hp -= damage;
                victim.AddNewStatuses(statuses);
            }
        }
        if(other.tag!="Player" && other.tag!="Spell" && other.tag != "Floor")
            Destroy(gameObject);
    }
}
