using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // Maximum health
    [SerializeField] private Image[] hearts; // Heart images in the UI
    [SerializeField] private string gameOverScene = "level-game-over"; // Game Over scene name

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize health
        UpdateHearts(); // Update UI on start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Check collision with enemy
        {
            TakeDamage(1); // Reduce health by 1
            Destroy(collision.gameObject); // Destroy the enemy
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(gameOverScene); // Load Game Over scene
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; // Show heart
            }
            else
            {
                hearts[i].enabled = false; // Hide heart
            }
        }
    }
}
