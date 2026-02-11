using UnityEngine;

public class WalkingState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
          Debug.Log("You entered the Walking Enter State");
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
        Debug.Log("You entered the Walking Exit State");
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
       Debug.Log("You entered the Walking Update State");
    }
}
