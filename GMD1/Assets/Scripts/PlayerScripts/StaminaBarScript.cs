using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{

    public Slider slider;
    
    public void setStamina(float stamina){

        slider.value=stamina;
    }

    public void setMaxStamina(float maxStamina){

        slider.maxValue=maxStamina;
        slider.value=maxStamina;
    }
}
