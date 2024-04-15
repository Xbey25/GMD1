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

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

       
    }

    public void TakeDamage(int damage)
    {
        // Deduct damage from health
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update UI for health
        UpdateHealthUI();

        // Check if player is alive
        if (currentHealth <= 0)
        {
            // Handle player death
            Die();
        }
    }

    public void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
    }

    public void UpdateStaminaUI()
    {
        staminaSlider.value = currentStamina;
    }

    void Die()
    {
        //TODO: create death screen
        Debug.Log("Player died!");
    }
}
