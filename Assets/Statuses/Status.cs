using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public int id;
    [SerializeField]private Sprite _icon;
    [SerializeField]private float _duration;
    public float duration { get { return _duration; }}
    public float curDur;

    public float dmgInSec;
    public float HealInSec;
    public Entity target;

    private void Start()
    {
        target= GetComponent<Entity>();
        if (target == null)
            Destroy(gameObject);
    }
    //Надо как-то сделать проверку в этом классе на то равен target null
    //или нет, чтобы не ебать себе мозги по этому поводу при каждом создани
    //статуса

    public float GetInTick(float valueInSec)
    {
        return valueInSec * Time.fixedDeltaTime;
    }
    
}
