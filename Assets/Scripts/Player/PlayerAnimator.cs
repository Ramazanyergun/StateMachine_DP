using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{


    public Animator m_animator { get; private set; }
    int speedHash;
    int isCrouchedHash;
    void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
        
        speedHash = Animator.StringToHash("speed");
        isCrouchedHash = Animator.StringToHash("is_Crouching");
    }

    public void SetSpeed(float value)
    {
        m_animator.SetFloat(speedHash, value, 0.1f, Time.deltaTime);
    }

    public void SetCrouch(bool value)
    {
        m_animator.SetBool(isCrouchedHash, value);
    }


}
