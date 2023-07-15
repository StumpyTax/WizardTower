using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : ScriptableObject
{
    public Entity entity;
    public Action OnGet;
    public Action OnEnd;
    private List<StatusStorable> _statuses;
    
    // public void AddNewStatuses(IEnumerable<StatusStorable> statuses)
    // {
    //     foreach (var status in statuses)
    //     {
    //         AddNewStatus(status);
    //     }
    // }

}
