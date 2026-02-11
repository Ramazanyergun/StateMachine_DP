using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_moveSpeed = 4f;
    [SerializeField] private float m_CrouchedWalkSpeed;
    [SerializeField] private float m_SprintSpeed;
    [SerializeField] private float m_acceleration = 0.15f;
    public float currentSpeed;
    Vector3 m_currentVelocity;

    public void HandleAllMovements()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveInput = new Vector2(
            InputManager.Instance.horizontalInput,
            InputManager.Instance.verticalInput
        );

        if (moveInput.magnitude > 0.1f)
        {
            Vector3 moveDir = transform.forward * moveInput.y + transform.right * moveInput.x;
            moveDir.y = 0;
            moveDir.Normalize();

            currentSpeed = GetMovementSpeed();
            Vector3 targetVelocity = moveDir * currentSpeed;

            m_rigidbody.linearVelocity = Vector3.SmoothDamp(
                m_rigidbody.linearVelocity,
                targetVelocity,
                ref m_currentVelocity,
                m_acceleration
            );
        }
        else
        {
            m_rigidbody.linearVelocity = Vector3.SmoothDamp(
                m_rigidbody.linearVelocity,
                Vector3.zero,
                ref m_currentVelocity,
                m_acceleration
            );
        }


    }
    private float GetMovementSpeed()
    {
        if (InputManager.Instance.isCrouchedWalking)
            return m_CrouchedWalkSpeed;

        if (InputManager.Instance.isSprinting)
            return m_SprintSpeed;

        return m_moveSpeed;
    }

}
