using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private EnemyStats _enemyStats;
    public List<EnemyStats> _currentEnemies;
    void Start()
    {
        _currentEnemies = new List<EnemyStats>();
        _enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
    }

    void Update()
    {

    }
}
