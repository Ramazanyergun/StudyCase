using UnityEngine;

public class InteractionData : ScriptableObject
{
    [Header("Interaction Settings")]
    public InteractionType interactionType;

    [Tooltip("Hold için gerekli süre")]
    public float holdDuration = 1f;

    protected bool isActive;

    void OnDisable()
    {
        if (interactionType != InteractionType.Hold)
            holdDuration = 0f;
    }
    public virtual void OnPress(GameObject interactor) { }
    public virtual void OnHold(GameObject interactor, float holdTime) { }
    public virtual void OnRelease(GameObject interactor) { }
    public virtual void Interact(GameObject interactor) { }

}
public enum InteractionType
{
    Press,
    Hold,
    Toggle
}