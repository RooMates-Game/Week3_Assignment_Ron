using UnityEngine;
using UnityEngine.UI;  // Make sure to include this to work with UI components.

public class HealthManager : MonoBehaviour
{
    public Image[] hearts;  // Array to hold the heart images
    private int currentHealth;

    void Start()
    {
        currentHealth = hearts.Length;  // Initialize health to 3 (or however many hearts you have)
        UpdateHeartsUI();
    }

    // Call this function when the ship takes damage
    public void TakeDamage()
    {
        currentHealth--;  // Decrease health by 1
        if (currentHealth < 0) currentHealth = 0;  // Prevent health from going negative
        UpdateHeartsUI();
    }

    // Update the UI to show the current health
    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;  // Show or hide hearts based on health
        }
    }
}
