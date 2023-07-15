using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class IceBlastProjectile : Projectile
{
    private Vector3 _end;
    public AudioClip startClip;
    public AudioClip endClip;
    private AudioSource _audioSource;
    void Start()
    {
        // statuses = new List<Status>();
        // statuses.Add(new Ice());
        rb=GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = startClip;
        _audioSource.Play();
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
        if (other.TryGetComponent(out entity))
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
        var team = spell.casterEntity.team;
        if (entity != null)
            team = entity.team;
      
        if (other.tag == "Wall" || team != spell.casterEntity.team)
        {

            _audioSource.clip = endClip;
            _audioSource.Play();
            rb.velocity = Vector3.zero;
            GetComponent<Animator>().SetTrigger("Hit");
        }
    }
    public void OnHitEnd()
    {
        Destroy(gameObject);
    }
}
