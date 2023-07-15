using Random = UnityEngine.Random;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(MovementControl))]
public class Golem : Enemy
{
    public float attackRange;
    public float attackTriggerRange;

    private Rigidbody _rb;
    public GameObject _attackTrigger;
    //public GameObject _attackRange;
    private Animator _animator;
    private bool isReady = true;
    private bool isEnemyClose;
    private bool isEnemyInRange;
    private bool isWalking;

    private AudioSource _audioSource;
    public AudioClip walk;
    public AudioClip death;
    public AudioClip attack;


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

        _rb= GetComponent<Rigidbody>();
        _audioSource= GetComponent<AudioSource>();
    }

    public void Awake()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        entity.OnDeath += () => {
            _audioSource.Stop();
            _audioSource.loop= false;
            _audioSource.clip = death;
            _audioSource.Play();
            _animator.SetTrigger("Death"); };
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
            {
                _audioSource.Stop();
                _audioSource.loop = false;
                _audioSource.clip = attack;
                _audioSource.Play();
                Attack();
            }
            else
                _movementControl.MoveTo(
                    _movementControl.GetMoveVector(
                        transform.position, player.transform.position));

        if (_rb.velocity.magnitude > 0.1 && !isWalking)
        {
            _audioSource.Stop();
            isWalking = true;
            _audioSource.loop = true;
            _audioSource.clip = walk;
            _audioSource.Play();
        }
        else if (_rb.velocity.magnitude < 0.1)
        {
            isWalking = false;
            _audioSource.Stop();
        }
        else
            _audioSource.pitch = Random.Range(0.7f,1.1f);
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
