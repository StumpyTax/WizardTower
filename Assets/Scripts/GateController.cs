using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GateController : MonoBehaviour
{

    public int sceneId;
    public bool roomIsClear;
/*    public GameObject anim;
*/  
    
    public void changeScene()
    {
        SceneManager.LoadScene(sceneId);
    }
    public void Finish()
    {
/*        anim.SetActive(true);
*/    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && roomIsClear)
        {
            changeScene();
        }
                
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
