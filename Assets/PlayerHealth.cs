using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // Maximum health (e.g., 3 hearts)
    private int currentHealth; // Player's current health

    void Start()
    {
        currentHealth = maxHealth; // Set current health to max at the start of the game
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease health by the damage value

        // Update UI (e.g., remove a heart)
        Debug.Log($"Player took {damage} damage! Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("Player health is zero. Game over!");
            SceneManager.LoadScene("level-game-over"); // Load Game Over scene
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Getter method for accessing current health if needed elsewhere
    }
}
