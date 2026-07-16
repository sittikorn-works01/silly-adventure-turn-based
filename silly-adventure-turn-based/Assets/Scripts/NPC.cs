using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public CanvasGroup uiCanvas;

    [SerializeField] private string interactPrompt;
    [SerializeField] private UnitInfo unitInfo;
    public string InteractPrompt => interactPrompt;    

    public void Interact()
    {
        print(interactPrompt);

        GameStateController.Instance.DialogueController.SetCurrentInteractedUnit(unitInfo);
        GameStateController.Instance.ChangeGameState(GameState.Dialogue);

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
