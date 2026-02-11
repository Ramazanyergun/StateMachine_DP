using UnityEngine;

public abstract class PlayerAnimBaseState
{

    // What do you when you enter the state 
    public abstract void EnterState(PlayerStateMachine playerStateMachine);

    // What do you when you change the state
    public abstract void UpdateState(PlayerStateMachine playerStateMachine);

    // What do you when you exit the state
    public abstract void ExitState(PlayerStateMachine playerStateMachine);
}
