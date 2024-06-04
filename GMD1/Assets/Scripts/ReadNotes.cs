using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadNotes : MonoBehaviour
{
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;

    public GameObject note1UI;
    public GameObject note2UI;
    public GameObject note3UI;
    public GameObject note4UI;
    
    private PlayerControls inputActions;
    private bool noteUIOpen = false;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Player.PickUp.started += OnPickUpStarted;
        inputActions.Player.PickUp.canceled += OnPickUpCanceled;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Start()
    {
        CloseAllNotes();
    }

    private void OnInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Note"))
            {
                ToggleNoteState(hitObject);
            }
            else if (noteUIOpen)
            {
                CloseAllNotes();
            }
        }
        else if (noteUIOpen)
        {
            CloseAllNotes();
        }
    }

    private void ToggleNoteState(GameObject obj)
    {
        if (obj == note1)
        {
            ToggleNoteUI(note1UI, note1);
        }
        else if (obj == note2)
        {
            ToggleNoteUI(note2UI, note2);
        }
        else if (obj == note3)
        {
            ToggleNoteUI(note3UI, note3);
        }
        else if (obj == note4)
        {
            ToggleNoteUI(note4UI, note4);
        }
    }

    private void ToggleNoteUI(GameObject noteUI, GameObject note)
    {
        if (!noteUI.activeSelf)
        {
            CloseAllNotes();
            noteUI.SetActive(true);
            note.SetActive(false);
            noteUIOpen = true;
        }
    }

    private void CloseAllNotes()
    {
        note1UI.SetActive(false);
        note2UI.SetActive(false);
        note3UI.SetActive(false);
        note4UI.SetActive(false);

        note1.SetActive(true);
        note2.SetActive(true);
        note3.SetActive(true);
        note4.SetActive(true);

        noteUIOpen = false;
    }

    private void OnPickUpStarted(InputAction.CallbackContext context)
    {
        StartCoroutine(LongClickRoutine());
    }

    private void OnPickUpCanceled(InputAction.CallbackContext context)
    {
        StopAllCoroutines();
    }

    private IEnumerator LongClickRoutine()
    {
        yield return new WaitForSeconds(0.2f); // Adjust this value to determine the long click duration
        OnInteract();
    }
}
