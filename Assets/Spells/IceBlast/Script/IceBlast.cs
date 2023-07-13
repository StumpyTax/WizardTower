using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceBlast : Spell
{
    public float speed;
    public float cd=0;
    public float range;
    public float indent;
    
 /*   public GameObject debbuf;*/
    public IceBlastProjectile projectile;

    private void Start()
    {
        projectile.spell=this;
        projectile.range = range;
        projectile.speed = speed;
        projectile.direction = (targetDir - casterEntity.transform.position);
        projectile.direction.z = 0;
        projectile.direction = projectile.direction.normalized;
        Fire();
        Destroy(gameObject);
    }
    public void Fire()
    {
        projectile.start = casterEntity.transform.position + projectile.direction * indent;
        projectile.start.z = casterEntity.transform.position.z;
        float angle = Mathf.Atan2(projectile.direction.y,projectile.direction.x)*180/Mathf.PI;
        Instantiate(projectile,projectile.start,
            Quaternion.Euler(0f,0f,angle-90));
    }
}
