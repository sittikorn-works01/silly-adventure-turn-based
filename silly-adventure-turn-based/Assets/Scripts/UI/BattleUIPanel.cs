using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleUIPanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI unitTurnText;
    [SerializeField] private TextMeshProUGUI unitActionText;

    [SerializeField] private Image playerHPBar;

    private PlayerCommandManager player;
    private EnemyCommandManager enemy;

    private Dictionary<BattleState, Action> stateHandlers;

    [SerializeField] private ResultPanel resultPanel;

    private void OnEnable()
    {
        BattleManager.Instance.OnBattleStateChanged += BattleManager_OnBattleStateChanged;
    }   

    public void Initialize(PlayerCommandManager player, EnemyCommandManager enemy)
    {
        this.player = player;
        this.enemy = enemy;
        player.HealthChanged += UpdatePlayerHPBar;

        SetupHandlers();
    }

    private void SetupHandlers()
    {
        stateHandlers = new()
        {
            {BattleState.PlayerTurn, () => ShowUnitTurnText(player)},
            {BattleState.EnemyTurn, () => ShowUnitTurnText(enemy)},
            {BattleState.Win, () => ShowResultPanel(BattleState.Win)},
            {BattleState.Lose, () => ShowResultPanel(BattleState.Lose)},
        };
    }

    private void ShowUnitTurnText(BaseUnitManager unit)
    {
        unitTurnText.text = $"{unit.UnitName} Turn!";
    }

    private void ShowUnitActionText(string unitName)
    {
        unitActionText.text = $"{unitName} Turn!";
    }

    public void UpdatePlayerHPBar(float currentHealth, float maxHealth)
    {
        playerHPBar.fillAmount = currentHealth/maxHealth;
    }

    private void OnDestroy()
    {
        player.HealthChanged -= UpdatePlayerHPBar;
    }

    private void OnDisable()
    {
        BattleManager.Instance.OnBattleStateChanged -= BattleManager_OnBattleStateChanged;
    }

    private void BattleManager_OnBattleStateChanged(BattleState state)
    {
        if(stateHandlers.TryGetValue(state, out var handler))
        {
            handler.Invoke();
        }
    }

    private void ShowResultPanel(BattleState state)
    {
        resultPanel.Initialize(state);
        resultPanel.Open();
    }
}
