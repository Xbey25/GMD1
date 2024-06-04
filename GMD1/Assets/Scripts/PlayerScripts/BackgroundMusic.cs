using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; // Reference to the background music clip
    private AudioSource audioSource;

    void Awake()
    {
        // Ensure only one instance of the BackgroundMusicPlayer exists
        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Persist this GameObject across scenes
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Ensure the music loops
            audioSource.playOnAwake = true; // Play the music as soon as the game starts
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned.");
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }
}
