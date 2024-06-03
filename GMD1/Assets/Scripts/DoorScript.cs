using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public bool requireKey;
    public bool reqRed, reqYellow, reqGreen;

    public Image redKeyUI;
    public Image greenKeyUI;
    public Image yellowKeyUI;
  
    public Animator doorAnim;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.tag == "Player")
        {


            if (requireKey)
            {
                if (reqRed && other.gameObject.GetComponent<KeyInventory>().hasRedKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    redKeyUI.enabled = false;

                }
                else if (reqYellow && other.gameObject.GetComponent<KeyInventory>().hasYellowKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    yellowKeyUI.enabled = false;
                }
                else if (reqGreen && other.gameObject.GetComponent<KeyInventory>().hasGreenKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    greenKeyUI.enabled = false;
                }
            }
            else
            doorAnim.SetTrigger("DoorIdle");
            
       }
    }
}
