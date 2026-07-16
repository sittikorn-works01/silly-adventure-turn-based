using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommandManager : BaseUnitManager
{
    [SerializeField] private PlayerCommandPanel commandPanel;

    private Dictionary<PlayerCommand, Action> commandHandlers;
    private Dictionary<BattleState, Action> stateHandlers;

    private void Start()
    {
        commandHandlers = new()
        {
            { PlayerCommand.Attack, OnPlayerCommandAttack},
        };

        stateHandlers = new()
        {
            {BattleState.PlayerTurn, OnEnterTurn },
        };
    }

    private void CommandPanel_OnPlayerUsingCommand(PlayerCommand command)
    {
        if(commandHandlers.TryGetValue(command, out var handler))
        {
            handler.Invoke();
        }
    }

    public override void BattleManager_OnBattleStateChanged(BattleState state)
    {
        if (stateHandlers.TryGetValue(state, out var handler))
        {
            handler.Invoke();
        }            
    }

    public void OnEnterTurn()
    {
        commandPanel.SetupPanel();
    }

    public void OnPlayerCommandAttack()
    {
        print($"{UnitName} is attacking");
        //select target
    }

    public override void OnEnable()
    {
        base.OnEnable();
        commandPanel.OnPlayerUsingCommand += CommandPanel_OnPlayerUsingCommand;
    }


    public override void OnDisable()
    {
        base.OnDisable();
        commandPanel.OnPlayerUsingCommand -= CommandPanel_OnPlayerUsingCommand;
    }
}
