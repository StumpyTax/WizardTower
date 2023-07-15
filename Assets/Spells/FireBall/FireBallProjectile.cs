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
        // statuses = new List<StatusStorable>();
        // statuses.Add(new Fire());
        rb=GetComponent<Rigidbody>();

        rb.AddForce(direction*speed, ForceMode.VelocityChange);
        _end = direction * range;
    }
    public void OutOfMaxRange()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (_end.magnitude < (transform.position - start).magnitude)
            GetComponent<Animator>().SetTrigger("MaxRange");
    }
    private void OnTriggerEnter(Collider other)
    {
        Entity entity;
        if (other.TryGetComponent<Entity>(out entity))
        {
            if (entity.team != this.spell.casterEntity.team)
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
        }
        if (other.tag == "Wall" || entity.team != spell.casterEntity.team)
        {
            
            rb.velocity = Vector3.zero;
            GetComponent<Animator>().SetTrigger("Hit");
        }
    }
    public void OnHitEnd()
    {
        Destroy(gameObject);
    }
}
