using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceScript : MonoBehaviour
{
    public Edge TopEdge;
    public List<Edge> Edges;
    public bool isRolled;

    private Unity.Mathematics.Random _random;
    private Rigidbody rb;

    public void Start()
    {
        _random = new Unity.Mathematics.Random(76319);
        rb = GetComponent<Rigidbody>();
        Edges.AddRange(GetComponentsInChildren<Edge>());
    }

    public void ThrowDice()
    {
        isRolled = false;
        var torqueRandomX = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        var torqueRandomY = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        var torqueRandomZ = (Random.Range(0, 40) - 20) * 5 * rb.mass;
        rb.AddForce(new Vector3(0, 0, -Random.Range(3, 6)) * rb.mass, ForceMode.Impulse);
        rb.AddTorque(new Vector3(torqueRandomX, torqueRandomY, torqueRandomZ), ForceMode.Impulse);
    }

    public Edge GetTopEdge()
    {
        Edge topEdge = null;
        foreach (var edge in Edges)
        {
            if (topEdge == null)
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

    private void OnCollisionEnter()
    {
        Debug.Log("Enter");
        rb.angularVelocity = Vector3.zero;
        StartCoroutine(ttt());
    }

    private IEnumerator ttt()
    {
        while (!isRolled)
        {
            if ((Math.Abs(rb.position.z - (-1.5f)) < 0.05f))
            {
                isRolled = true;
                var _topEdge = GetTopEdge();
                if (_topEdge != TopEdge)
                {
                    TopEdge = _topEdge;
                }

                yield break;
            }

            yield return null;
        }
    }
}