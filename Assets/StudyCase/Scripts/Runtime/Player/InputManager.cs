using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private PlayerInputActions inputActions;

    public Vector2 movementInput;

    public float horizontalInput;
    public float verticalInput;
    public bool isSprinting;
    public bool isInteracting;
    private Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    void Awake()
    {
        if (Instance == null)
            Instance = this;

    }
    void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerInputActions();

            inputActions.Locomotion.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            inputActions.Locomotion.Movement.canceled += i => movementInput = Vector2.zero;

            inputActions.Locomotion.Sprint.started += _ => isSprinting = true;
            inputActions.Locomotion.Sprint.canceled += _ => isSprinting = false;

            inputActions.Camera.Follow.performed += i => cameraInput = i.ReadValue<Vector2>();
            inputActions.Camera.Follow.canceled += i => cameraInput = Vector2.zero;
 
            inputActions.Interaction.Interact.started += _ => isInteracting = true;
            inputActions.Interaction.Interact.canceled += _ => isInteracting = false;

        }
        inputActions.Enable();
    }

    void OnDisable()
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
