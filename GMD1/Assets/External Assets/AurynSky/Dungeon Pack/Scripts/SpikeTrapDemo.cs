using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour
{
    public Animator spikeTrapAnim;
    public AudioSource audioSource; // AudioSource component
    public AudioClip openSound; // AudioClip for opening sound
    public AudioClip closeSound; // AudioClip for closing sound

    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Ensure there's an AudioSource component attached
        StopCoroutine(OpenCloseTrap());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is the player
        {
            Debug.Log("Player entered trigger collider.");
            StartCoroutine(OpenCloseTrap());
        }
    }

    IEnumerator OpenCloseTrap()
    {
        // Play open animation and sound
        spikeTrapAnim.SetTrigger("open");
        audioSource.PlayOneShot(openSound); // Play the open sound
        Debug.Log("Playing open animation.");
        yield return new WaitForSeconds(3.0f);

        // Play close animation and sound
        spikeTrapAnim.SetTrigger("close");
        audioSource.PlayOneShot(closeSound); // Play the close sound
        Debug.Log("Playing close animation.");
    }
}
