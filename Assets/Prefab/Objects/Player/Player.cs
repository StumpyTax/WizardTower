using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviour
{
    public Entity entity;
    public Caster caster { get; private set; }
    public MovementControl movementControl { get; private set; }
    private PlayerInput _playerInput;
    private DiceThrower _diceThrower;
    private UIManager _uiManager;

    private void Start()
    {
        entity = GetComponent<Entity>();
        entity.team = "player";
        _uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        
        caster = GetComponent<Caster>();
        caster.isEnable = true;
        movementControl = GetComponent<MovementControl>();
        movementControl.isEnable = true;
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
    }

    public void FixedUpdate()
    {
        if (_playerInput.Player.enabled)
            movementControl.MoveTo(PlayerMoveDirection());
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
