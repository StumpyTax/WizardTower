using System;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Status : MonoBehaviour
{
    private Sprite _icon;
    private float _duration;
    public float duration { get { return _duration; }}
    public float curDur;

    public float dmgInTick;
    public float healInTick;
    public float intervalBetweenTicks;
    

    public Action<Entity> OnGet;
    public Action<Entity> OnTick;
    public Action<Entity> OnEnd;


    public Status(float _duration, float dmgInTick, float healInTick, float intervalBetweenTicks)
    {
        this._duration = _duration;
        this.dmgInTick = dmgInTick;
        this.healInTick = healInTick;
        this.intervalBetweenTicks = intervalBetweenTicks;
    }
    public abstract void Init();
    
    //Надо как-то сделать проверку в этом классе на то равен target null
    //или нет, чтобы не ебать себе мозги по этому поводу при каждом создани
    //статуса

}
