using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    private GameObject _target;
    public float duration;
    private Sprite _icon;
    

    public abstract void Tick();


}
