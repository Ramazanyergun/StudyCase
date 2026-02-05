using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private InputManager m_inputManager;
    private PlayerLocomotion m_playerLocomotion;
    private AnimationManager m_animationManager;

    void Awake()
    {
        try
        {
            m_inputManager = GetComponent<InputManager>();
            m_playerLocomotion = GetComponent<PlayerLocomotion>();
            m_animationManager = GetComponent<AnimationManager>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }

    void Update()
    {
        m_inputManager.HandleAllInputs();
    }
    void FixedUpdate()
    {
        if (m_playerLocomotion != null)
            m_playerLocomotion.HandleAllMovements();
        if (m_animationManager != null)
            m_animationManager.HandleAnimations();

    }

}
