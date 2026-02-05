using System;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator m_animator;

    void Awake()
    {
        try
        {
            m_animator = GetComponent<Animator>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
    public void HandleAnimations()
    {
        m_animator.SetBool("isSprinting", InputManager.Instance.isSprinting);

    }
}
