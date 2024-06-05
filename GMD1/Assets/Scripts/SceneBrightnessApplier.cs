using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SceneBrightnessApplier : MonoBehaviour
{
    public PostProcessProfile brightnessProfile;
    private AutoExposure exposure;

    private void Start()
    {
        brightnessProfile.TryGetSettings(out exposure);
        ApplySavedBrightness();
    }

   private void ApplySavedBrightness()
{
    float savedBrightness = PlayerPrefs.GetFloat("BrightnessSettings", 1f);
    Debug.Log("Applying saved brightness: " + savedBrightness);
    if (exposure != null)
    {
        exposure.keyValue.value = savedBrightness != 0 ? savedBrightness : 0.05f;
    }
    else
    {
        Debug.LogWarning("Exposure is null!");
    }
}

}
