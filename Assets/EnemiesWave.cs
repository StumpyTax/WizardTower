using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

public class EnemiesWave : MonoBehaviour
{
    public Player player;
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] public List<Transform> spawnPoints;
    public Action OnEnemiesDead;
    public void StartWave()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i] = SpawnEnemy(enemies[i], spawnPoints[i]);
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
