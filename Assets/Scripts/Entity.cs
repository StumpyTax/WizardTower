using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float hp;
    public int mastery;
    public float critChance;
    public float ms;

    public void DamageTaken() 
    {
        Debug.Log(hp);
        if (hp <= 0)
            Destroy(gameObject);
    }
}
