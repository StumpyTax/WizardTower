using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private float _hp;
    public float Hp
    {
        get => _hp;
        set 
        {
            if (value < _hp)
            {
                _hp = value;
                if (_hp <= 0)
                {
                    OnDeath.Invoke();
                    return;
                }
                OnDamageTaken.Invoke();
            }
            if (value > _hp)
            {
                _hp = value;
                OnHeal.Invoke();
            }
        }
    }
    
    public int mastery;
    public float movementSpeed;
    public float critChance;

    public Action OnHeal;
    public Action OnDeath;
    public Action OnDamageTaken;
}
