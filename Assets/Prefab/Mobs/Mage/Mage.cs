using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MovementControl))]
public class Mage : Enemy
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
        _animator=GetComponent<Animator>();
        entity.OnDeath += OnDeath;
    }

    public void Update()
    {
        _movementControl.FixedUpdate();
        if (isReady)
            if (isEnemyClose && _caster.spells[0].curCooldown <= 0)
                Attack();
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
    private void AttackRoutine()
    {
        _caster.direction = player.GetComponent<CapsuleCollider>().bounds.center;
        _caster.Cast(_caster.spells[0]);
    }
    private void OnDeath()
    {
        _animator.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
