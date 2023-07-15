using System;
using Unity.VisualScripting;
using UnityEngine;

public class TimeAction 
{
    private float  _delay;
    private readonly Action _action;

    public Action OnDestroy;
    
    public static TimeAction NewAction(Action action, float delay)
    {
        return new TimeAction(action, delay);
    }

    public void Update()
    {
        _delay -= Time.deltaTime;
        if (_delay <= 0)
        {
            _action.Invoke();
            OnDestroy.Invoke();
        }
    }
    
    private TimeAction(Action action, float delay)
    {
        this._delay = delay;
        this._action = action;
        _action += () => {  };
    }
}
