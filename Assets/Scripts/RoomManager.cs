using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemiesWave> enemiesWaves;
    private List<Transform> enemySpawnPoints;
    private GameManager _gameManager;


    public Action OnWavesEnd;
    private int _currentWaveIndex = -1;

    private EnemiesWave CurrentWave()
    {
        return enemiesWaves[_currentWaveIndex];
    }

    private void SpawnNextWave()
    {
        _currentWaveIndex++;
        if (_currentWaveIndex < 0 && enemiesWaves.Count <= _currentWaveIndex)
        {
            OnWavesEnd.Invoke();
            return;
        }

        CurrentWave().spawnPoints = enemySpawnPoints;
        CurrentWave().player = _gameManager.curPlayer.GetComponent<Player>();
        CurrentWave().StartWave();
        CurrentWave().OnEnemiesDead += () => SpawnNextWave();
    }

    private void Start()
    {
        _gameManager = GameManager.instance;
        enemySpawnPoints = new List<Transform>();
        for (var i = 0; i < transform.childCount; i++)
        {
            var children = transform.GetChild(i);
            if (children.tag == "SpawnPoint Enemy") this.enemySpawnPoints.Add(children);
        }
        SpawnNextWave();
    }
}