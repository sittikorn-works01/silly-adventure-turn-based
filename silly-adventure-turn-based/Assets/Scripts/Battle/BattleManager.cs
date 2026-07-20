using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
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
    [SerializeField] private BattleUIPanel battlePanel;

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

        battlePanel.Initialize(player, enemy);
        
        print($"Battle with {BattleSetup.EnemyUnit.name}");
        SetBattleState(BattleState.PlayerTurn);
    }

    public void SetBattleState(BattleState newState)
    {
        currentState = newState;
        OnBattleStateChanged?.Invoke(newState);
    }
}
