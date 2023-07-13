using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public float indent = 0.5001f;
    public GameObject edgeTemplate;
    public List<GameObject> edges;

    private Rigidbody _rb;
    private GameObject _topEdge;
    public Action<GameObject, GameObject> OnTopEdgeChange;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        for (int i = 0; i < 6; i++)
        {
            edges[i] = Instantiate(edges[i]);
            edges[i].transform.SetParent(transform,false);
        }


        edges[0].transform.localPosition = new Vector3(0f, 0f, indent);
        edges[1].transform.localPosition = new Vector3(0f, 0f, -indent);
        edges[0].transform.eulerAngles = new Vector3(0f, 0f, 0f);
        edges[1].transform.eulerAngles = new Vector3(0f, 0f, -0f);
        
        edges[2].transform.localPosition = new Vector3(0f, indent, 0f);
        edges[3].transform.localPosition = new Vector3(0f, -indent, 0f);
        edges[2].transform.eulerAngles = new Vector3(90f, 0f, 0f);
        edges[3].transform.eulerAngles = new Vector3(90f, 0f, 0f);
        
        edges[4].transform.localPosition = new Vector3(indent, 0f, 0f);
        edges[5].transform.localPosition = new Vector3(-indent, 0f, 0f);
        edges[4].transform.eulerAngles = new Vector3(0f, 90f, 0f);
        edges[5].transform.eulerAngles = new Vector3(0f, 90f, -0f);
        
        foreach (var edge in edges)
        {
            edge.SetActive(true);
            edge.transform.localScale = edge.transform.lossyScale;
        }
    }
    public bool isEdgeValid()
    {
        // Debug.Log("angular"+rb.angularVelocity.Equals(Vector3.zero));
        // Debug.Log("velocity"+rb.velocity.Equals(Vector3.zero));
        // Debug.Log("magnitude"+Math.Abs(rb.position.z - (-0.5f)));
        // Debug.Log(rb.angularVelocity.Equals(Vector3.zero) &&
        //           rb.velocity.Equals(Vector3.zero) &&
        //           Math.Abs(rb.position.z - (-0.5f)) < 0.05f);

        return _rb.angularVelocity.Equals(Vector3.zero) &&
               _rb.velocity.Equals(Vector3.zero) &&
               Math.Abs(_rb.position.z - (-0.5f)) < 0.05f;
    }
    public void ThrowDice()
    {
        var torqueRandomX = (Random.Range(0, 40) - 20) * 5 * _rb.mass;
        var torqueRandomY = (Random.Range(0, 40) - 20) * 5 * _rb.mass;
        var torqueRandomZ = (Random.Range(0, 40) - 20) * 5 * _rb.mass;
        //rb.AddForce(new Vector3(0, 0, -Random.Range(3, 6)) * rb.mass, ForceMode.Impulse);
        _rb.AddTorque(new Vector3(torqueRandomX, torqueRandomY, torqueRandomZ), ForceMode.Impulse);
    }
    public GameObject GetTopEdge()
    {
        foreach (var edge in edges)
        {
            if (_topEdge is null)
            {
                _topEdge = edge;
            }
            if (edge.transform.position.z < _topEdge.transform.position.z)
            {
                if (edge != _topEdge)
                {
                    if (OnTopEdgeChange != null)
                    OnTopEdgeChange.Invoke(_topEdge, edge);
                }
                _topEdge = edge;
            }
        }

        return _topEdge;
    }

    public void ChangeEdge(GameObject oldEdge, GameObject newEdge)
    {
        var index = edges.IndexOf(oldEdge);
        oldEdge = edges[index];
        newEdge = Instantiate(newEdge, oldEdge.transform, false);
        newEdge.transform.SetParent(transform, false);
        newEdge.transform.localPosition = oldEdge.transform.localPosition;
        newEdge.transform.localScale = oldEdge.transform.lossyScale;
        newEdge.transform.eulerAngles = oldEdge.transform.eulerAngles;
        Destroy(oldEdge);
        edges[index] = newEdge;
    }
    
    public void SetDiceAtStartPosition()
    {
        _rb.transform.localPosition = new Vector3(0, 0, -3f);
        _rb.constraints = RigidbodyConstraints.FreezePosition;
    }
}