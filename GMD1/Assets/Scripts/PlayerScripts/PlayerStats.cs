using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxStamina = 100;
    public int currentStamina;

  
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
     

        Debug.Log("Player died.");
    }
}
