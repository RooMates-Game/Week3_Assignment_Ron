using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] private float speed = 10f;

    [SerializeField] private InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [SerializeField] private float reverseDuration = 3f; // Duration to keep the direction reversed
    private Coroutine reverseCoroutine = null; // Tracks the current coroutine for reversing directions


    private bool reverseHorizontal = false; // Tracks whether horizontal movement is reversed

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();

        // Reverse horizontal movement if the toggle is active
        if (reverseHorizontal)
        {
            moveDirection.x *= -1;
        }

        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
    }


    // BOOST HANDLER
    // Method to toggle horizontal direction reversal
    public void SwapHorizontalDirection()
        {
            // Start the reverse effect for a limited duration
            if (reverseCoroutine != null)
            {
                StopCoroutine(reverseCoroutine);
            }
            reverseCoroutine = StartCoroutine(ReverseDirectionForDuration());
        }

    private IEnumerator ReverseDirectionForDuration()
    {
        reverseHorizontal = true;
        Debug.Log("Horizontal direction reversed!");
        yield return new WaitForSeconds(reverseDuration);
        reverseHorizontal = false;
        Debug.Log("Horizontal direction restored to normal.");
        reverseCoroutine = null;
    }
}
