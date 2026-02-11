using UnityEngine;

public class CrouchedWalkingState :PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine playerStateMachine)
    {
          Debug.Log("You entered the Crouched Walking Enter State");
    }

    public override void ExitState(PlayerStateMachine playerStateMachine)
    {
       Debug.Log("You entered the Crouched Walking Exit State");
    }

    public override void UpdateState(PlayerStateMachine playerStateMachine)
    {
    Debug.Log("You entered the Crouched Walking Update State");
    }

  
}
