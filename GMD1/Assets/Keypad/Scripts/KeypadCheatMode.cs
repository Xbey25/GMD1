using UnityEngine;
using UnityEngine.Events;


    [System.Serializable]
    public class KeypadCheatModeEvent : UnityEvent { }

    public class KeypadCheatMode : MonoBehaviour
    {
        public GameObject redDoor; // Reference to the RedDoor object
        public KeypadCheatModeEvent onCheatModeActivated; // Unity event for cheat mode activation

        public void ActivateCheatMode()
        {
            if (redDoor != null)
            {
                // Disable the DoorController component within the RedDoor object
                DoorEnemyActivator doorController = redDoor.GetComponent<DoorEnemyActivator>();
                if (doorController != null)
                {
                    doorController.enabled = false;
                    Debug.Log("Cheat mode activated: DoorController disabled.");
                }
                else
                {
                    Debug.LogError("DoorController component not found in RedDoor object.");
                }
            }
            else
            {
                Debug.LogError("RedDoor object reference is null.");
            }

            // Invoke the cheat mode activated event
            onCheatModeActivated.Invoke();
        }
    }

