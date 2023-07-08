using UnityEngine;

public class CasterPlayer : Caster
{
    private PlayerInput _playerInput;
    public Vector3 mousePosition;

    public void Start()
    {
        _playerInput = new PlayerInput();
        
        _playerInput.Player.Enable();
        _playerInput.Player.cast_spell_1.performed += x =>  Cast(spells[0]);
        _playerInput.Player.cast_spell_2.performed += x =>  Cast(spells[1]);
    }
    

    private void Cast(Spell spell)
    {
        spell.casterPlayer = this;
        spell.targetDir = getMousePosition();
        Instantiate(spell);
    }

    public Vector3 getMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
