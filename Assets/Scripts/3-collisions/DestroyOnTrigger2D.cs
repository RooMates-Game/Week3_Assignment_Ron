// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// /**
//  * This component destroys its object whenever it triggers a 2D collider with the given tag.
//  */
// public class DestroyOnTrigger2D : MonoBehaviour {
//     [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
//     [SerializeField] string triggeringTag;

//     private void OnTriggerEnter2D(Collider2D other) {
//         if (other.tag == triggeringTag && enabled) {
//             Destroy(this.gameObject);
//             Destroy(other.gameObject);
//         }
//     }

//     private void Update() {
//         /* Just to show the enabled checkbox in Editor */
//     }
// }

using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger destruction of this object")]
    [SerializeField] private string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && enabled)
        {
            if (other.CompareTag("Player")) // If the collided object is the Player
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1); // Reduce the player's health
                }
            }
            else
            {
                Destroy(other.gameObject); // Destroy other object (e.g., laser)
            }

            Destroy(this.gameObject); // Destroy this enemy
        }
    }
}
