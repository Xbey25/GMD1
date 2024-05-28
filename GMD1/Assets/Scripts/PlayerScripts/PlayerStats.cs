using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
         // Maybe set death screen or print message
        
         SceneManager.LoadScene("GameOver");
         Debug.Log("Player died.");
    }
}

