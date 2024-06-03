using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jumpscare : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioSource jumpscareSound; 
    public float displayDuration = 1.5f; // Duration to display the jumpscare


    private void Start()
    {
        jumpscareImage.enabled = false;
        jumpscareSound.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area.");
            StartCoroutine(DisplayJumpscare());
            jumpscareImage.enabled = true;
            jumpscareSound.enabled = true;
        }
    }

    private IEnumerator DisplayJumpscare()
    {
        Debug.Log("Jumpscare started.");
        jumpscareSound.Play();

        yield return new WaitForSeconds(displayDuration);

        jumpscareImage.enabled = false;
        jumpscareSound.Stop();

        Debug.Log("Jumpscare ended. Disabling GameObject.");
        gameObject.SetActive(false);
    }
}
