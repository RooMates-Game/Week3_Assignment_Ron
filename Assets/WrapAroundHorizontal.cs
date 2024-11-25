using UnityEngine;

public class WrapAroundHorizontal : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 playerPosition = transform.position;


        float screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;


        if (playerPosition.x > screenRight)
        {
            playerPosition.x = screenLeft;
        }

        else if (playerPosition.x < screenLeft)
        {
            playerPosition.x = screenRight;
        }


        transform.position = playerPosition;
    }
}
