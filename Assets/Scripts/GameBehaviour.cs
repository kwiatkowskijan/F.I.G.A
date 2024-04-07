using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private EnemyStats _enemyStats;
    public List<EnemyStats> _currentEnemies;
    [SerializeField] private HUD hud;

    private int _health = 100;

    public int health
    {
        get { return _health; }

        set { _health = value; }
    }
    void Start()
    {
        _currentEnemies = new List<EnemyStats>();
        _enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        hud.UpdateHealthUI(_health);
    }

    private void Die()
    {
        SceneManager.LoadScene("Jan");
    }
}
