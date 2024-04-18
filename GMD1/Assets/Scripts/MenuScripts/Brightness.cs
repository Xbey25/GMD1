using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class Brightness : MonoBehaviour
{
    public Slider BrightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    AutoExposure exposure;
    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(BrightnessSlider.value);
    }

    public void AdjustBrightness(float value)
    {
        if(value!=0)
        {
            exposure.keyValue.value = value;
        }else
        {
            exposure.keyValue.value = .05f;
        }
    }

}










// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Rendering.PostProcessing;

// public class Brightness : MonoBehaviour
// {
//     public Slider BrightnessSlider;
//     public PostProcessProfile brightness;
//     AutoExposure exposure;

//     void Start()
//     {
//         brightness.TryGetSettings(out exposure);
//         float savedBrightness = PlayerPrefs.GetFloat("BrightnessValue", 1f);
//         AdjustBrightness(savedBrightness);
//         DontDestroyOnLoad(gameObject);
//     }

//     public void AdjustBrightness(float value)
//     {
//         if (exposure != null)
//         {
//             exposure.keyValue.value = value;
//         }
//         PlayerPrefs.SetFloat("BrightnessValue", value);
//         PlayerPrefs.Save();

//     }
// }
