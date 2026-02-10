using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private PlayerInputAction inputActions;
    [Header("Movement Inputs")]
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            Instance = this;

        inputActions = new PlayerInputAction();
    }


    void OnEnable()
    {
        inputActions.Locomotion.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        inputActions.Locomotion.Movement.canceled += _ => movementInput = Vector2.zero;

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();

    }

    private void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }


}
