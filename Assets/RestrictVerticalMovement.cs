// using UnityEngine;

// public class RestrictVerticalMovement : MonoBehaviour
// {
//     private Camera mainCamera;

//     void Start()
//     {
//         mainCamera = Camera.main; 
//     }

//     void Update()
//     {
//         Vector3 playerPosition = transform.position;

        
//         float screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
//         float screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        
//         if (playerPosition.y > screenTop)
//         {
//             playerPosition.y = screenTop;
//         }
//         else if (playerPosition.y < screenBottom)
//         {
//             playerPosition.y = screenBottom;
//         }

//         transform.position = playerPosition;
//     }
// }

using UnityEngine;

public class RestrictVerticalMovement : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        AssignMainCamera();
    }

    void Update()
    {
        // If no camera is assigned, attempt to reassign it
        if (mainCamera == null)
        {
            AssignMainCamera();
            if (mainCamera == null) return; // Exit if still null
        }

        Vector3 playerPosition = transform.position;

        // Get screen boundaries
        float screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        float screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        // Restrict the player's vertical movement
        if (playerPosition.y > screenTop)
        {
            playerPosition.y = screenTop;
        }
        else if (playerPosition.y < screenBottom)
        {
            playerPosition.y = screenBottom;
        }

        // Apply the updated position to the player
        transform.position = playerPosition;
    }

    private void AssignMainCamera()
    {
        if (Camera.main != null)
        {
            mainCamera = Camera.main;
        }
        else
        {
            mainCamera = FindObjectOfType<Camera>();
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("No camera found in the scene. Ensure a camera is tagged as MainCamera.");
        }
    }
}
