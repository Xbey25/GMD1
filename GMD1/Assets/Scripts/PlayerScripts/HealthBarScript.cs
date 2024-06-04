using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    public void setHealth(float health){

        slider.value=health;
    }

    public void setMaxHealth(float maxHealth){

        slider.maxValue=maxHealth;
        slider.value=maxHealth;
    }
}
