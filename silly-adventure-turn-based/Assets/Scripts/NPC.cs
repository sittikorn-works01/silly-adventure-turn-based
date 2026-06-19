using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public CanvasGroup uiCanvas;

    [SerializeField] private string interactPrompt;
    public string InteractPrompt => interactPrompt;    

    public void Interact()
    {
        print(interactPrompt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.alpha = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.alpha = 0;
        }
    }
}
