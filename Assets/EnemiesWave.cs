using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

public class EnemiesWave : MonoBehaviour
{
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] public List<Transform> spawnPoints;
    public Action OnEnemiesDead;
    public void StartWave()
    {
        var i = 0;
        foreach (var enemy in enemies)
        {
            SpawnEnemy(enemy, spawnPoints[i]);
            i++;
        }
    }

    private void SpawnEnemy(Enemy enemy, Transform transform)
    {
        enemy = Instantiate(enemy);
        enemy.transform.position = transform.position;
        enemy.entity.OnDeath += () =>
        {
            enemies.Remove(enemy);
            if (enemies.Count == 0) OnEnemiesDead.Invoke();
        };
    }
}
