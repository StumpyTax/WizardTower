using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenLoader : MonoBehaviour 
{ 
    public void OnFadeComplete()
    {
        GameManager.instance.NextRoom();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
