using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceThrowScript : MonoBehaviour
{
    public GameObject dice;
    public GameObject camera;

    private Rigidbody _diceRb;
    private DiceScript _diceScript;

    public void Awake()
    {
        dice = Instantiate(dice);
        dice.transform.parent = gameObject.transform;
        dice.transform.position = Vector3.zero;

        camera = Instantiate(camera);
        camera.GetComponent<CameraTrack>().trackedO = dice;

        _diceRb = dice.GetComponent<Rigidbody>();
        _diceRb.constraints = RigidbodyConstraints.FreezePosition;
        _diceScript = dice.GetComponent<DiceScript>();
    }

    public void Start()
    {
        _diceRb = dice.GetComponent<Rigidbody>();
    }

    public void ThrowDice()
    {
        _diceScript.ThrowDice();
    }

    public IEnumerator RollCoroutine()
    {
        float timeForStop = 2f;
        RollDice();
        var vector = _diceRb.angularVelocity;
        var k = vector / timeForStop;
        for (float t = timeForStop; t > 0; t -= Time.deltaTime)
        {
            _diceRb.angularVelocity = t * k;
            yield return null;
        }
        _diceRb.angularVelocity = Vector3.zero;
    }

    private void RollDice()
    {
        var torqueRandomX = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        var torqueRandomY = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        var torqueRandomZ = Random.Range(-_diceRb.maxAngularVelocity, _diceRb.maxAngularVelocity);
        _diceRb.angularVelocity = new Vector3(torqueRandomX, torqueRandomY, torqueRandomZ);
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