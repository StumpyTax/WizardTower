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
                var damage= casterStats.mastery * spell.dmg;

                if (Random.value <= casterStats.critChance)
                    damage *= 2;
                Debug.Log(damage);
                victim.Hp -= damage;
                /*                victim.OnDamageTaken();
                */
                SetStatuses(victim);
            }
        }
        if(other.tag!="Player" && other.tag!="Spell")
            Destroy(gameObject);
    }
}
