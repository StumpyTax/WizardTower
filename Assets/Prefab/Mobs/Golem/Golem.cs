using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Golem : CasterEnemy
{
    public float attackRange;
    public float attackTriggerRange;


    public GameObject _attackTrigger;
    //public GameObject _attackRange;

    private bool isReady = true;
    private bool isEnemyClose;
    private bool isEnemyInRange;

    public void Start()
    {
        base.Start();
        entity.Start();
        _attackTrigger = Instantiate(_attackTrigger, gameObject.transform, false);
        _attackTrigger.name = "triggerRange";
        var script = _attackTrigger.GetComponent<AttackTrigger>();
        script.radius = attackTriggerRange;
        script.OnStay += () =>
        {
            Debug.Log("Hello");
            isEnemyClose = true;
        };
        script.OnExit += () =>
        {
            Debug.Log("where are you?");
            isEnemyClose = false;
        };
        
        // _attackRange = Instantiate(_attackRange, gameObject.transform, false);
        // _attackRange.name = "attackRange";
        // script = _attackRange.GetComponent<AttackTrigger>();
        // script.radius = attackRange;
        // script.OnEnter += () =>
        // {
        //     isEnemyInRange = true;
        // };
        // script.OnExit += () =>
        // {
        //     isEnemyInRange = false;
        // };
    }

    public void Update()
    {
        entity.Update();
        if (isReady)
            if (isEnemyClose)
                Attack();
            else
                entity.GoTo(entity.player.transform.position);
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isReady = false;
        yield return new WaitForSeconds(1f);
        Cast(spells[0]);
        isReady = true;
    }
}
