using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance;
    private GameState currentGameState;

    public event Action <GameState> GameStateChanged;
    [SerializeField] private CameraController cameraController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cameraController.Initialize();
    }

    public void ChangeGameState(GameState newState)
    {
        currentGameState = newState;
        OnEnterGameState();
    }

    private void OnEnterGameState()
    {
        GameStateChanged?.Invoke(currentGameState);

        //switch (currentGameState)
        //{
        //    case GameState.FreeRoam:
        //        OnEnterFreeRoamState();
        //        break;
        //    case GameState.Dialogue:
        //        OnEnterDialogueState();
        //        break;
        //}
            
    }

    //private void OnEnterFreeRoamState()
    //{

    //}

    //private void OnEnterDialogueState()
    //{

    //}
}
