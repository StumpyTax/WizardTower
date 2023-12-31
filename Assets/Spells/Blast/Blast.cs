using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

public class Blast : Spell
{
    public int blastWaves = 12;
    public float speed = 5;
    public float indent = 1.2f;
    public float range = 2;

    public BlastWave blastWave;
    // Start is called before the first frame update
    public void Start()
    {
        gameObject.AddComponent<Animator>();
        BlastField();
        Destroy(gameObject);
    }

    private void BlastField()
    {
        var casterX = casterEntity.gameObject.transform.position.x;
        var casterY = casterEntity.gameObject.transform.position.y;
        for (var i = 0; i < blastWaves; i++)
        {
            blastWave.spell=this;
            var vector = (Mathf.PI * 2) / blastWaves;
            var vector2 = new Vector3(Mathf.Sin(i * vector) + casterX, Mathf.Cos(i * vector) + casterY, casterEntity.transform.position.z);
            blastWave.start = vector2;


            blastWave.direction = new Vector3(blastWave.start.x - casterX, blastWave.start.y - casterY, 0f);
            
            blastWave.start.Scale(new Vector3(indent, indent, 1));


            blastWave.range = range;
            blastWave.speed = speed;


            Instantiate(blastWave, 
                vector2,
                Quaternion.Euler(0f, 0f, -360/blastWaves * i)).name = i.ToString();
            Debug.Log(vector2);
        }
    }
}
