using System;
using UnityEngine;
// public class AnimationManager : MonoBehaviour
// {
//     private Animator m_animator;
//     private InputManager m_inputManager;

//     void Awake()
//     {
//         m_animator = GetComponent<Animator>();
//         m_inputManager = GetComponent<InputManager>();
//     }

//     public void HandleAnimations()
//     {
//         if (m_animator == null || m_inputManager == null) return;

//         // Her karede if-else yerine direkt değeri atayabilirsin
//         m_animator.SetBool("isSprinting", m_inputManager.isSprinting);

//         // Ekstra: Karakterin hareket edip etmediğini de kontrol etmek isteyebilirsin
//         // bool isMoving = m_inputManager.movementInput.magnitude > 0.1f;
//         // m_animator.SetBool("isMoving", isMoving);
//     }
// }


public class AnimationManager : MonoBehaviour
{
    private Animator m_animator;
    private InputManager m_inputManager;
    private Rigidbody m_rb;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_inputManager = GetComponent<InputManager>();
        m_rb = GetComponent<Rigidbody>();
    }

    public void HandleAnimations()
    {
        if (m_animator == null) return;

        // Karakterin o anki gerçek hızını alıyoruz (Yatay düzlemde)
        Vector3 velocity = m_rb.linearVelocity;
        velocity.y = 0;
        float currentSpeed = velocity.magnitude;

        // Animator'daki "Speed" parametresini güncelliyoruz
        // 0.1f damptime, geçişlerin çok daha yumuşak olmasını sağlar
        m_animator.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime);
    }
}