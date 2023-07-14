using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public static void ToMainMenu()
    {
        
        GameManager.instance.curPlayer=null;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameManager.instance);
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
