using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    private Rigidbody m_playerRB;
    private InputManager m_inputManager;
    private Transform cam;
    public float m_crouchedSpeed = 2f;
    public float m_runSpeed = 7f;
    private Vector3 m_currentVelocity;
    [SerializeField] private float m_currentSpeed;
    private bool m_isSprinting;


    public float m_smoothTime = 0.15f;
    public float m_rotationSpeed = 10f;
    private void Awake()
    {
        m_inputManager = GetComponent<InputManager>();
        m_playerRB = GetComponent<Rigidbody>();
        cam = Camera.main.transform;

    }
    public void HandleAllMovements()
    {
        HandleMovement();
        HandleRotation();


    }

    private void HandleRotation()
    {
        Vector3 targetDir = Vector3.zero;
        targetDir = cam.forward * m_inputManager.verticalInput + cam.right * m_inputManager.horizontalInput;

        targetDir.y = 0;
        if (targetDir.sqrMagnitude < 0.01f) return;
        targetDir.Normalize();

        Quaternion targetRot = Quaternion.LookRotation(targetDir, Vector3.up);
        Quaternion playerRot = Quaternion.Slerp(transform.rotation, targetRot, m_rotationSpeed * Time.deltaTime);

        transform.rotation = playerRot;

    }
    private void HandleMovement()
    {
        Vector3 moveDir = cam.forward * m_inputManager.verticalInput + cam.right * m_inputManager.horizontalInput;
        moveDir.Normalize();
        moveDir.y = 0;
        Vector3 targetVelocity;
        if (moveDir.magnitude > 0.1f)
        {
            m_isSprinting = m_inputManager.isSprinting;
            m_currentSpeed = m_isSprinting ? m_runSpeed : m_crouchedSpeed;

            targetVelocity = moveDir * m_currentSpeed;
            m_playerRB.linearVelocity = Vector3.SmoothDamp(m_playerRB.linearVelocity, targetVelocity, ref m_currentVelocity, m_smoothTime);
        }
        else
        {
            targetVelocity = Vector3.zero;
            m_playerRB.linearVelocity = Vector3.SmoothDamp(m_playerRB.linearVelocity, targetVelocity, ref m_currentVelocity, m_smoothTime);
        }
    }
}

