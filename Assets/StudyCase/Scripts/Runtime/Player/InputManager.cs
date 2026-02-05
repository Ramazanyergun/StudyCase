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

    }
    private void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }
}
