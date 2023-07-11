using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class CasterPlayer : Caster
{
    private PlayerInput _playerInput;
    private Spell _spell;
    
    public Entity entity;

    public void Start()
    {
        entity = GetComponent<Entity>();
        _playerInput = new PlayerInput();
        
        _playerInput.Player.Enable();
        _playerInput.Player.cast_spell_1.performed += x =>  Cast(spells[0]);
        _playerInput.Player.cast_spell_2.performed += x =>  Cast(spells[1]);
    }

    public void OnCastEnd()
    {
        GetComponent<Animator>().SetBool("Cast", false);
        _spell.casterEntity = entity;
        _spell.targetDir = GetMousePosition();
        _spell.targetDir.z = 0;
        Instantiate(_spell);
    }
    public void Cast(Spell spell)
    {
        _spell = spell;
        GetComponent<Animator>().SetBool("Cast", true);
    }

    public static Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
