using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemiesToSpawn;
    [SerializeField] private List<EnemyStats> _enemies;
    [SerializeField] private GameBehaviour _gameBehaviour;

    [SerializeField] private float _spawnInterval = 5f;

    private void Start()
    {
        _enemies = new List<EnemyStats>();
        InvokeRepeating("SpawnEnemy", 0f, _spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (_enemies.Count < numberOfEnemiesToSpawn)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, 1f, transform.position.z);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
            _enemies.Add(enemyStats);
            _gameBehaviour._currentEnemies.Add(enemyStats);
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
