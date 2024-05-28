using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GOMenuScript : MonoBehaviour

{
    public void OnContinueButton ()
    {
        //will load second scene, scene index 0 is reserved to menu scene
        SceneManager.LoadScene("Menu");
        
    }

    public void OnQuitButton(){
        Application.Quit();
    }
}

