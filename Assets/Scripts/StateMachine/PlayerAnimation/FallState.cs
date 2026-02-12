using UnityEngine;

public class FallState : PlayerAnimBaseState
{
    public override void EnterState(PlayerStateMachine sm)
    {
        Debug.Log("Fall State Enter");
    }

    public override void ExitState(PlayerStateMachine sm)
    {
        Debug.Log("Fall State Exit");
    }

    public override void UpdateState(PlayerStateMachine sm)
    {
        // Havada hafif yön kontrolü istiyorsan:
       

        // Yere değdi mi?
        if (sm.Movement.IsGrounded())
        {
            sm.ChangeState(new GroundedState());
        }
    }
}
