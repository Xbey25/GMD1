using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Options : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public MenuNav menuNav;
  

    public void OnBackButton()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        menuNav.enabled = true;
    }
   

}
