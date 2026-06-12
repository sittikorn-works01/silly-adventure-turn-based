using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private GameState currentState;
    public GameplayUIPanel gameplayUIPanel;

    public PlayerCommandManager player;
    public EnemyCommandManager enemy;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    private void Start()
    {
        player.Initialize();
        enemy.Initialize();
        SetGameState(GameState.PlayerTurn);
    }

    public void SetGameState(GameState newState)
    {
        currentState = newState;
        OnChangeGameState();
    }

    private void OnChangeGameState()
    {
        switch (currentState)
        {
            case GameState.PlayerTurn:
                OnEnterPlayerTurn();
                break;
            case GameState.EnemyTurn:
                OnEnterEnemyTurn().Forget();
                break;
            default:
                break;
        }
    }

    void OnEnterPlayerTurn()
    {
        gameplayUIPanel.ShowUnitTurnText("Player");
        player.OnEnterTurn();
    }
    private async UniTaskVoid OnEnterEnemyTurn()
    {
        gameplayUIPanel.ShowUnitTurnText("Enemy");
        enemy.OnEnterTurn();
    }
}
