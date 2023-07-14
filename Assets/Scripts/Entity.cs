using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Entity : MonoBehaviour
{
    public float maxHp=100;
    private float _hp;

    public float Hp
    {
        get => _hp;
        set
        {
            Debug.Log(Hp);
            if (value < _hp)
            {
                _hp = value;
                if (_hp <= 0)
                {
                    OnDeath.Invoke();
                    return;
                }
                if (OnDamageTaken != null)
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
    public bool isStunned;

    public Action OnHeal;
    public Action OnDeath;
    public Action OnDamageTaken;

    public string team;

    private List<Status> _statuses = new List<Status>();
    private void Start()
    {
        _hp = maxHp;
    }
    public void AddNewStatus(Status status)
    {
        Debug.Log("new status");
        status.Init();
        status.OnEnd += (entity) => _statuses.Remove(status);
        _statuses.Add(status);
        status.OnGet.Invoke(this);
    }
    public void AddNewStatuses(IEnumerable<Status> statuses)
    {
        foreach (var status in statuses)
        {
            AddNewStatus(status);
        }
    }
    public Status[] GetStatuses()
    {
        return _statuses.ToArray();
    }
}
