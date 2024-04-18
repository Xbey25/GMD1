using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float attackDistance = 2f; // Distance at which the enemy attacks the player
    public AudioClip attackSound; // Sound to play when the attack commences
    public GameObject[] respawnPoints; // Array of respawn points for the enemy
    private bool isAttacking = false;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the enemy is not currently attacking and the player is within attack distance
        if (!isAttacking && Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            // Start the attack
            StartAttack();
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        // Play attack sound
        AudioSource.PlayClipAtPoint(attackSound, transform.position);

        // Deduct 35 HP from the player
        player.GetComponent<PlayerStats>().AdjustHealth(-35);

        // Respawn the enemy at another spawning point
        RespawnEnemy();
    }

    void RespawnEnemy()
    {
        // Select a random respawn point
        Transform respawnPoint = respawnPoints[Random.Range(0, respawnPoints.Length)].transform;
        // Move the enemy to the respawn point
        transform.position = respawnPoint.position;
        // Reset attacking state
        isAttacking = false;
    }
}
