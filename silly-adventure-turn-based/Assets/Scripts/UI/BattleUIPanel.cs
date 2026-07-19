using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIPanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI unitTurnText;
    [SerializeField] private TextMeshProUGUI unitActionText;

    [SerializeField] private Image playerHPBar;

    private PlayerCommandManager player;
    
    private void OnDisable()
    {
        player.HealthChanged -= UpdatePlayerHPBar;
    }

    public void Initialize(PlayerCommandManager player)
    {
        this.player = player;
        player.HealthChanged += UpdatePlayerHPBar;
    }

    public void ShowUnitTurnText(string unitName)
    {
        unitTurnText.text = $"{unitName} Turn!";
    }

    public void ShowUnitActionText(string unitName)
    {
        unitActionText.text = $"{unitName} Turn!";
    }

    public void UpdatePlayerHPBar(float currentHealth, float maxHealth)
    {
        Dev.Log();
        playerHPBar.fillAmount = currentHealth/maxHealth;
        Debug.Log($"{currentHealth} {maxHealth}");
    }
}
