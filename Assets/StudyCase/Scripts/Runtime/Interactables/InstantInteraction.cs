using UnityEngine;
[CreateAssetMenu(menuName = "Interaction/Instant  ")]
public class InstantInteraction : InteractionData
{
    public override void Interact(GameObject interactor)
    {

        Debug.Log("item alındı", interactor);
    }

}
