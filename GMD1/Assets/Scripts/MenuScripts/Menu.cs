using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public MenuNav menuNav;

    public void OnPlayButton ()
    {
        //will load second scene, scene index 0 is reserved to menu scene
        SceneManager.LoadScene(1);
        
    }

    public void OnOptionsButton()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        menuNav.enabled = false;

    }

    public void OnQuitButton(){
        Application.Quit();
    }
}
