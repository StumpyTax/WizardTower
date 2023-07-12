using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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
