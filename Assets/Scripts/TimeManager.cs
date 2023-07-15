using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private List<TimeAction> _actions;
    public static TimeManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _actions = new List<TimeAction>();
    }


    public void AddAction(Action action, float delay)
    {
        var a = TimeAction.NewAction(action, delay);
        a.OnDestroy += () =>
        {
            _actions.Remove(a);
        };
        _actions.Add(a);
    }
    
    void Update()
    {
        for (var i = 0; i < _actions.Count; i++)
        {
            _actions[i].Update();
        }
    }
}
