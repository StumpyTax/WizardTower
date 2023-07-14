using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image bar;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        var entity = gameManager.curPlayer.GetComponent<Entity>();
        bar.fillAmount = entity.Hp / entity.maxHp;
        Debug.Log(bar.fillAmount);
    }
}
