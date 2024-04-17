using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LevelController : MonoBehaviour
{
    public PostProcessProfile brightness;
    AutoExposure exposure;

    void Start()
    {
        // Retrieve the brightness value from PlayerPrefs set in the menu scene
        float savedBrightness = PlayerPrefs.GetFloat("BrightnessValue", 1f);
        
        // Try to get the exposure settings from the PostProcessProfile
        if (brightness != null)
        {
            brightness.TryGetSettings(out exposure);

            // Adjust the brightness using the retrieved value
            AdjustBrightness(savedBrightness);
        }
        else
        {
            Debug.LogError("PostProcessProfile for brightness not assigned in the inspector!");
        }
    }

    public void AdjustBrightness(float value)
    {
        // Ensure that exposure settings are available
        if (exposure != null)
        {
            // Adjust the exposure key value to control brightness
            exposure.keyValue.value = value;
        }
        else
        {
            Debug.LogError("AutoExposure settings not found in PostProcessProfile!");
        }
    }
}
