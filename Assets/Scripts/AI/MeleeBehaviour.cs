using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float runSpeed = 5f; // Speed at which the enemy runs away

    private void Update()
    {
        if (PlayerInRange())
        {
            RunAway();
        }
    }

    bool PlayerInRange()
    {
        // Check if the player is within a certain range from the enemy
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < 10f; // Change 10f to the desired range
    }

    void RunAway()
    {
        // Calculate direction away from the player
        Vector3 direction = transform.position - player.position;
        direction.Normalize();

        // Move the enemy in the calculated direction
        transform.Translate(direction * runSpeed * Time.deltaTime);
    }
}
