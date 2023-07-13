using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceThrowScript : MonoBehaviour
{
    public GameObject dice;
    public GameObject camera;

    public GameObject topEdge()
    {
        return _dice.GetTopEdge();
    }

    private Rigidbody _diceRb;
    private Dice _dice;

    public void Awake()
    {
        dice = Instantiate(dice, gameObject.transform, true);

        camera = Instantiate(camera, gameObject.transform, true);
        camera.GetComponent<CameraTrack>().trackedO = dice;

        _diceRb = dice.GetComponent<Rigidbody>();
        _dice = dice.GetComponent<Dice>();
    }

    public void Start()
    {
        _diceRb = dice.GetComponent<Rigidbody>();
        SetDiceAtStartPosition();
    }

    public void ThrowDice()
    {
        SetDiceAtStartPosition();
        _dice.ThrowDice();
        _diceRb.constraints = RigidbodyConstraints.None;
    }
    public bool isEdgeValid()
    {
        bool result = _dice.isEdgeValid();
        // IEnumerator ExampleCoroutine()
        // {
        //     yield return new WaitForSecondsRealtime(0.5f);
        //     result = _diceScript.isEdgeValid();
        //     Debug.Log("result in routin" + result);
        // }
        //
        // StartCoroutine(ExampleCoroutine());
        // Debug.Log(result);
        return result;
    }
        // public IEnumerator WaitDiceStop()
        // {
        //     while (!_diceScript.isEdgeValid())
        //     {
        //         yield return null;
        //     }
        //
        //     topEdge = _diceScript.GetTopEdge();
        // }
        
    private void RollDice()
    {
        var torqueRandomX = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        var torqueRandomY = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        var torqueRandomZ = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        _diceRb.angularVelocity = new Vector3(torqueRandomX, torqueRandomY, torqueRandomZ);
    }
    public void SetDiceAtStartPosition()
    {
        _diceRb.transform.localPosition = new Vector3(0, 0, -3f);
        _diceRb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void Friction(float frictionForce)
    {
        _diceRb.angularVelocity = _diceRb.angularVelocity - (_diceRb.angularVelocity * frictionForce);
    }
    
    private void Friction(Vector3 frictionForce)
    {
        _diceRb.angularVelocity = _diceRb.angularVelocity - frictionForce;
    }
}