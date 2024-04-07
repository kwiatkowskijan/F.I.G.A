using UnityEngine;
using UnityEngine.AI;

public class EnemyRetreat : MonoBehaviour
{
    public Transform player; // Referencja do GameObject gracza
    public float safeDistance = 10f; // Bezpieczny dystans, na kt�rym przeciwnik przestaje si� zbli�a�
    public float keepDistance = 5f; // Odleg�o��, jak� przeciwnik trzyma si� od gracza
    public float moveSpeed = 5f; // Szybko�� przeciwnika

    private void Update()
    {
        if (PlayerInRange())
        {
            KeepDistance();
        }
    }

    bool PlayerInRange()
    {
        // Sprawdzenie, czy gracz znajduje si� w zasi�gu
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < safeDistance; // Zwraca true, je�li gracz jest w zasi�gu
    }

    void KeepDistance()
    {
        // Obliczenie kierunku od gracza do przeciwnika
        Vector3 direction = transform.position - player.position;
        direction.Normalize();

        // Obliczenie docelowej pozycji, na kt�r� przeciwnik powinien zmierza�
        Vector3 targetPosition = player.position + direction * keepDistance;

        // Poruszanie przeciwnikiem w kierunku docelowej pozycji
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
