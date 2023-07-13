using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    public GameObject player;
    public GameObject curPlayer;
    public int floor = 1;
    [SerializeField] private string f1End;
    [SerializeField]private List<string> f1_rooms =new List<string>();
    public int floorSize=10;
    private Queue<string> roomsQueue = new Queue<string>();
    public bool roomIsClear = true;
    
    private void GenerateLvlQueue()
    {
        List<string> rooms=new List<string>();
        switch (floor)
        {
            case 1: 
                {
                    rooms = f1_rooms;
                    break; 
                }
        }
       

        for (int i = 0; i < floorSize; i++)
        {
            var room = rooms[Random.Range(0,rooms.Count)];
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
            res = f1End;

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

        if(curPlayer==null)
            curPlayer=Instantiate(player, point.transform.position,Quaternion.identity);
        
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
        DontDestroyOnLoad(curPlayer);
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
