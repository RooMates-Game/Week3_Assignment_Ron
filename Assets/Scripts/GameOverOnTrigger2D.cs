using UnityEngine;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] private string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && enabled)
        {
            if (other.CompareTag("Player")) // If the player is involved in the collision
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    // Use the health system instead of directly quitting the game
                    playerHealth.TakeDamage(1);
                }
            }
        }
    }
}
