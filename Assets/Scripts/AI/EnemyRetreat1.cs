using UnityEngine;
using UnityEngine.AI;

public class EnemyRetreat : MonoBehaviour
{
    public Transform player; // Referencja do GameObject gracza
    public float safeDistance = 10f; // Bezpieczny dystans, na którym przeciwnik przestaje siê zbli¿aæ
    public float keepDistance = 5f; // Odleg³oœæ, jak¹ przeciwnik trzyma siê od gracza
    public float moveSpeed = 5f; // Szybkoœæ przeciwnika

    private void Update()
    {
        if (PlayerInRange())
        {
            KeepDistance();
        }
    }

    bool PlayerInRange()
    {
        // Sprawdzenie, czy gracz znajduje siê w zasiêgu
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < safeDistance; // Zwraca true, jeœli gracz jest w zasiêgu
    }

    void KeepDistance()
    {
        // Obliczenie kierunku od gracza do przeciwnika
        Vector3 direction = transform.position - player.position;
        direction.Normalize();

        // Obliczenie docelowej pozycji, na któr¹ przeciwnik powinien zmierzaæ
        Vector3 targetPosition = player.position + direction * keepDistance;

        // Poruszanie przeciwnikiem w kierunku docelowej pozycji
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
