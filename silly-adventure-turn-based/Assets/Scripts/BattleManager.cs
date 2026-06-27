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
    public Action<BattleState> BattleStateChanged;

    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private GameObject playerSpawnPoint;

    //public PlayerCommandManager player;
    //public EnemyCommandManager enemy;

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
        //player.Initialize();
        //enemy.Initialize();

        Instantiate(BattleSetup.PlayerUnit.UnitPrefab, playerSpawnPoint.transform.position, playerSpawnPoint.transform.rotation);
        Instantiate(BattleSetup.EnemyToFight.UnitPrefab, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);

        
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
        //battlePanel.ShowUnitTurnText("Player");
        //player.OnEnterTurn();
    }
    private async UniTaskVoid OnEnterEnemyTurn()
    {
        //battlePanel.ShowUnitTurnText("Enemy");
        //enemy.OnEnterTurn();
    }
}
