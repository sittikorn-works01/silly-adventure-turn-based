using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : BasePanel
{
    [SerializeField] private Button battleButton;
    [SerializeField] private Button exitButton;
    private GameStateController GameStateController => GameStateController.Instance;
    private BattleSetup BattleSetup => BattleSetup.Instance;

    private UnitInfo currentInteractedUnit;


    private void OnEnable()
    {
        battleButton.onClick.AddListener(OnPressBattleButton);
        exitButton.onClick.AddListener(OnPressExitButton);
    }

    public void Initialize(UnitInfo currentInteractedUnit)
    {
        this.currentInteractedUnit = currentInteractedUnit;
        print($"PLAYER IS NOW HAVE A CHAT WITH {currentInteractedUnit.name}");
    }

    private void OnPressBattleButton()
    {
        //BattleSetup.BeginBattle();
    }

    private void OnPressExitButton()
    {
        GameStateController.ChangeGameState(GameState.FreeRoam);
        Dev.Log();
    }
}
