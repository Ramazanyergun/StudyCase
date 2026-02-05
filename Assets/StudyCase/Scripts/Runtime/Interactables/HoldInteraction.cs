using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Hold  ")]
public class HoldInteraction : InteractionData
{
    public override void OnHold(GameObject interactor, float holdTime)
    {
        if (holdTime >= holdDuration)
        {
            Debug.Log("Lever aktif!");
        }
    }

    public override void OnRelease(GameObject interactor)
    {
        Debug.Log("Lever bırakıldı");
    }
}
