using UnityEngine;

public class BoostCollusion : MonoBehaviour
{ [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            // Destroy the boost object when colliding
            Destroy(other.gameObject);

            // Swap the player's left and right directions
            ReversePlayerControls();
        }
    }

    // Function to reverse the player's controls
    private void ReversePlayerControls()
    {
        // Find the player's InputMover script
        InputMover inputMover = GameObject.FindWithTag("Player").GetComponent<InputMover>();

        if (inputMover != null)
        {
            inputMover.SwapHorizontalDirection();
        }
        else
        {
            Debug.LogWarning("Player or InputMover script not found!");
        }
    }
}
