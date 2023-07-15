using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviour
{
    public Entity entity;
    public Caster caster { get; private set; }
    public MovementControl movementControl { get; private set; }
    public float pickUpRange;
    public GameObject rangeTrigger;

    public Devour devour;
    private EdgeCracked edge = null;



    private PlayerInput _playerInput;
    private DiceThrower _diceThrower;
    public UIManager uiManager;
    private Animator _animator;
    private SpriteRenderer _rend;
    private Material _defMat;
    private Material _blinkMat;


    private void Start()
    {
        entity = GetComponent<Entity>();
        entity.team = "player";
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();

        _playerInput = GetComponent<PlayerInput>();
        
        caster = GetComponent<Caster>();
        caster.isEnable = true;
        movementControl = GetComponent<MovementControl>();
        movementControl.isEnable = true;
        _diceThrower = GetComponent<DiceThrower>();
        _diceThrower.playerInput = _playerInput;
        
        _playerInput.actions["cast_spell_1"].performed += x =>
        {
            caster.direction = GetMousePosition();
            caster.Cast(caster.spells[0]);
        };
        _playerInput.actions["cast_spell_2"].performed += x =>
        {
            caster.direction = GetMousePosition();
            caster.Cast(caster.spells[1]);
        };
        _playerInput.actions["Pause"].performed += x =>
        {
            uiManager.ShowMenu();
        };
        _playerInput.actions["pick_up"].performed += PickUp;
        _playerInput.actions["roll_dice"].performed += _diceThrower.Roll;

        _playerInput.actions["confirm"].performed += x =>
        {
            _diceThrower._diceChoose.enabled = false;
            _diceThrower._diceThrowScript.enabled = true;
            _playerInput.SwitchCurrentActionMap("DiceChoose");
            uiManager.HideDiceChooseWindow();
        };
        
        var collider = rangeTrigger.GetComponent<RangeTrigger>();
        collider.radius = pickUpRange;
        rangeTrigger = Instantiate(rangeTrigger, gameObject.transform, false);
        collider = rangeTrigger.GetComponent<RangeTrigger>();
        collider.OnStay += (collider) =>
        {
            EdgeCracked edge;
            if (collider.TryGetComponent<EdgeCracked>(out edge))
                this.edge = edge;
        };
        collider.OnExit += (collider) =>
        {
            edge = null;
        };

        _animator = GetComponent<Animator>();
        _rend = GetComponentInChildren<SpriteRenderer>();
        _defMat = _rend.material;
        _blinkMat = Resources.Load("Blink", typeof(Material)) as Material;

        entity.OnDeath += OnDeath;
        entity.OnDamageTaken += OnDamageTaken;
        

        
        SpellShowUIContract();
        //_diceThrower.OnSpellsChanged.Invoke(caster.spells[0], caster.spells[1]);
    }
    private void OnDeath() 
    {
        entity.isStunned = true;
        _animator.SetTrigger("Death");
    }
    private void Death()
    {
        Scene.ToMainMenu();
    }
 
    private void OnDamageTaken()
    {
        _rend.material = _blinkMat;
        Invoke("ResetMaterial", 0.3f);
    }
    private void ResetMaterial()
    {
        _rend.material = _defMat;
    }
    private void OnDmgTakenEnd()
    {

    }

    public void FixedUpdate()
    {
        if (_playerInput == null) return;
        if (_playerInput.enabled)
            movementControl.MoveTo(PlayerMoveDirection());
    }

    private Vector3 PlayerMoveDirection()
    {
        Vector3 vector = _playerInput.actions["move"].ReadValue<Vector2>();
        return vector;
    }
    
    public static Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void PickUp(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(edge);
        if (edge == null)
        {
            return;
        }
        Destroy(edge.gameObject);
        _diceThrower.Choose(edge.edge);
        _diceThrower._diceChoose.enabled = true;
        _diceThrower._diceThrowScript.enabled = false;
        _playerInput.SwitchCurrentActionMap("Player");
        uiManager.ShowDiceChooseWindow();
        edge = null;
    }

    private void SpellShowUIContract()
    {
        _diceThrower.OnSpellsChanged += (spell1, spell2) =>
        {
            uiManager.spell1 = spell1;
            uiManager.spell2 = spell2;
        };
    }
}
