using System;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PlayerLocomotion))]
[RequireComponent(typeof(AnimationManager))]
public class PlayerManager : MonoBehaviour
{

    private InputManager m_inputManager;
    private PlayerLocomotion m_playerLocomotion;
    private AnimationManager m_animationManager;

    void Awake()
    {



        m_inputManager = GetComponent<InputManager>();
        m_playerLocomotion = GetComponent<PlayerLocomotion>();
        m_animationManager = GetComponent<AnimationManager>();

    }

    void Update()
    {
        m_inputManager.HandleAllInputs();
    }
    void FixedUpdate()
    {

        m_playerLocomotion.HandleAllMovements();

        m_animationManager.HandleAnimations();

    }

}
