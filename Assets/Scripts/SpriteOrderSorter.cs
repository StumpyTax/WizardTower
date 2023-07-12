using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrderSorter : MonoBehaviour
{
    private Renderer _rend;
    
    public bool isStatic;

    public void Awake()
    {
        _rend = GetComponentInChildren<Renderer>();
    }

    public void LateUpdate()
    {
        var _center = GetComponent<Collider>();

        _rend.sortingOrder = (int)(0 - (_center.bounds.center.y*10));
        if (isStatic)
            Destroy(this);
    }

}
