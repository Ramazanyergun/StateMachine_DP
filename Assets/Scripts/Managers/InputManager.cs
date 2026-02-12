using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private PlayerInputAction inputActions;
    [Header("Movement Inputs")]
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public bool isCrouchedWalking;
    public bool isSprinting;

    [Header("Jump Input")]
    public bool isJumped;

    [Header("Camera Input")]
    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
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

        inputActions.Locomotion.Crouch.started += i => isCrouchedWalking = true;
        inputActions.Locomotion.Crouch.canceled += i => isCrouchedWalking = false;

        inputActions.Locomotion.Sprint.started += i => isSprinting = true;
        inputActions.Locomotion.Sprint.canceled += i => isSprinting = false;

        inputActions.Locomotion.Jump.started += i => isJumped = true;
        inputActions.Locomotion.Jump.canceled += i => isJumped = false;

        inputActions.Camera.Follow.performed += i => cameraInput = i.ReadValue<Vector2>();
        inputActions.Camera.Follow.canceled += i => cameraInput = Vector2.zero;

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleCameraInput();
    }

    private void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }

    private void HandleCameraInput()
    {
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }


}
