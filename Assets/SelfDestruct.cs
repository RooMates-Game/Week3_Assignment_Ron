using UnityEngine;
using System.Collections; // Add this line

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destructionTime = 3f; // Time in seconds before the object is destroyed

    private void Start()
    {
        // Call the coroutine to destroy the object after the specified time
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(destructionTime);

        // Destroy this GameObject after the wait time
        Destroy(gameObject);
    }
}
