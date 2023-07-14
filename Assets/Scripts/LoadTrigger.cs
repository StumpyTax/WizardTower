using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    private void Start()
    {
        var gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.GetComponent<GameManager>().PlayerPosition();
    }
}
