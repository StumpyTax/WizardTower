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

    private Caster _caster;
    private MovementControl _movementControl;


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

    public void Update()
    {
        _movementControl.FixedUpdate();
        if (isReady)
            if (isEnemyClose)
                Attack();
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        isReady = false;
        yield return new WaitForSeconds(1f);
        _caster.direction = player.GetComponent<CapsuleCollider>().bounds.center;
        _caster.Cast(_caster.spells[0]);
        isReady = true;
    }
}
