using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Tooltip("Heart UI Images representing player's health. Must be assigned in the Inspector.")]
    [SerializeField]
    private Image[] hearts;  // Array to hold the heart images

    private int currentHealth;  // Tracks the current health

    void Start()
    {
        // Initialize current health to the number of heart images
        currentHealth = hearts.Length;
        UpdateHeartsUI();
    }

    // Call this function to reduce health by one
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;  // Reduce health
            UpdateHeartsUI(); // Update the heart images visibility
        }

        if (currentHealth <= 0)
        {
            HandleGameOver(); // Trigger game-over logic when all hearts are gone
        }
    }

    // Updates the visibility of the heart images
    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;  // Disable hearts one by one as health decreases
        }
    }

    // Handles the game-over scenario
    private void HandleGameOver()
    {
        Debug.Log("Game Over!");  // Placeholder for game-over logic
        // Add your game-over functionality here (e.g., load game-over scene)
    }
}
