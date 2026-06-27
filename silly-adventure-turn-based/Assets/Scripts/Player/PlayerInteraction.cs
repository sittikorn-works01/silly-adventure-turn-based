using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable currentInteractableObj;
    [SerializeField] private UnitInfo playerUnit; 

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
            GameStateController.Instance.DialogueController.SetPlayerUnit(playerUnit);
            currentInteractableObj.Interact();
        }
    }
}
