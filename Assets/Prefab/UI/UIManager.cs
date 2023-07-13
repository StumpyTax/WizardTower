using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject spell1Window;
    public GameObject spell2Window;
    public GameObject devourWindow;
    public GameObject diceMiniWindow;

    public GameObject diceChooseWindow;

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
}
