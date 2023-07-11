using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;
using UnityEditor;
using System.Linq;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    public GameObject player;

    public int floor = 1;
    [SerializeField]private List<SceneAsset> f1_rooms=new List<SceneAsset>();
    public int floorSize=10;
    private Queue<string> roomsQueue = new Queue<string>();
    public bool roomIsClear = true;

    private void GenerateLvlQueue()
    {
        List<SceneAsset> rooms=new List<SceneAsset>();
        switch (floor)
        {
            case 1: 
                {
                    rooms = f1_rooms;
                    break; 
                }
        }
        var random = new Unity.Mathematics.Random(1);

        for (int i = 0; i < floorSize; i++)
        {
            var room = rooms[random.NextInt(rooms.Count)].name;
            roomsQueue.Enqueue(room);
            Debug.Log(room);
        }
    }
    public string GetNextRoom()
    {
        string res;
        if (roomsQueue.Count > 0)
            res = roomsQueue.Dequeue();
        else
            res = null;

        return res;
    }

    public void NextRoom()
    {
        var nextSceneName = GetNextRoom();
        if (nextSceneName != null)
        {
            Debug.Log(nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
    private void PlayerPosition()
    {
        var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var gate=point.GetComponentInParent<GateController>();
        if (gate != null)
        {
            gate.enterGate = true;
        }
        Instantiate(player, point.transform.position,Quaternion.identity);
    }

    void Awake()
    {
        PlayerPosition();
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        GenerateLvlQueue();
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            roomIsClear = false;
        else
            roomIsClear = true;

    }
}
