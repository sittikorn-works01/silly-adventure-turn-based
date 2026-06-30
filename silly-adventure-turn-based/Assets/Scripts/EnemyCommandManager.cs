using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyCommandManager : BaseUnitManager
{
    public void OnEnterTurn()
    {
        //DoDamage(GameManager.player);
        EndTurn().Forget();

    }
    private async UniTaskVoid EndTurn()
    {
        await UniTask.Delay(1000);
        BattleManager.Instance.SetBattleState(BattleState.PlayerTurn);

    }

    public override void TakeDamage(float receivedDamage)
    {
        base.TakeDamage(receivedDamage);
        //GameManager.battlePanel.UpdateEnemyHPBar(hp, unitInfo.hp);
    }

    public override void BattleManager_OnBattleStateChanged(BattleState state)
    {
        
    }
}
