using Cysharp.Threading.Tasks;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; set; }
    public static BattleSetup BattleSetup => BattleSetup.Instance;
    private BattleState currentState;
    public GameplayUIPanel gameplayUIPanel;

    //public PlayerCommandManager player;
    //public EnemyCommandManager enemy;

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
        //player.Initialize();
        //enemy.Initialize();
        Dev.Log();
        print($"Battle with {BattleSetup.EnemyToFight.name}");
        SetBattleState(BattleState.PlayerTurn);
    }

    public void SetBattleState(BattleState newState)
    {
        currentState = newState;
        OnChangeBattleState();
    }

    private void OnChangeBattleState()
    {
        switch (currentState)
        {
            case BattleState.PlayerTurn:
                OnEnterPlayerTurn();
                break;
            case BattleState.EnemyTurn:
                OnEnterEnemyTurn().Forget();
                break;
            default:
                break;
        }
    }

    void OnEnterPlayerTurn()
    {
        gameplayUIPanel.ShowUnitTurnText("Player");
        //player.OnEnterTurn();
    }
    private async UniTaskVoid OnEnterEnemyTurn()
    {
        gameplayUIPanel.ShowUnitTurnText("Enemy");
        //enemy.OnEnterTurn();
    }
}
