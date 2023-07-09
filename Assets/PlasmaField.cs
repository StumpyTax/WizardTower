using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(SphereCollider))]
public class PlasmaField : Spell
{
    public float speed;
    public float range;

    private void Start()
    {
         StartCoroutine(Spreading());
    }

    private void Update()
    {
        transform.position = casterEntity.transform.position;
    }

    public IEnumerator Spreading()
    {
        float speedFixed = Time.deltaTime * speed;
        var radius = transform.localScale;
        var scale = Vector3.one * range;
        while (radius.magnitude < scale.magnitude)
        {
            speedFixed = Time.deltaTime * speed;
            radius += Vector3.one * speedFixed;
            transform.localScale = radius;
            yield return null;
        }
        while (Vector3.zero.x < radius.x)
        {
            speedFixed = Time.deltaTime * speed;
            radius -= Vector3.one * speedFixed;
            transform.localScale = radius;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
