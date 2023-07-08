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
    public GameObject topEdge;

    private Rigidbody _diceRb;
    private DiceScript _diceScript;

    public void Awake()
    {
        dice = Instantiate(dice, gameObject.transform, true);

        camera = Instantiate(camera, gameObject.transform, true);
        camera.GetComponent<CameraTrack>().trackedO = dice;

        _diceRb = dice.GetComponent<Rigidbody>();
        _diceScript = dice.GetComponent<DiceScript>();
    }

    public void Start()
    {
        _diceRb = dice.GetComponent<Rigidbody>();
        SetDiceAtStartPosition();
    }

    public void ThrowDice()
    {
        topEdge = null;
        SetDiceAtStartPosition();
        _diceRb.constraints = RigidbodyConstraints.FreezePosition;
        _diceScript.ThrowDice();
        _diceRb.constraints = RigidbodyConstraints.None;
    }

    public bool isEdgeValid()
    {
        bool result = _diceScript.isEdgeValid();
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
    private void SetDiceAtStartPosition()
    {
        _diceRb.transform.localPosition = new Vector3(0, 0, -3f);
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