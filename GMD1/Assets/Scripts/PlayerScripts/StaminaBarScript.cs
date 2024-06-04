using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    
    public void setStamina(int stamina){

        slider.value=stamina;
    }

    public void setMaxStamina(int maxStamina){

        slider.maxValue=maxStamina;
        slider.value=maxStamina;
    }
}
