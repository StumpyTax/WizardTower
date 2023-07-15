using System;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    private Sprite _icon;

    public float curDur;
    
    public Action<Entity> OnGet;
    public Action<Entity> OnTick;
    public Action<Entity> OnEnd;

    public StatusStorable status;
    
    public abstract void Init();
}
