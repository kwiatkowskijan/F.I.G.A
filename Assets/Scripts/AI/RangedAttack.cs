using UnityEngine;
using UnityEngine.AI;

public class RangedAttack : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField] private float timer = 5f;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Ensure the player reference is not null
        if (player == null)
            return;

        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        // Calculate the direction towards the player
        Vector3 direction = (player.position - spawnPoint.position).normalized;

        // Instantiate the bullet facing towards the player
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, Quaternion.LookRotation(direction)) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.velocity = direction * enemySpeed; // Set the velocity instead of adding force
        Destroy(bulletObj, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
