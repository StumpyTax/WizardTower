using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Caster : MonoBehaviour
{
    public Queue<Spell> spells;
    public Dictionary<Guid, Spell> spellsDict;
    
    

    private PlayerInput _playerInput;

    public void Start()
    {
        spells = new Queue<Spell>(2);
        spellsDict = new Dictionary<Guid, Spell>();
        _playerInput = GetComponent<PlayerInput>();
        
        var i = 0;
        
        // foreach (var action in _playerInput.actions)
        // {
        //     spellsDict.Add(action.id, spells.ToArray()[i]);
        //     _playerInput.onActionTriggered += Cast;
        //     i++;
        // }
    }

    private void Cast(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            var spell = spellsDict[action.action.id];
            spell.caster = this;
            Instantiate(spell);   
        }
    }
}
