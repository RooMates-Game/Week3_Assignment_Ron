<<<<<<< HEAD
<<<<<<< HEAD
﻿public class DestroyOnTrigger2D : MonoBehaviour {

private HealthManager healthManager;

    void Start()
    {
        // Find the HealthManager in the scene
        healthManager = FindObjectOfType<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogError("HealthManager not found in scene!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Player hit an enemy
            healthManager.TakeDamage();
            // Destroy the enemy
            Destroy(other.gameObject);
        }
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
>>>>>>> parent of 6090528 (health destroyed with everything else)
    }


}
<<<<<<< HEAD
















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
=======
>>>>>>> parent of 6090528 (health destroyed with everything else)
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
>>>>>>> parent of 6090528 (health destroyed with everything else)
