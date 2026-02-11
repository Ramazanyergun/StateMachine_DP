using UnityEngine;

public class SprintingState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Sprinting Enter State");
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Sprinting Exit State");
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Sprinting Update State");
    }


}
