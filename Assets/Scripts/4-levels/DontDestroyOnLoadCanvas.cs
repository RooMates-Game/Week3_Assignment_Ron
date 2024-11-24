using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadCanvas : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

        private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "level-game-over" || SceneManager.GetActiveScene().name == "level-win") 
        {
            Destroy(gameObject); // Destroy the Canvas when Game Over or Win scene is loaded
        }
    }
}
