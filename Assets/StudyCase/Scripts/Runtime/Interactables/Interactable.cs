using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractionData interactionData;

    [HideInInspector] public float holdTimer;

    public void Press(GameObject interactor)
    {
        interactionData.OnPress(interactor);
    }

    public void Hold(GameObject interactor)
    {
        holdTimer += Time.deltaTime;
        interactionData.OnHold(interactor, holdTimer);
    }

    public void Release(GameObject interactor)
    {
        holdTimer = 0f;
        interactionData.OnRelease(interactor);
    }
}
