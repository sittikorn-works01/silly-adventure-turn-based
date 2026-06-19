using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitTurnText;
    [SerializeField] private TextMeshProUGUI unitActionText;

    [SerializeField] private Image playerHPBar;
    [SerializeField] private Image enemyHPBar;

    [SerializeField] private PlayerCommandManager player;

    private void OnEnable()
    {
        player.HealthChanged += UpdatePlayerHPBar;
    }

    private void OnDisable()
    {
        player.HealthChanged -= UpdatePlayerHPBar;
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

    public void UpdateEnemyHPBar(float currentHealth, float maxHealth)
    {
        Dev.Log();
        enemyHPBar.fillAmount = currentHealth/maxHealth;
        Debug.Log($"{currentHealth} {maxHealth}");
    }


}
