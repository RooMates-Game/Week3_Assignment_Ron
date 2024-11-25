using UnityEngine;

public class RestrictVerticalMovement : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; 
    }

    void Update()
    {
        Vector3 playerPosition = transform.position;

        
        float screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        float screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        
        if (playerPosition.y > screenTop)
        {
            playerPosition.y = screenTop;
        }
        else if (playerPosition.y < screenBottom)
        {
            playerPosition.y = screenBottom;
        }

        transform.position = playerPosition;
    }
}
