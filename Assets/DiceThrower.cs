using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Caster))]
public class DiceThrower : MonoBehaviour
{
    public GameObject diceThrowGameObject;

    private Caster _caster;
    private DiceThrowScript _diceScript;
    private PlayerInput _playerInput;

    private void Start()
    {
        _caster = GetComponent<Caster>();
        diceThrowGameObject = Instantiate(diceThrowGameObject);
        _diceScript = diceThrowGameObject.GetComponent<DiceThrowScript>();
        
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        _playerInput.Player.roll_dice.performed += Roll;

    }

    // private IEnumerator Roll()
    // {
    //     _diceScript.ThrowDice();
    //     while (!_diceScript.isRolled)
    //     {
    //         yield return null;
    //     } 
    //     Debug.Log(_diceScript.TopEdge.name);
    // }
    
    private void Roll(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            _diceScript.ThrowDice();
            //StartCoroutine(_diceScript.RollCoroutine());
        }
    }
}
