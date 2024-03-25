using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioSource audioSource;
    public float footstepInterval = 0.5f; // Time interval between footstep sounds

    private bool isMoving;
    private float footstepTimer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        footstepTimer = footstepInterval;
    }

    private void Update()
    {
        // Check if the player is moving
        bool wasMoving = isMoving;
        isMoving = IsPlayerMoving();

        // Start or stop footstep sounds based on player movement
        if (isMoving && !wasMoving)
        {
            footstepTimer = 0f; // Start footstep timer
            PlayFootstepSound();
        }
        else if (!isMoving && wasMoving)
        {
            audioSource.Stop(); // Stop footstep sound if player stops moving
        }

        // Update footstep timer
        if (isMoving)
        {
            footstepTimer += Time.deltaTime;

            if (footstepTimer >= footstepInterval)
            {
                footstepTimer -= footstepInterval;
                PlayFootstepSound();
            }
        }
    }

    private bool IsPlayerMoving()
    {
        // Check if the player is moving based on input
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private void PlayFootstepSound()
    {
        // Stop the current footstep sound
        audioSource.Stop();

        // Play a random footstep sound from the array
        if (footstepSounds.Length > 0)
        {
            AudioClip footstepClip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
