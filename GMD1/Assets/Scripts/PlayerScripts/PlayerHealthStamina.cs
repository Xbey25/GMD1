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

        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUI();

        if (currentHealth <= 0)
        {
            // Handle player death
        }
    }

    public void UpdateUI()
    {
        healthSlider.value = currentHealth;
        staminaSlider.value = currentStamina;
    }
}
