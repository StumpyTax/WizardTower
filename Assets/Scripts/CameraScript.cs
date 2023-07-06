using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject player;

    void Start()
    {
        player= GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    private void UpdatePosition()
    {
        Vector3 tmp = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z);
        transform.position = tmp;
    }
    void Update()
    {
        UpdatePosition();
    }
}
