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
    public DialogueController DialogueController;

    public event Action <GameState> GameStateChanged;

    private void Awake()
    {
        //_instance = this;
        //if (_instance != null)
        //{
        //    print("KUAY I'M OUT");
        //    Destroy(gameObject);
        //}
    }

    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;
        OnEnterGameState();

        GameStateChanged?.Invoke(CurrentGameState);
    }

    private void Update()
    {
        
    }

    private void CHEAT_EnterFreeRoamState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameState(GameState.FreeRoam);
        }
    }

    private void OnEnterGameState()
    {
        switch (CurrentGameState)
        {
            case GameState.FreeRoam:
                OnEnterFreeRoamState();
                break;
            case GameState.Dialogue:
                OnEnterDialogueState();
                break;
        }

    }

    private void OnEnterFreeRoamState()
    {

    }

    private void OnEnterDialogueState()
    {

    }
}
