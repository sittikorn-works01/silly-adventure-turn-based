using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;
    public static BattleManager Instance 
    {
        get 
        { 
            if(instance == null)
            {
                instance = FindFirstObjectByType<BattleManager>();
            }
            return instance;
        }
    }
    public static BattleSetup BattleSetup => BattleSetup.Instance;
    private BattleState currentState;
    public Action<BattleState> OnBattleStateChanged;

    [SerializeField] private Transform unitsParent;
    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private GameObject playerSpawnPoint;

    public PlayerCommandManager player;
    public EnemyCommandManager enemy;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        player.Initialize(BattleSetup.PlayerUnit);
        enemy.Initialize(BattleSetup.EnemyUnit);

        Instantiate(BattleSetup.PlayerUnit.UnitPrefab, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation, unitsParent);
        Instantiate(BattleSetup.EnemyUnit.UnitPrefab, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation, unitsParent);

        
        print($"Battle with {BattleSetup.EnemyUnit.name}");
        SetBattleState(BattleState.PlayerTurn);
    }

    public void SetBattleState(BattleState newState)
    {
        Dev.Log();
        currentState = newState;
        OnBattleStateChanged?.Invoke(newState);
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
        //battlePanel.ShowUnitTurnText("Player");
        //player.OnEnterTurn();
    }
    private async UniTaskVoid OnEnterEnemyTurn()
    {
        //battlePanel.ShowUnitTurnText("Enemy");
        //enemy.OnEnterTurn();
    }
}
