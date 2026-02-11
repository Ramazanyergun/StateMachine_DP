using UnityEngine;

public class IdleState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Idle Enter State");
        playerStateMachine.Animator.SetCrouch(InputManager.Instance.isCrouchedWalking);
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Idle Exit State");
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Idle Update State");
        if (InputManager.Instance.isCrouchedWalking)
        {
            playerStateMachine.ChangeState(new CrouchedIdleState());

        }
    }
}
