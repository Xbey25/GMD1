using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadNotes : MonoBehaviour
{
    public List<GameObject> notes;
    public List<GameObject> noteUIs;

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
        for (int i = 0; i < notes.Count; i++)
        {
            if (obj == notes[i])
            {
                ToggleNoteUI(noteUIs[i], notes[i]);
                break;
            }
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
        for (int i = 0; i < noteUIs.Count; i++)
        {
            noteUIs[i].SetActive(false);
            notes[i].SetActive(true);
        }

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
