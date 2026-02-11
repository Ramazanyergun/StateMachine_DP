using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerAnimBaseState m_currentState;
    private PlayerMovement m_playerMovement;
    public PlayerAnimator Animator;
    public float speed;


    void Awake()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        Animator = GetComponent<PlayerAnimator>();
    }
    void Start()
    {
        m_currentState = new IdleState();
        m_currentState.EnterState(this);
    }

    void Update()
    {
        m_currentState.UpdateState(this);

    }


    public void ChangeState(PlayerAnimBaseState newState)
    {
        m_currentState.ExitState(this);
        m_currentState = newState;
        m_currentState.EnterState(this);

    }
}
