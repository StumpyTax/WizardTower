using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHp=100;
    private float _hp;
    private bool isAlive=true;

    public float Hp
    {
        get => _hp;
        set
        {
            if (value < _hp)
            {
                _hp = value;
                if (_hp <= 0 && isAlive)
                {
                    isAlive = false;
                    if (OnDeath != null) 
                        OnDeath.Invoke();
                    return;
                }
                if (OnDamageTaken != null)
                    OnDamageTaken.Invoke();   
            }
            Debug.Log(Hp);
            if (value > _hp)
            {
                _hp = value;
                if (OnHeal != null)
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
    public Action OnGetStatus;

    public string team;

    [SerializeField] public List<Status> _statuses;
    private void Start()
    {
        _hp = maxHp;
    }
    public void AddNewStatus(StatusStorable statusStorable)
    {
        var status = Instantiate(statusStorable.status);
        status.Init();
        status.OnEnd += (entity) =>
        {
            Debug.Log("removed");
            _statuses.Remove(status);
            Destroy(status.gameObject);
        };
        _statuses.Add(status);
        status.OnGet?.Invoke(this);
    }
    public void AddNewStatuses(IEnumerable<StatusStorable> statuses)
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
