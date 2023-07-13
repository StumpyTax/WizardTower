using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MovementControl))]
public class Golem : Enemy
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
        _caster = GetComponent<Caster>();
        _movementControl = GetComponent<MovementControl>();
    }

    public void Awake()
    {
        base.Start();
    }

    public void Update()
    {
        _movementControl.FixedUpdate();
        if (isReady)
            if (isEnemyClose)
                Attack();
            else
                _movementControl.MoveTo(
                    _movementControl.GetMoveVector(
                        transform.position, player.transform.position));
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isReady = false;
        yield return new WaitForSeconds(1f);
        _caster.Cast(_caster.spells[0]);
        isReady = true;
    }
}
