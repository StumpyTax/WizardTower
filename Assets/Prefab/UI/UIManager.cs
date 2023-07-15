using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /*public SpellStorable spell1;
    public SpellStorable spell2;*/
    
    public GameObject spell1Window;
    public GameObject spell2Window;
/*    private GameObject[] SpellsWindow=new GameObject[2];
*/
    public GameObject spell1WindowBackground;
    public GameObject spell2WindowBackground;
/*    private GameObject[] SpellsWindowBackground=new GameObject[2];
*/    
    public Image Spell1WindowImage;
    public Image Spell2WindowImage;
    private Image[] SpellsWindowImage=new Image[2];


    public Image Spell1WindowImageBackground;
    public Image Spell2WindowImageBackground;
    private Image[] SpellsWindowImageBackground=new Image[2];

    public GameObject devourWindow;
    public GameObject diceMiniWindow;
    public GameObject menu;

    private Player _player;
    

    public GameObject diceChooseWindow;

    public void Start()
    {
        SpellsWindowImage[0] = spell1Window.GetComponent<Image>();
        SpellsWindowImage[1] = spell2Window.GetComponent<Image>();

        SpellsWindowImage[0].type = Image.Type.Filled;
        SpellsWindowImage[1].type = Image.Type.Filled;
        SpellsWindowImage[0].fillMethod = Image.FillMethod.Vertical;
        SpellsWindowImage[1].fillMethod = Image.FillMethod.Vertical;

        SpellsWindowImageBackground[0] = spell1WindowBackground.GetComponent<Image>();
        SpellsWindowImageBackground[1] = spell2WindowBackground.GetComponent<Image>();

        SpellsWindowImageBackground[0].color = new Color(1, 1, 1, 0.25f);
        SpellsWindowImageBackground[1].color = new Color(1, 1, 1, 0.25f);
        
        _player = GameManager.instance
            .curPlayer
            .GetComponent<Player>();

        _player.uiManager = this;
       /* spell1 = _player.caster.spells[0];
        spell2 = _player.caster.spells[1];*/
    }

    public void Update()
    {
        var spell1 = _player.caster.spells[0];
        var spell2 = _player.caster.spells[1];

        if (spell1 != null)
            UpdateSpell(0);
        if (spell2 != null)
            UpdateSpell(1);
        

       /* Spell1WindowImage.sprite = spell1.icon;
        Spell2WindowImage.sprite = spell2.icon;

        Spell1WindowImage.fillAmount = 1 - (_player.caster.spells[0].curCooldown 
                                            / spell1.cooldown);
        Spell2WindowImage.fillAmount = 1 - (_player.caster.spells[1].curCooldown 
                                            / spell2.cooldown);
        
        Spell1WindowImageBackground.sprite = spell1.icon;
        Spell2WindowImageBackground.sprite = spell2.icon;*/

    }

    private void UpdateSpell(int index)
    {
        var spell = _player.caster.spells[index];
        SpellsWindowImage[index].sprite = spell.icon;
        SpellsWindowImage[index].fillAmount = 1 - (_player.caster.spells[index].curCooldown
                                            / spell.cooldown);
        SpellsWindowImageBackground[index].sprite = spell.icon;
    }

    public void ShowDiceChooseWindow()
    {
        diceMiniWindow.SetActive(false);
        diceChooseWindow.SetActive(true);
    }
    
    public void HideDiceChooseWindow()
    {
        diceMiniWindow.SetActive(true);
        diceChooseWindow.SetActive(false);
    }
    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
