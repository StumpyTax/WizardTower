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
        DontDestroyOnLoad(gameObject);

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
        return result;
    }
        
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
}