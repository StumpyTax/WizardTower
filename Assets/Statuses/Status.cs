using System;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public int id;
    [SerializeField]private Sprite _icon;
    [SerializeField]private float _duration;
    public float duration { get { return _duration; }}
    public float curDur;

    public float dmgInTick;
    public float HealInTick;
    public float intervalBetweenTicks;
    
    public Entity target;

    public Action<Entity> OnGet;
    public Action<Entity> OnTick;
    public Action<Entity> OnEnd;

    public abstract void Init();
    // {
    //     target= GetComponent<Entity>();
    //     if (target == null)
    //         Destroy(gameObject);
    // }
    //Надо как-то сделать проверку в этом классе на то равен target null
    //или нет, чтобы не ебать себе мозги по этому поводу при каждом создани
    //статуса

}
