using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DiceChooseScript : MonoBehaviour
{
    public float axisMultiplayerX = 1;
    public float axisMultiplayerY = 1;
    public float FrictionForce = 0.5f;

    private Rigidbody rb;
    public List<Edge> Edges;
    private Unity.Mathematics.Random _random;

    public void Start()
    {
        _random = new Unity.Mathematics.Random(76319);
        rb = GetComponent<Rigidbody>();
        Edges.AddRange(GetComponentsInChildren<Edge>());
    }

    public void Update()
    {
        Friction();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0)) //если зажата ЛКМ
        {
            // gameObject.transform.rotation = Quaternion.Euler(
            //     gameObject.transform.rotation.eulerAngles.x + Input.GetAxis("Mouse Y") * axiseMultiplayerY,
            //     0f,
            //     gameObject.transform.rotation.eulerAngles.z + Input.GetAxis("Mouse X") * axiseMultiplayerX);
            rb.angularVelocity = new Vector3(
                rb.angularVelocity.x + Input.GetAxis("Mouse Y") * axisMultiplayerY,
                0f,
                rb.angularVelocity.z + Input.GetAxis("Mouse X") * axisMultiplayerX);
        }
    }

    private void Friction()
    {
        rb.angularVelocity += new Vector3(
            rb.angularVelocity.x * (Mathf.PI / -FrictionForce), 
            rb.angularVelocity.y * (Mathf.PI / -FrictionForce),
            rb.angularVelocity.z * (Mathf.PI / -FrictionForce));
    }
}
