using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable currentInteractableObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactableObj))
        {
            currentInteractableObj = interactableObj;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractableObj = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableObj != null)
        {
            currentInteractableObj.Interact();
        }
    }
}
