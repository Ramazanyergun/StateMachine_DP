using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_moveSpeed = 4f;
    [SerializeField] private float m_acceleration = 0.15f;
    Vector3 m_currentVelocity;

    public void HandleAllMovements()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = new Vector2(InputManager.Instance.horizontalInput, InputManager.Instance.verticalInput);

        if (moveInput.magnitude > 0.1f)
        {
            Vector3 moveDir = transform.forward * moveInput.y + transform.right * moveInput.x;
            moveDir.Normalize();
            moveDir.y = 0;

            // Koşma kontrolü
            // isRunning = Keyboard.current.leftShiftKey.isPressed;
            // movementSpeed = isRunning ? runSpeed : walkSpeed;

            Vector3 targetVelocity = moveDir * m_moveSpeed;
            m_rigidbody.linearVelocity = Vector3.SmoothDamp(m_rigidbody.linearVelocity, targetVelocity, ref m_currentVelocity, m_acceleration);

        }
        else
        {
            m_rigidbody.linearVelocity = Vector3.SmoothDamp(m_rigidbody.linearVelocity, Vector3.zero, ref m_currentVelocity, m_acceleration);
        }
    }
}
