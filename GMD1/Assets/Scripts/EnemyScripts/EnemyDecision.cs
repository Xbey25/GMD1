using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float detectionRange = 10f; // Range within which the enemy can detect the player
    public float observationTime = 10f; // Time the enemy observes the player before making a decision
    private float observationTimer = 0f;
    private bool isObserving = false;
    private bool isStalking = false;

    void Update()
    {
        if (!isObserving)
        {
            // Check if the player is within the detection range
            if (Vector3.Distance(transform.position, player.position) <= detectionRange)
            {
                // Player detected, start observing
                isObserving = true;
                observationTimer = observationTime;
            }
        }
        else
        {
            // Decrement observation timer
            observationTimer -= Time.deltaTime;

            // If observation time is over, call make decision for random
            if (observationTimer <= 0f)
            {
                MakeDecision();
            }
        }
    }

    void MakeDecision()
    {
        // Generate a random number between 1 and 10
        int randomNumber = Random.Range(1, 11);

        if (randomNumber <= 6)
        {
            // Continue stalking behavior
            isStalking = true;
            Debug.Log("Continuing stalking behavior...");
        }
        else
        {
            // Enter attack mode
            isStalking = false;
            Debug.Log("Entering attack mode...");
            // pending attack logic, maybe sound?
            Attack();
        }

        // Reset observation variables
        isObserving = false;
        observationTimer = 0f;
    }

    void Attack()
    {
        // attack bhv
        Debug.Log("Enemy attacking player...");
    }
}
