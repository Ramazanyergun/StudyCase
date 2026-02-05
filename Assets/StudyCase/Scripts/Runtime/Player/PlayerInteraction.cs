using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private float m_interactionDistance;
    [SerializeField] private LayerMask m_interactionLayer;
    [SerializeField] private Vector3 m_offset;
    private Interactable m_currentIInteractable;

    void Update()
    {
        DetectInteractable();
    }
    void DetectInteractable()
    {
        Ray ray = new Ray(Camera.main.transform.position + m_offset, Camera.main.transform.forward);
        Debug.DrawRay(transform.position + m_offset, transform.forward, Color.black);
        if (Physics.Raycast(ray, out RaycastHit hit, m_interactionDistance, m_interactionLayer))
        {

            m_currentIInteractable = hit.collider.GetComponent<Interactable>();
            Debug.Log(m_currentIInteractable.gameObject.name);
        }
        else
            m_currentIInteractable = null;
    }
}
