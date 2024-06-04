using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float maxStamina = 100f; 
    public float currentStamina;

    public Slider healthSlider;
    public Slider staminaSlider;

    public HealthBarScript healthBar;
    public StaminaBarScript staminaBar;

    public EndMenuNav endmenunav;
    public EndMenuNav wonmenunav;

    public Canvas endScreen;
    public Canvas wonScreen;

    void Start()
    {
        if (endScreen != null && wonScreen != null)
        {
            endScreen.enabled = false;
            endmenunav.StopMovement();
            wonScreen.enabled = false;
            wonmenunav.StopMovement();
        }
        else
        {
            Debug.LogError("Canvas is not assigned!");
        }
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        healthBar.setMaxHealth(maxHealth);
        staminaBar.setMaxStamina(maxStamina);
    }

    public void AdjustHealth(float amount) // do not change to int, float works somehow
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AdjustStamina(float amount) // do not change to int, float works somehow
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        staminaBar.setStamina(currentStamina);
    }

    void Die() // TODO: Remove, we dont have health anymore
    {
        Debug.Log("Player died.");
    }
}