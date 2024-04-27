using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool requireKey;
    public bool reqRed, reqYellow, reqGreen;

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
                }
                else if (reqYellow && other.gameObject.GetComponent<KeyInventory>().hasYellowKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
                else if (reqGreen && other.gameObject.GetComponent<KeyInventory>().hasGreenKey)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
            }
            else
            doorAnim.SetTrigger("DoorIdle");
            
       }
    }
}
