using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private static GameStateController _instance;
    public static GameStateController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindFirstObjectByType<GameStateController>();
            }
            return _instance;
        }
    }
    public GameState CurrentGameState { get; private set; }

    public event Action <GameState> GameStateChanged;

    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;
        OnEnterGameState();
    }

    private void Update()
    {
        CHEAT();
    }

    private void CHEAT()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameState(GameState.FreeRoam);
        }
    }

    private void OnEnterGameState()
    {
        GameStateChanged?.Invoke(CurrentGameState);

        //switch (CurrentGameState)
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
