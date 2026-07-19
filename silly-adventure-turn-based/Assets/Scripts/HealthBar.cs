using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilled;
    private EnemyCommandManager enemy;

    private void Start()
    {
        enemy = FindFirstObjectByType<EnemyCommandManager>();
        enemy.HealthChanged += Enemy_HealthChanged;
    }

    private void Enemy_HealthChanged(float currentHealth, float maxHealth)
    {
        UpdateHealthBarFilled(currentHealth, maxHealth);
    }

    public void UpdateHealthBarFilled(float currentHealth, float maxHealth)
    {
        healthBarFilled.fillAmount = currentHealth / maxHealth;
    }

    private void OnDestroy()
    {
        enemy.HealthChanged -= Enemy_HealthChanged;
    }
}
