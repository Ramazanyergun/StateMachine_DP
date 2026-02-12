using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerAnimBaseState m_currentState;
    public PlayerMovement Movement { get; private set; }
    public PlayerAnimator Animator { get; private set; }



    void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
        Animator = GetComponent<PlayerAnimator>();
    }
    void Start()
    {
        m_currentState = new GroundedState();
        m_currentState.EnterState(this);
    }

    void Update()
    {
        m_currentState?.UpdateState(this);
        Animator.UpdateAnimator(Movement.currentSpeed / Movement.m_SprintSpeed, Movement.IsGrounded(), InputManager.Instance.isCrouchedWalking);
    }


    public void ChangeState(PlayerAnimBaseState newState)
    {
        m_currentState?.ExitState(this);
        m_currentState = newState;
        m_currentState.EnterState(this);

    }
}
