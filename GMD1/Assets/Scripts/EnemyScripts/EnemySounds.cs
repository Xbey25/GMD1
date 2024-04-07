using UnityEngine;

public class EnemyRandomSounds : MonoBehaviour
{
    public AudioClip[] randomSounds;
    public float minInterval = 5f;
    public float maxInterval = 15f;

    private AudioSource audioSource;
    private float nextSoundTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetNextSoundTime();
    }

    void Update()
    {
        if (Time.time >= nextSoundTime)
        {
            PlayRandomSound();
            SetNextSoundTime();
        }
    }

    void SetNextSoundTime()
    {
        nextSoundTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    void PlayRandomSound()
    {
        if (randomSounds.Length == 0 || audioSource == null)
            return;

        AudioClip randomClip = randomSounds[Random.Range(0, randomSounds.Length)];
        audioSource.PlayOneShot(randomClip);
    }
}
