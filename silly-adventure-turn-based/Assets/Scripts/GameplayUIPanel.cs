using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI unitTurnText;
    [SerializeField] private TextMeshProUGUI unitActionText;

    [SerializeField] private Image playerHPBar;
    [SerializeField] private Image enemyHPBar;

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
