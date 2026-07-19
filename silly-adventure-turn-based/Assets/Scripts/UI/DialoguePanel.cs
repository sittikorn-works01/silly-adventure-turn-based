using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : BasePanel
{
    [SerializeField] private Button battleButton;
    [SerializeField] private Button exitButton;
    private GameStateController GameStateController => GameStateController.Instance;
    private BattleSetup BattleSetup => BattleSetup.Instance;

    private UnitInfo currentInteractedUnit;
    private UnitInfo playerUnit;


    private void OnEnable()
    {
        battleButton.onClick.AddListener(OnPressBattleButton);
        exitButton.onClick.AddListener(OnPressExitButton);
    }

    public void Initialize(UnitInfo playerUnit, UnitInfo currentInteractedUnit)
    {
        this.playerUnit = playerUnit;
        this.currentInteractedUnit = currentInteractedUnit;
        print($"{playerUnit.name} is having a chat with {currentInteractedUnit.name}");
    }

    private void OnPressBattleButton()
    {
        BattleSetup.BeginBattle(playerUnit, currentInteractedUnit);
        print($"{playerUnit.name} begins battle with {currentInteractedUnit.name}");
    }

    private void OnPressExitButton()
    {
        GameStateController.ChangeGameState(GameState.FreeRoam);
        Dev.Log();
    }
}
