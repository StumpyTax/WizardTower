using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Caster : MonoBehaviour
{
    public Spell[] spells;
    private PlayerInput _playerInput;

    public void Start()
    {
        _playerInput = new PlayerInput();
        
        _playerInput.Player.Enable();
        _playerInput.Player.cast_spell_1.performed += x =>  Cast(spells[0]);
        _playerInput.Player.cast_spell_2.performed += x =>  Cast(spells[1]);


        //var i = 0;

        // foreach (var action in _playerInput.actions)
        // {
        //     spellsDict.Add(action.id, spells.ToArray()[i]);
        //     _playerInput.onActionTriggered += Cast;
        //     i++;
        // }
    }

    private void Cast(Spell spell)
    {
        spell.caster = this;
        Instantiate(spell);
    }

    // private void Cast(InputAction.CallbackContext action)
    // {
    //     if (action.performed)
    //     {
    //         var spell = spellsDict[action.action.id];
    //         spell.caster = this;
    //         Instantiate(spell);   
    //     }
    // }
}
