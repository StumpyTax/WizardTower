using UnityEngine;
public class GateController : MonoBehaviour
{
    public bool enterGate=false;

    public void Finish()
    {
/*        anim.SetActive(true);
*/    }
     
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="Player" && GameManager.instance.roomIsClear && !enterGate)
        {
            var transition=GameObject.FindGameObjectWithTag("Transition");
            if (transition != null)
                transition.GetComponent<Animator>().SetTrigger("Fade");
        }
        else
        {
            Debug.Log(GameManager.instance.roomIsClear);
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
