using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private Image[] hearts;  // Reference to your heart UI images
    
    private int currentHealth;

    void Start()
    {
        currentHealth = hearts.Length;  // Start with full health
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();
            
            if (currentHealth <= 0)
            {
                // Load game over scene
                SceneManager.LoadScene("level-game-over");
            }
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentHealth);
        }
    }
}