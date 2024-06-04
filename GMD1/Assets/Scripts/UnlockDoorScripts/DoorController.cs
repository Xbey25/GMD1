using UnityEngine;

public class DoorEnemyActivator : MonoBehaviour
{
    public Animator doorAnim; // Assign the door's Animator component in the Inspector
    public GameObject enemy; // Assign the enemy GameObject in the Inspector

    private bool enemyEnabled = false; // Track whether the enemy has been enabled

    void Start()
    {
        if (enemy != null)
        {
            enemy.SetActive(false); // Ensure the enemy is initially disabled
        }
        else
        {
            Debug.LogError("Enemy GameObject is not assigned!");
        }

        if (doorAnim == null)
        {
            Debug.LogError("Door Animator is not assigned!");
        }
    }

    void Update()
    {
        if (doorAnim != null && enemy != null)
        {
            // Get the current animation state
            AnimatorStateInfo stateInfo = doorAnim.GetCurrentAnimatorStateInfo(0);

            // Check if the current state is the "isOpen" state
            if (stateInfo.IsName("DoorOpen") && !enemyEnabled)
            {
                Debug.Log("Door is in 'isOpen' state, enabling enemy.");
                enemy.SetActive(true); // Enable the enemy GameObject when the door is open
                enemyEnabled = true; // Set the flag to avoid enabling the enemy again
            }
        }
    }
}
