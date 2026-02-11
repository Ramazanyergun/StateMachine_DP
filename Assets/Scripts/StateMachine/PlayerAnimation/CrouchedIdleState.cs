using UnityEngine;

public class CrouchedIdleState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Crouched Idle Enter State");
        playerStateMachine.Animator.SetCrouch(InputManager.Instance.isCrouchedWalking);
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Crouched Idle Exit State");

    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Crouched Idle Update State");
    }


}
