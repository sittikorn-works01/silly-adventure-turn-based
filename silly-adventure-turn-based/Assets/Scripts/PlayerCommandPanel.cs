using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class PlayerCommandPanel : MonoBehaviour
{
    [SerializeField] private PlayerCommandManager playerBattleCommand;

    [SerializeField] private Button attackButton; 
    [SerializeField] private Button healButton; 
    [SerializeField] private Button surrenderButton; 

    public void SetupPanel()
    {
        attackButton.onClick.AddListener(OnPressCommandAttack);
        healButton.onClick.AddListener(OnPressCommandAttack);
        surrenderButton.onClick.AddListener(OnPressCommandAttack);

        attackButton.gameObject.SetActive(true);
        healButton.gameObject.SetActive(true);
        surrenderButton.gameObject.SetActive(true);
    }

    private void OnPressCommandAttack()
    {
        playerBattleCommand.OnCommandAttack();
        EndTurn().Forget();
    }

    private async UniTaskVoid EndTurn()
    {
        DisableCommandButton();
        await UniTask.Delay(1000);
        GameManager.Instance.SetGameState(GameState.EnemyTurn);
        
    }

    private void DisableCommandButton()
    {
        attackButton.onClick.RemoveAllListeners();
        healButton.onClick.RemoveAllListeners();
        surrenderButton.onClick.RemoveAllListeners();

        attackButton.gameObject.SetActive(false);
        healButton.gameObject.SetActive(false);
        surrenderButton.gameObject.SetActive(false);
    }
}
