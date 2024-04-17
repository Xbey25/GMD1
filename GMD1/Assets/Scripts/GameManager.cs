using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float brightnessValue = .05f; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBrightness(float value)
    {
        brightnessValue = value;
    }

    public float GetBrightness()
    {
        return brightnessValue;
    }
}
