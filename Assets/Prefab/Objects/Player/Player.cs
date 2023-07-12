using UnityEngine;

public class Player : Entity
{
    private Caster caster;
    private MovementControl _control;
    private PlayerInput _playerInput;

    private void Start()
    {
        caster = GetComponent<Caster>();
        _control = GetComponent<MovementControl>();
        
        
        _playerInput = new PlayerInput();
        _playerInput.Enable();
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
    }

    public void FixedUpdate()
    {
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
}
