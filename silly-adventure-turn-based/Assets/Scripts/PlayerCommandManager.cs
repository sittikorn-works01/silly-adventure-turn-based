using System;
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
}
