using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 25;
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    private Transform player;
    private AudioSource audioSource;
    private float lastAttackTime = 0f;

    // Assign the AudioClip for attack sound in the Unity Editor
    public AudioClip attackSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (player != null && Time.time - lastAttackTime >= attackCooldown)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        // Check if an attack sound is assigned
        if (attackSound != null && audioSource != null)
        {
            // Play the attack sound
            audioSource.PlayOneShot(attackSound);
        }

        // Deduct health from the player
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(damage);
        }

        // Reset attack cooldown
        lastAttackTime = Time.time;
    }
}
