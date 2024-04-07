using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public Transform player;
    public float runSpeed = 5f;

    private void Update()
    {
        if (PlayerInRange())
        {
            RunAway();
        }
    }

    bool PlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < 10f;
    }

    void RunAway()
    {
        Vector3 direction = transform.position - player.position;
        direction.Normalize();

        transform.Translate(direction * runSpeed * Time.deltaTime);
    }
}
