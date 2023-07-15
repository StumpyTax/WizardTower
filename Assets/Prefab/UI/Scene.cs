using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public AudioSource audio;
    public static void ToMainMenu()
    {
        
        GameManager.instance.curPlayer=null;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public void LetsStart()
    {
        audio.Play();
        SceneManager.LoadScene("Start");
    }
    public void GG()
    {
        audio.Play();
        Application.Quit();
    }
}
