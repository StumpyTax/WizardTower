using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class movePlayer2 : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 300f;
    public float FrictionForce = 30f;
    public float FrictionForceWindow = 30f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;
    private Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // обратите внимание что все действия с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()
    {
        MovementLogic();
        Friction();
        FrictionBound();
        //JumpLogic();
        _anim.SetFloat("moveX", Mathf.Abs(_rb.velocity.x));
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce((movement) * Speed);
        var _frictionVector = _rb.velocity;
    }

    private void Friction()
    {
        var _frictionVector = _rb.velocity;
        _frictionVector.Scale(new Vector3(-FrictionForce, 0, -FrictionForce));
        _rb.AddForce(_frictionVector);
    }

    private void FrictionBound()
    {
        if (_rb.velocity.x < FrictionForceWindow && _rb.velocity.x > -FrictionForceWindow)
        {
            var _vector = _rb.velocity;
            _vector.Set(_vector.x * -1 * _rb.mass, 0, 0);
            _rb.AddRelativeForce(_vector, ForceMode.VelocityChange);
        }
        if (_rb.velocity.z < FrictionForceWindow && _rb.velocity.z > -FrictionForceWindow)
        {
            var _vector = _rb.velocity;
            _vector.Set(0, 0, _vector.z * -1 * _rb.mass);
            _rb.AddRelativeForce(_vector, ForceMode.VelocityChange);
        }
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);

                // Обратите внимание что я делаю на основе Vector3.up 
                // а не на основе transform.up. Если персонаж упал или 
                // если персонаж -- шар, то его личный "верх" может 
                // любое направление. Влево, вправо, вниз...
                // Но нам нужен скачек только в абсолютный вверх, 
                // потому и Vector3.up
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}