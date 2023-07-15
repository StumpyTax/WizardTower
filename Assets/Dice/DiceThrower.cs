using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class DiceThrower : MonoBehaviour
{
    public Action<SpellStorable, SpellStorable> OnSpellsChanged;
    
    public GameObject diceThrowGameObject;
    public PlayerInput playerInput;
    private Caster _caster;
    public DiceThrowScript _diceThrowScript { get; private set; }
    public DiceChoose _diceChoose { get; private set; }

    private void Start()
    {
        _caster = GetComponent<Caster>();
        diceThrowGameObject = Instantiate(diceThrowGameObject);
        _diceThrowScript = diceThrowGameObject.GetComponent<DiceThrowScript>();
        _diceChoose = diceThrowGameObject.GetComponentInChildren<DiceChoose>();

        //playerInput.DiceChoose.confirm.performed += x => _diceChoose.Confirm();
    }
    public void Choose(Edge edge)
    {
        _diceChoose.newEdge = edge.GameObject();
        _diceThrowScript.enabled = false;
        _diceChoose.enabled = true;
    }
    
    public async void Roll(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            _diceThrowScript.ThrowDice();
            while (!_diceThrowScript.isEdgeValid())
            {
                Debug.Log("await");
                await Task.Yield();
            }
            Debug.Log(_diceThrowScript.topEdge().GetComponent<Edge>().spell);
            _caster.spells[1] = _caster.spells[0];
            _caster.spells[0] = _diceThrowScript.topEdge().GetComponent<Edge>().spell.Get();
            OnSpellsChanged.Invoke(_caster.spells[0], _caster.spells[1]);
        }
    }
}
