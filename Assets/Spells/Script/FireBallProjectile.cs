using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    private Vector3 _end;
    void Start()
    {
        rb=GetComponent<Rigidbody>();

        rb.AddForce(direction*speed);
        _end = start * range;

    }
    
    void Update()
    {
        if (start.x >= _end.x && start.y >= _end.y)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var victim = other.GetComponent<Entity>();
            if (victim != null)
            {
                var casterStats = spell.caster.GetComponent<Entity>();
                var damage= casterStats.mastery * spell.dmg;

                if (Random.value <= casterStats.critChance)
                    damage *= 2;
                Debug.Log(damage);
                victim.hp -= damage;
                victim.DamageTaken();
            }
        }
        if(other.tag!="Player" && other.tag!="Spell")
            Destroy(gameObject);
    }
}
