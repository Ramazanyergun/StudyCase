using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public LayerMask interactionLayer;

    private Interactable current;

    void Update()
    {
        DetectInteractable();

        if (current == null) return;

        switch (current.interactionData.interactionType)
        {
            case InteractionType.Press:
                if (InputManager.Instance.isInteracting)
                    current.Press(gameObject);
                break;

            case InteractionType.Hold:
                if (InputManager.Instance.isInteracting)
                    current.Hold(gameObject);

                if (!InputManager.Instance.isInteracting)
                    current.Release(gameObject);
                break;

            case InteractionType.Toggle:
                if (InputManager.Instance.isInteracting)
                    current.Press(gameObject);
                break;
        }
    }

    void DetectInteractable()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionLayer))
            current = hit.collider.GetComponent<Interactable>();
        else
            current = null;
    }
}
