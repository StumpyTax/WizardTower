using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MovementControl))]
public class Golem : Enemy
{
    public float attackRange;
    public float attackTriggerRange;


    public GameObject _attackTrigger;
    //public GameObject _attackRange;
    private Animator _animator;
    private bool isReady = true;
    private bool isEnemyClose;
    private bool isEnemyInRange;

    public void Start()
    {
        _attackTrigger = Instantiate(_attackTrigger, gameObject.transform, false);
        _attackTrigger.name = "triggerRange";
        var script = _attackTrigger.GetComponent<AttackTrigger>();
        script.radius = attackTriggerRange;
        script.OnStay += (Collider) =>
        {
            Debug.Log("Hello");
            isEnemyClose = true;
        };
        script.OnExit += (Collider) =>
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
        _animator = GetComponent<Animator>();
        entity.OnDeath += () => _animator.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(gameObject);
    }
    public void Update()
    {
        var dir = player.transform.position - transform.position;
        dir.z = 0;
        dir=dir.normalized;
        if (dir.x >= 0)
            _animator.SetFloat("Horizontal",1);
        else
            _animator.SetFloat("Horizontal", -1);

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
        _animator.SetTrigger("Attack");
        /*
        StartCoroutine(AttackRoutine());*/
    }

    private void /*IEnumerator*/ AttackRoutine()
    {
/*        isReady = false;
        yield return new WaitForSeconds(1f);*/
        _caster.Cast(_caster.spells[0]);
    }
}
