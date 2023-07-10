using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : Spell
{
    public float speed;
    public float cd=0;
    public float range;
    public float indent;
    
 /*   public GameObject debbuf;*/
    public FireBallProjectile projectile;

    private void Start()
    {
        projectile.spell=this;
        projectile.range = range;
        projectile.speed = speed;
        projectile.direction = (targetDir - casterEntity.transform.position).normalized;
       
        Fire();
        Destroy(gameObject);
    }
    public void Fire()
    {
        projectile.start = casterEntity.transform.position + projectile.direction * indent;
        Debug.Log(CasterPlayer.GetMousePosition());
        projectile.start.z = 0f;
        Instantiate(projectile,projectile.start,
            Quaternion.Euler(0f,0f,0f));
    }
}
