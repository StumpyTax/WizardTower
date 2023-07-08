using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Caster))]
public class DiceThrower : MonoBehaviour
{
    public GameObject diceThrowGameObject;

    private Caster _caster;
    private DiceThrowScript _diceThrowScript;
    private PlayerInput _playerInput;

    private void Start()
    {
        _caster = GetComponent<Caster>();
        diceThrowGameObject = Instantiate(diceThrowGameObject);
        _diceThrowScript = diceThrowGameObject.GetComponent<DiceThrowScript>();
        
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
    
    private async void Roll(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            _diceThrowScript.ThrowDice();
            while (!_diceThrowScript.isEdgeValid())
            {
                Debug.Log("await");
                await Task.Yield();
            }
            Debug.Log(_diceThrowScript.topEdge.GetComponent<Edge>().spell);
            _caster.spells[0] = _diceThrowScript.topEdge.GetComponent<Edge>().spell;
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(10000f);
    }
}
