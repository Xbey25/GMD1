using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessPostProcessing : MonoBehaviour
{   
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    AutoExposure exposure;

     void Awake() {
        brightness.TryGetSettings(out exposure);
         AdjustBrightness();
    }

    public void AdjustBrightness()
    {
        if(PlayerPrefs.GetFloat("BrightnessSettings")!=0)
        {
            exposure.keyValue.value = PlayerPrefs.GetFloat("BrightnessSettings");
        }else
        {
            exposure.keyValue.value = .05f;
        }
    }
}
