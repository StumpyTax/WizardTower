using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DiceScript : MonoBehaviour
{
    public GameObject edgeTemplate;
    public float indent = 0.5001f;
    public List<GameObject> Edges;
    public bool isRolled;

    private Unity.Mathematics.Random _random;
    private Rigidbody rb;

    public void Start()
    {
        _random = new Unity.Mathematics.Random(76319);
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < 6; i++)
        {
            var edge = Instantiate(edgeTemplate);
            edge.name = edgeTemplate.name + i;
            edge.transform.SetParent(transform,false);
            Edges.Add(edge);
        }


        Edges[0].transform.localPosition = new Vector3(0f, 0f, indent);
        Edges[1].transform.localPosition = new Vector3(0f, 0f, -indent);
        Edges[0].transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Edges[1].transform.eulerAngles = new Vector3(0f, 0f, -0f);
        
        Edges[2].transform.localPosition = new Vector3(0f, indent, 0f);
        Edges[3].transform.localPosition = new Vector3(0f, -indent, 0f);
        Edges[2].transform.eulerAngles = new Vector3(90f, 0f, 0f);
        Edges[3].transform.eulerAngles = new Vector3(90f, 0f, 0f);
        
        Edges[4].transform.localPosition = new Vector3(indent, 0f, 0f);
        Edges[5].transform.localPosition = new Vector3(-indent, 0f, 0f);
        Edges[4].transform.eulerAngles = new Vector3(0f, 90f, 0f);
        Edges[5].transform.eulerAngles = new Vector3(0f, 90f, -0f);
        
        foreach (var edge in Edges)
        {
            edge.SetActive(true);
            edge.transform.localScale = edge.transform.lossyScale;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);

    }
    public bool isEdgeValid()
    {
        // Debug.Log("start");
        // StartCoroutine(ExampleCoroutine());
        
        Debug.Log("angular"+rb.angularVelocity.Equals(Vector3.zero));
        Debug.Log("velocity"+rb.velocity.Equals(Vector3.zero));
        Debug.Log("magnitude"+Math.Abs(rb.position.z - (-0.5f)));
        Debug.Log(rb.angularVelocity.Equals(Vector3.zero) &&
                  rb.velocity.Equals(Vector3.zero) &&
                  Math.Abs(rb.position.z - (-0.5f)) < 0.05f);

        return rb.angularVelocity.Equals(Vector3.zero) &&
               rb.velocity.Equals(Vector3.zero) &&
               Math.Abs(rb.position.z - (-0.5f)) < 0.05f;
    }

    private void Update()
    {
        GetTopEdge();
    }

    public void ThrowDice()
    {
        isRolled = false;
        var torqueRandomX = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        var torqueRandomY = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        var torqueRandomZ = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        //rb.AddForce(new Vector3(0, 0, -Random.Range(3, 6)) * rb.mass, ForceMode.Impulse);
        rb.AddTorque(new Vector3(torqueRandomX, torqueRandomY, torqueRandomZ), ForceMode.Impulse);
    }

    public GameObject GetTopEdge()
    {
        GameObject topEdge = null;
        foreach (var edge in Edges)
        {
            if (topEdge is null)
            {
                topEdge = edge;
            }
            if (edge.transform.position.z < topEdge.transform.position.z)
            {
                topEdge = edge;
            }
        }

        return topEdge;
    }

    private IEnumerator ttt()
    {
        while (!isRolled)
        {
            if ((Math.Abs(rb.position.z - (-1.5f)) < 0.05f))
            {
                isRolled = true;
                var _topEdge = GetTopEdge();

                yield break;
            }

            yield return null;
        }
    }
}