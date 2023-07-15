using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemiesWave> enemiesWaves;
    private List<Transform> enemySpawnPoints;
    private GameManager _gameManager;

    public List<Edge> edges;

    public Action OnWavesEnd;
    private int _currentWaveIndex = -1;

    private EnemiesWave CurrentWave()
    {
        if (_currentWaveIndex >= 0 && enemiesWaves.Count > _currentWaveIndex)
            return enemiesWaves[_currentWaveIndex];
        return null;
    }

    private void SpawnNextWave()
    {
        _currentWaveIndex++;
        if (_currentWaveIndex < 0 || enemiesWaves.Count <= _currentWaveIndex)
        {
            OnWavesEnd?.Invoke();
            return;
        }

        CurrentWave().spawnPoints = enemySpawnPoints;
        CurrentWave().player = _gameManager.curPlayer.GetComponent<Player>();
        CurrentWave().StartWave();
        CurrentWave().OnEnemiesDead += () => SpawnNextWave();
    }

    private void Start()
    {
        OnWavesEnd += () =>
        {
            if (edges.Count > 0)
            {
                var edge = edges[Random.Range(0, edges.Count)];
                var spawnpoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)];
                Instantiate(edge.edgeItem, spawnpoint.position, spawnpoint.rotation);
            }
        };
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