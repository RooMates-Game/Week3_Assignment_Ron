// using UnityEngine;

// public class WrapAroundHorizontal : MonoBehaviour
// {
//     private Camera mainCamera;

//     void Start()
//     {
//         mainCamera = Camera.main;
//     }

//     void Update()
//     {
//         Vector3 playerPosition = transform.position;


//         float screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
//         float screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;


//         if (playerPosition.x > screenRight)
//         {
//             playerPosition.x = screenLeft;
//         }

//         else if (playerPosition.x < screenLeft)
//         {
//             playerPosition.x = screenRight;
//         }


//         transform.position = playerPosition;
//     }
// }


using UnityEngine;

public class WrapAroundHorizontal : MonoBehaviour
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
            if (mainCamera == null) return; // If still null, exit to avoid errors
        }

        Vector3 playerPosition = transform.position;

        // Get screen boundaries
        float screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        // Wrap the player around horizontally
        if (playerPosition.x > screenRight)
        {
            playerPosition.x = screenLeft;
        }
        else if (playerPosition.x < screenLeft)
        {
            playerPosition.x = screenRight;
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
