using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusStorable", menuName = "StatusStorable")]
public class StatusStorable : ScriptableObject
{
    private Sprite _icon;

    public float duration;
    public float curDur;

    public float dmgInTick;
    public float healInTick;
    public float intervalBetweenTicks;

    public Status status;
}