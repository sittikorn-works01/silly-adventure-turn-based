using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIPanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI unitTurnText;
    [SerializeField] private TextMeshProUGUI unitActionText;

    [SerializeField] private Image playerHPBar;

    private PlayerCommandManager player;
    private EnemyCommandManager enemy;
    
    private void OnEnable()
    {
        BattleManager.Instance.OnBattleStateChanged += ShowUnitTurnText;
    }   

    public void Initialize(PlayerCommandManager player, EnemyCommandManager enemy)
    {
        this.player = player;
        this.enemy = enemy;
        player.HealthChanged += UpdatePlayerHPBar;
    }

    public void ShowUnitTurnText(BattleState state)
    {
        if(state == BattleState.PlayerTurn)
        {
            unitTurnText.text = $"{player.name} Turn!";
        }
        else if (state == BattleState.EnemyTurn)
        {
            unitTurnText.text = $"{enemy.name} Turn!";
        }
    }

    //public void ShowUnitActionText(string unitName)
    //{
    //    unitActionText.text = $"{unitName} Turn!";
    //}

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
        BattleManager.Instance.OnBattleStateChanged -= ShowUnitTurnText;
    }
}
