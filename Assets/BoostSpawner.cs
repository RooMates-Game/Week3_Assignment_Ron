
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boostPrefab; // Assign your Boost Icon prefab in the Inspector
    [SerializeField] private float spawnInterval = 5f; // Time between spawns
    [SerializeField] private int maxBoosts = 3; // Maximum number of boosts allowed in the scene
    [SerializeField] private int currentBoosts = 0; // Current number of boosts in the scene

    private Camera mainCamera;

    private void Start()
    {
        // Get the main camera for determining screen boundaries
        mainCamera = Camera.main;

        // Start spawning the boost at regular intervals
        InvokeRepeating("SpawnBoost", spawnInterval, spawnInterval);
    }

    void SpawnBoost()
    {
        // Check if the current number of boosts is less than the maximum allowed
        if (currentBoosts < maxBoosts)
        {
            // Get the screen boundaries
            float screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            float screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            float screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
            float screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

            // Generate random X and Y positions within the screen bounds
            float randomX = Random.Range(screenLeft, screenRight);
            float randomY = Random.Range(screenBottom, screenTop);

            // Create a random position
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            // Instantiate the Boost Icon prefab at the random position
            GameObject boost = Instantiate(boostPrefab, spawnPosition, Quaternion.identity);

            // Increment the currentBoosts count
            currentBoosts++;

            // Optionally, destroy the boost and decrement the count when it is destroyed
            Destroy(boost, 3f); // Adjust this if needed, as it should be destroyed after 3 seconds
        }
    }
}
