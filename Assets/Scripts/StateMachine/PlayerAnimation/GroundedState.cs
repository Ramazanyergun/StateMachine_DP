using UnityEngine;
public class GroundedState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("Grounded Enter State");
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("Grounded Exit State");
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        // Hareketi sadece grounded state kontrol eder
        playerStateMachine.Movement.HandleAllMovements();

        // Jump kontrolü
        if (InputManager.Instance.isJumped && playerStateMachine.Movement.IsGrounded())
        {
            playerStateMachine.ChangeState(new JumpState());
            return;
        }

        // Yerden düştüyse fall state
        if (!playerStateMachine.Movement.IsGrounded())
        {
            playerStateMachine.ChangeState(new FallState());
        }
    }
}
