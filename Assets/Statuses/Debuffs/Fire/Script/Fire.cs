using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Status
{
    
    private float _dmgInTick;
    private void Start()
    {
        
        _dmgInTick =GetInTick(dmgInSec);
    }

    private void FixedUpdate()
    {
        target.Hp -= _dmgInTick;
        Debug.Log(target.Hp);
        curDur += Time.fixedDeltaTime;

        if (curDur >= duration)
            Destroy(gameObject);
    }
}
