using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    private Rigidbody2D _rb;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;

    private Vector2 _moveInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// Input action callback for input controller on player
    /// WASD/Joystick input
    /// </summary>
    /// <param name="action"></param>
    public void OnMoveInput(InputAction.CallbackContext action)
    {
        if (action.performed) { _moveInput = action.ReadValue<Vector2>(); }
        else if (action.canceled) { _moveInput = Vector2.zero; }
    }

    private void MovePlayer()
    {
        _rb.velocity = _moveInput * _moveSpeed;
    }
}
