using UnityEngine;

public class JumpState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine sm)
    {
        Debug.Log("Jump Enter State");

        sm.Movement.HandleJump();   // fizik
        sm.Animator.TriggerJump();  // animasyon
    }

    public override void ExitState(PlayerStateMachine sm)
    {
        Debug.Log("Jump Exit State");
    }

    public override void UpdateState(PlayerStateMachine sm)
    {
        // Yerden gerçekten ayrıldıysa fall'a geç
        if (!sm.Movement.IsGrounded())
        {
            sm.ChangeState(new FallState());
        }
    }
}
