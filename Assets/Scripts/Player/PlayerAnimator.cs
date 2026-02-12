using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator Animator { get; private set; }

    int speedHash;
    int crouchHash;
    int groundedHash;
    int jumpHash;

    void Awake()
    {
        Animator = GetComponentInChildren<Animator>();

        speedHash = Animator.StringToHash("Speed");
        crouchHash = Animator.StringToHash("Crouch");
        groundedHash = Animator.StringToHash("IsGrounded");
        jumpHash = Animator.StringToHash("Jump");
    }

    public void UpdateAnimator(float speed, bool isGrounded, bool isCrouched)
    {
        Animator.SetFloat(speedHash, speed, 0.1f, Time.deltaTime);
        Animator.SetFloat(crouchHash, isCrouched ? 1f : 0f, 0.1f, Time.deltaTime);
        Animator.SetBool(groundedHash, isGrounded);
    }

    public void TriggerJump()
    {
        Animator.SetTrigger(jumpHash);
    }
}
