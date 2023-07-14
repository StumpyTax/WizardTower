using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesWave : MonoBehaviour
{
    public Player player;
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] public List<Transform> spawnPoints;
    [SerializeField] private List<Transform> _spawnPoints;
    public Action OnEnemiesDead;
    public void StartWave()
    {
        _spawnPoints = new List<Transform>(spawnPoints);
        for (int i = 0; i < enemies.Count; i++)
        {
            if (i >= spawnPoints.Count) return;
            var randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            enemies[i] = SpawnEnemy(enemies[i], randomSpawnPoint);
            _spawnPoints.Remove(randomSpawnPoint);
        }

        player.caster.enemies = enemies.Select(x => x.entity).ToList();
    }

    private Enemy SpawnEnemy(Enemy enemy, Transform transform)
    {
        enemy = Instantiate(enemy);
        enemy.transform.position = transform.position;
        enemy.Start();
        enemy.player = player;
        enemy.entity.OnDeath += () =>
        {
            enemies.Remove(enemy);
            if (enemies.Count == 0) OnEnemiesDead.Invoke();
        };
        return enemy;
    }
}
