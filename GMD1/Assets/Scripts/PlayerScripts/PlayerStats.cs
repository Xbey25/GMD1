using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxStamina = 100;
    public int currentStamina;

    public Camera secondCamera;
    public Slider healthSlider;
    public Slider staminaSlider;

    public HealthBarScript healthBar;

    public StaminaBarScript staminaBar;

    public Canvas endScreen;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        healthBar.setMaxHealth(maxHealth);
        staminaBar.setMaxStamina(maxStamina);
    }

    public void AdjustHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AdjustStamina(int amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

    }


    void Die()
    {
        endScreen.enabled = true;
        secondCamera.enabled = true;

        Debug.Log("Player died.");
    }
}
