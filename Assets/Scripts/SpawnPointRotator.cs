using UnityEngine;

public class SpawnPointRotator : MonoBehaviour
{
    public Transform player; // Referencja do gracza

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Referencja do gracza nie zosta³a ustawiona.");
            return;
        }

        // Oblicz kierunek do gracza
        Vector3 directionToPlayer = player.position - transform.position;

        // Ustaw kierunek dla spawnPointa
        transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
    }
}