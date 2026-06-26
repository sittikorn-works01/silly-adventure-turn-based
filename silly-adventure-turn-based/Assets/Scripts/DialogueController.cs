using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Splines.ExtrusionShapes;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialoguePanel dialoguePanel;
    private GameStateController GameStateController => GameStateController.Instance;
    private UnitInfo currentInteractedUnit;

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

    private void OnEnterFreeRoamState()
    {
        dialoguePanel.Close();
    }

    private void OnEnterDialogueState()
    {
        dialoguePanel.Open();
        dialoguePanel.Initialize(currentInteractedUnit);
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
