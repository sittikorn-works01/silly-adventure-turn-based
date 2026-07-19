using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialoguePanel dialoguePanel;
    private GameStateController GameStateController => GameStateController.Instance;
    private UnitInfo currentInteractedUnit;
    private UnitInfo playerUnit;

    private void GameStateController_GameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.FreeRoam:
                OnEnterFreeRoamState();
                break;
            case GameState.Dialogue:
                OnEnterDialogueState();
                break;
        }
    }

    public void SetCurrentInteractedUnit(UnitInfo interactedUnit)
    {
        currentInteractedUnit = interactedUnit;
    }

    public void SetPlayerUnit(UnitInfo playerUnit)
    {
        this.playerUnit = playerUnit;
    }

    private void OnEnterFreeRoamState()
    {
        dialoguePanel.Close();
    }

    private void OnEnterDialogueState()
    {
        dialoguePanel.Open();
        dialoguePanel.Initialize(playerUnit, currentInteractedUnit);
    }

    public void OnEnable()
    {
        GameStateController.GameStateChanged += GameStateController_GameStateChanged;
    }

    private void OnDisable()
    {
        GameStateController.GameStateChanged -= GameStateController_GameStateChanged;
    }
}
