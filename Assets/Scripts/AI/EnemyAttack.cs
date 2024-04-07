using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackRate = 1f;
    public float attackRange = 2f;
    private float nextAttackTime = 0f;
    public Transform player; // Zmieniamy typ na publiczne pole, aby mo¿na by³o przypisaæ obiekt gracza w edytorze Unity

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) // Dodajemy sprawdzenie, czy obiekt gracza zosta³ przypisany
        {
            Debug.LogWarning("Player reference not set in EnemyAttack script!"); // Wypisujemy ostrze¿enie, ¿e obiekt gracza nie zosta³ przypisany
            return;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("-10");
        }
    }
}
