using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Toggle  ")]
public class ToggleInteraction : InteractionData
{
    public override void OnPress(GameObject interactor)
    {
        isActive = !isActive;
        Debug.Log(isActive ? "Kapı Açıldı" : "Kapı Kapandı");
    }
}
