using System;
using System.Collections;
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
    public DiceChoose   _diceChoose { get; private set; }
    public AudioClip invoke;

    private void Start()
    {
        _caster = GetComponent<Caster>();
        diceThrowGameObject = Instantiate(diceThrowGameObject);
        _diceThrowScript = diceThrowGameObject.GetComponent<DiceThrowScript>();
        _diceChoose = diceThrowGameObject.GetComponentInChildren<DiceChoose>();

        playerInput.actions["confirm"].performed += x => _diceChoose.Confirm();
    }
    public void Choose(Edge edge)
    {
        _diceChoose.newEdge = edge.GameObject();
        _diceThrowScript.enabled = false;
        _diceChoose.enabled = true;
    }
    
    public IEnumerator Roll(InputAction.CallbackContext action)
    {
        var source = GetComponent<AudioSource>();
        source.clip = invoke;
        source.loop = false;
        source.Play();

        Debug.Log("roll_dice");
        Debug.Log(_diceThrowScript.isEdgeValid());
        Debug.Log(action.performed);
        if (action.performed && _diceThrowScript.isEdgeValid())
        {
            Debug.Log("ThrowDice");
            _diceThrowScript.ThrowDice();
            Debug.Log("await delay");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("while !_diceThrowScript.isEdgeValid()");
            Debug.Log(!_diceThrowScript.isEdgeValid());

            while (!_diceThrowScript.isEdgeValid())
            {
                Debug.Log("await");
                yield return null;
            }

            var spell = _diceThrowScript.topEdge().GetComponent<Edge>().spell;
            Debug.Log(spell);
            if (spell == null) yield break;
            _caster.spells[1] = _caster.spells[0];
            _caster.spells[0] = spell.Get();
            
        }
    }
}
