using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SunStrike : Spell
{
    public float delay;
    private float curDelay;
    private SphereCollider _sphereCollider;

    public void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.enabled = false;
        _sphereCollider.isTrigger = true;
        StartCoroutine(Routine());
    }

    private IEnumerator Routine()
    {
        delay = 0;
        while (curDelay < delay)
        {
            curDelay += Time.deltaTime;
            yield return null;
        }
        _sphereCollider.enabled = true;
        Debug.Log("END");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Entity entity;
        if (other.TryGetComponent<Entity>(out entity))
        {
            if (entity.team != casterEntity.team)
            {
                Debug.Log("TRIGGER");
                var victim = other.GetComponent<Entity>();
                if (victim != null)
                {
                    var casterStats = casterEntity.GetComponent<Entity>();
                    var damage= CalculateDamage();

                    victim.Hp -= damage;
                }
            }
        }
    }
}
