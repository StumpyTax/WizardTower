using UnityEngine;

[RequireComponent(typeof(Entity))]
public class CasterPlayer : Caster
{
    public Entity entity;
    
    private PlayerInput _playerInput;

    public void Start()
    {
        entity = GetComponent<Entity>();
        _playerInput = new PlayerInput();
        
        _playerInput.Player.Enable();
        _playerInput.Player.cast_spell_1.performed += x =>  Cast(spells[0]);
        _playerInput.Player.cast_spell_2.performed += x =>  Cast(spells[1]);
    }

    public override void Cast(Spell spell)
    {
        spell.casterEntity = entity;
        spell.targetDir = GetMousePosition();
        Instantiate(spell);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
