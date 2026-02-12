using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float m_moveSpeed = 4f;
    [SerializeField] private float m_CrouchedWalkSpeed;
    [SerializeField] private float m_acceleration = 0.15f;
    public float m_SprintSpeed;

    public float currentSpeed;
    Vector3 m_currentVelocity;


    [Header("Jump Settings")]
    [SerializeField] private float m_jumpForce = 6f;

    [Header("Grounded Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private bool m_isGrounded;
    [Header("Rotation Settings")]
    [SerializeField] private float m_rotationSpeed;
    private Transform m_cam;

    void Awake()
    {
        m_cam = Camera.main.transform;
    }
    void FixedUpdate()
    {
        m_isGrounded = CheckIsGrounded();
    }
    public void HandleAllMovements()
    {

        HandleRotation();
        HandleMovement();
        HandleJump();
    }


    private void HandleRotation()
    {
        Vector3 moveDir =
            m_cam.forward * InputManager.Instance.verticalInput +
            m_cam.right * InputManager.Instance.horizontalInput;

        moveDir.y = 0f;

        if (moveDir.sqrMagnitude < 0.01f)
            return;

        moveDir.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(moveDir);

        Quaternion smoothRotation = Quaternion.Slerp(
            m_rigidbody.rotation,
            targetRotation,
            m_rotationSpeed * Time.deltaTime
        );

        m_rigidbody.MoveRotation(smoothRotation);
    }
    private void HandleMovement()
    {
        Vector2 moveInput = new Vector2(
            InputManager.Instance.horizontalInput,
            InputManager.Instance.verticalInput
        );

        if (moveInput.magnitude > 0.1f)
        {
            Vector3 moveDir =
                m_cam.forward * moveInput.y +
                m_cam.right * moveInput.x;

            moveDir.y = 0f;
            moveDir.Normalize();

            currentSpeed = GetMovementSpeed();

            Vector3 targetVelocity = moveDir * currentSpeed;
            targetVelocity.y = m_rigidbody.linearVelocity.y;

            m_rigidbody.linearVelocity = Vector3.SmoothDamp(
                m_rigidbody.linearVelocity,
                targetVelocity,
                ref m_currentVelocity,
                m_acceleration
            );
        }
        else
        {
            currentSpeed = 0;
        }
    }


    public void HandleJump()
    {
        if (IsGrounded() && InputManager.Instance.isJumped)
        {
            m_rigidbody.linearVelocity = new Vector3(
                m_rigidbody.linearVelocity.x,
                m_jumpForce,
                m_rigidbody.linearVelocity.z
            );
        }
    }

    private bool CheckIsGrounded()
    {
        return Physics.CheckSphere(
             groundCheckPoint.position,
             groundCheckRadius,
             groundLayer
         );
    }
    private float GetMovementSpeed()
    {
        if (InputManager.Instance.isCrouchedWalking)
            return m_CrouchedWalkSpeed;

        if (InputManager.Instance.isSprinting)
            return m_SprintSpeed;


        return m_moveSpeed;
    }


    public bool IsGrounded()
    {
        return m_isGrounded;
    }
}
