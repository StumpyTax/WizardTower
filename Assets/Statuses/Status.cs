using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    [SerializeField]private Sprite _icon;
    [SerializeField]private float _duration;
    public float duration { get { return _duration; }}
    protected float curDur;

    public float dmgInSec;
    public float HealInSec;
    public Entity target;

    private void Start()
    {
        target= GetComponent<Entity>();
        if (target == null)
            Destroy(gameObject);
    }
    //���� ���-�� ������� �������� � ���� ������ �� �� ����� target null
    //��� ���, ����� �� ����� ���� ����� �� ����� ������ ��� ������ �������
    //�������

    public float GetInTick(float valueInSec)
    {
        return valueInSec * Time.fixedDeltaTime;
    }
    
}
