using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scen : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LetsStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void GG()
    {
        Application.Quit();
    }
}
