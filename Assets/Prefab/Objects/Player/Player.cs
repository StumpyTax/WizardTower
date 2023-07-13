using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviour
{
    public Entity entity;

    private Caster caster;
    private MovementControl _control;
    private PlayerInput _playerInput;
    private DiceThrower _diceThrower;
    private UIManager _uiManager;
    private Animator _animator;
    private SpriteRenderer _rend;
    private Material _defMat;
    private Material _blinkMat;


    private void Start()
    {
        entity = GetComponent<Entity>();
        entity.team = "player";
        _uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        
        caster = GetComponent<Caster>();
        _control = GetComponent<MovementControl>();
        _diceThrower = GetComponent<DiceThrower>();
        _diceThrower.playerInput = _playerInput;
        
        _playerInput.Player.cast_spell_1.performed += x =>
        {
            caster.direction = GetMousePosition();
            caster.Cast(caster.spells[0]);
        };
        _playerInput.Player.cast_spell_2.performed += x =>
        {
            caster.direction = GetMousePosition();
            caster.Cast(caster.spells[1]);
        };
        _playerInput.Player.pick_up.performed += PickUp;
        _playerInput.Player.roll_dice.performed += _diceThrower.Roll;

        _animator = GetComponent<Animator>();
        _rend = GetComponentInChildren<SpriteRenderer>();
        _defMat = _rend.material;
        _blinkMat = Resources.Load("Blink", typeof(Material)) as Material;

        entity.OnDeath += OnDeath;
        entity.OnDamageTaken += OnDamageTaken;
    }
    private void OnDeath() 
    {
        entity.isStunned = true;
        _animator.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(gameObject);
    }
 
    private void OnDamageTaken()
    {
        _rend.material = _blinkMat;
    }
    private void OnDmgTakenEnd()
    {

    }

    public void FixedUpdate()
    {
        if (_playerInput.Player.enabled && !entity.isStunned)
            _control.MoveTo(PlayerMoveDirection());
    }

    private Vector3 PlayerMoveDirection()
    {
        return new Vector3( 
            (_playerInput.Player.left.inProgress ? -1 : 0) + (_playerInput.Player.right.inProgress ? 1 : 0),
            (_playerInput.Player.down.inProgress ? -1 : 0) + (_playerInput.Player.up.inProgress ? 1 : 0),
            0);
    }
    
    public static Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void PickUp(InputAction.CallbackContext callbackContext)
    {
        _diceThrower.Choose();
        _playerInput.Player.Disable();
        _playerInput.DiceChoose.Enable();
        _uiManager.ShowDiceChooseWindow();
    }
}
