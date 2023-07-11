using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Spell[] Spells;
    private Caster caster;
    private MovementControl _control;
    private PlayerInput _playerInput;

    private void Start()
    {
        caster = GetComponent<Caster>();
        _control = GetComponent<MovementControl>();
        
        
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.cast_spell_1.performed += x => caster.Cast(caster.spells[0]);
        _playerInput.Player.cast_spell_2.performed += x => caster.Cast(caster.spells[1]);
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
}
