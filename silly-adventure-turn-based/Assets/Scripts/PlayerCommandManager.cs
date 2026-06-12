using UnityEngine;

public class PlayerCommandManager : BaseUnit
{
    [SerializeField] private PlayerCommandPanel commandPanel;

    public void OnEnterTurn()
    {
        commandPanel.SetupPanel();
    }

    public void OnCommandAttack()
    {
        DoDamage(GameManager.enemy);
    }

    public override void TakeDamage(float receivedDamage)
    {
        base.TakeDamage(receivedDamage);
        GameManager.gameplayUIPanel.UpdatePlayerHPBar(hp, unitInfo.hp);
    }
}
