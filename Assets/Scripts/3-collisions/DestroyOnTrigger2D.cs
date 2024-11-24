// using UnityEngine;

// public class DestroyOnTrigger2D : MonoBehaviour
// {
//     [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
//     [SerializeField] string triggeringTag;

//     private HealthManager healthManager;  // Reference to the HealthManager

//     private void Start()
//     {
//         // Find the HealthManager in the scene
//         healthManager = FindObjectOfType<HealthManager>();
//         if (healthManager == null)
//         {
//             Debug.LogError("HealthManager not found in the scene!");
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.tag == triggeringTag && enabled)
//         {
//             // Notify HealthManager to reduce health
//             healthManager?.TakeDamage();

//             // Destroy the enemy object
//             Destroy(other.gameObject);
//         }
//     }
// }



using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private HealthManager healthManager;  // Reference to the HealthManager

    private void Start()
    {
        // Find the HealthManager in the scene
        healthManager = FindObjectOfType<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogError("HealthManager not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only handle collisions with enemies and not UI or health point images
        if (other.CompareTag("Enemy") && this.CompareTag("Player")) // If the player collides with an enemy
        {
            healthManager?.TakeDamage(); // Notify the HealthManager to reduce health
            Destroy(other.gameObject);   // Destroy the enemy
        }
        else if (other.CompareTag("Laser") && this.CompareTag("Enemy")) // If the laser hits an enemy
        {
            Destroy(other.gameObject); // Destroy the laser
            Destroy(this.gameObject);  // Destroy the enemy
        }
    }
}

