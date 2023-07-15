using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SpellStorable spell1;
    public SpellStorable spell2;
    
    public GameObject spell1Window;
    public GameObject spell2Window;
    public GameObject spell1WindowBackground;
    public GameObject spell2WindowBackground;
    
    public Image Spell1WindowImage;
    public Image Spell2WindowImage;
    public Image Spell1WindowImageBackground;
    public Image Spell2WindowImageBackground;
    
    public GameObject devourWindow;
    public GameObject diceMiniWindow;
    public GameObject menu;

    

    public GameObject diceChooseWindow;
     
    public void Start()
    {
        Spell1WindowImage = spell1Window.GetComponent<Image>();
        Spell2WindowImage = spell2Window.GetComponent<Image>();
        Spell1WindowImage.type = Image.Type.Filled;
        Spell2WindowImage.type = Image.Type.Filled;
        Spell1WindowImage.fillMethod = Image.FillMethod.Vertical;
        Spell2WindowImage.fillMethod = Image.FillMethod.Vertical;
        
        Spell1WindowImageBackground = spell1WindowBackground.GetComponent<Image>();
        Spell2WindowImageBackground = spell2WindowBackground.GetComponent<Image>();
        Spell1WindowImageBackground.color = new Color(1, 1, 1, 0.25f);
        Spell2WindowImageBackground.color = new Color(1, 1, 1, 0.25f);
        
        var player = GameManager.instance
            .curPlayer
            .GetComponent<Player>();
        player.uiManager = this;
        spell1 = player.caster.spells[0];
        spell2 = player.caster.spells[1];
    }

    public void Update()
    {
        if (spell1 == null || spell2 == null) return;
        Spell1WindowImage.sprite = spell1.icon;
        Spell2WindowImage.sprite = spell2.icon;
        Spell1WindowImage.fillAmount = 1 - (spell1.curCooldown / spell1.cooldown);
        Spell2WindowImage.fillAmount = 1 - (spell2.curCooldown / spell2.cooldown);
        
        Spell1WindowImageBackground.sprite = spell1.icon;
        Spell2WindowImageBackground.sprite = spell2.icon;

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
