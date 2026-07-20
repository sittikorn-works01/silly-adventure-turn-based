using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommandManager : BaseUnitManager
{
    private Dictionary<BattleState, Action> stateHandlers;

    private void Start()
    {
        stateHandlers = new()
        {
            {BattleState.EnemyTurn, OnEnterTurn },
        };
    }

    public void OnEnterTurn()
    {
        DoDamage();
        EndTurn().Forget();

    }
    public void DoDamage()
    {
        print($"{UnitName} is attacking");
        //TODO: add select-unit-to-apply-command system
        BattleManager.Instance.player.TakeDamage(Atk);
    }

    private async UniTaskVoid EndTurn()
    {
        await UniTask.Delay(1000);
        BattleManager.Instance.SetBattleState(BattleState.PlayerTurn);
    }

    public override void BattleManager_OnBattleStateChanged(BattleState state)
    {
        if (stateHandlers.TryGetValue(state, out var handler))
        {
            handler.Invoke();
        }
    }
}
