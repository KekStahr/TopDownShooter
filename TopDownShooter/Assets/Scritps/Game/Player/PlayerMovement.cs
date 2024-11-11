using UnityEngine;
using UnityEngine.InputSystem;

// This script controls the player's movement using Unity's Input System.
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 movementInput;
    [SerializeField] private float speed;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    [SerializeField] private Transform gunHolder; // Reference to the gun holder

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotatePlayerTowardsMouse();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
        _rigidbody.linearVelocity = smoothedMovementInput * speed;
    }

    private void RotatePlayerTowardsMouse()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the mouse is on the left or right side of the player
        if (mousePosition.x < transform.position.x) // Mouse is on the left
        {
            // Rotate player to face left
            transform.rotation = Quaternion.Euler(180, 0, -180);
        }
        else // Mouse is on the right
        {
            // Rotate player to face right
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
