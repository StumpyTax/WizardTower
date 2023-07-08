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
        projectile.direction = targetDir.normalized;
        Fire();
        Destroy(gameObject);
    }
    public void Fire()
    {
        projectile.start = targetDir.normalized+caster.transform.position;
/*        projectile.start.Scale(new Vector3(indent, indent, 1));
*/        projectile.start.z = 0f;
        Debug.Log(caster.getMousePosition());
        Instantiate(projectile,projectile.start,
            Quaternion.Euler(0f,0f,0f));
    }
}
