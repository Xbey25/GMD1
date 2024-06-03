using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jumpscare : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioSource jumpscareSound; 
    public float displayDuration = 1.5f; // Duration to display the jumpscare

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area.");
            StartCoroutine(DisplayJumpscare());
        }
    }

    private IEnumerator DisplayJumpscare()
    {
        Debug.Log("Jumpscare started.");
        jumpscareImage.enabled = true;
        jumpscareSound.enabled = true;
        jumpscareSound.Play();

        yield return new WaitForSeconds(displayDuration);

        jumpscareImage.enabled = false;
        jumpscareSound.Stop();

        Debug.Log("Jumpscare ended. Disabling GameObject.");
        gameObject.SetActive(false);
    }
}
