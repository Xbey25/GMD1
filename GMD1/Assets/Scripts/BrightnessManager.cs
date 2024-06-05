using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessManager : MonoBehaviour
{
    public static BrightnessManager Instance { get; private set; }

    public Slider BrightnessSlider;
    public PostProcessProfile brightnessProfile;
    private AutoExposure exposure;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            brightnessProfile.TryGetSettings(out exposure);
            float savedBrightness = PlayerPrefs.GetFloat("BrightnessSettings", 1f);
            AdjustBrightness(savedBrightness);

            if (BrightnessSlider != null)
            {
                BrightnessSlider.onValueChanged.AddListener(AdjustBrightness);
                BrightnessSlider.value = savedBrightness;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdjustBrightness(float value)
    {
        if (exposure != null)
        {
            exposure.keyValue.value = value != 0 ? value : 0.05f;
        }
        PlayerPrefs.SetFloat("BrightnessSettings", value);
        PlayerPrefs.Save();
    }
}
