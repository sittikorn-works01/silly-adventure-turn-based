using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class PlayerCommandPanel : MonoBehaviour
{
    [SerializeField] private PlayerCommandManager playerBattleCommand;

    [SerializeField] private Button attackButton; 
    [SerializeField] private Button healButton; 
    [SerializeField] private Button surrenderButton;

    public event Action<PlayerCommand> OnPlayerUsingCommand;

    public void SetupPanel()
    {
        Dev.Log();
        attackButton.onClick.AddListener(OnPressCommandAttack);
        healButton.onClick.AddListener(OnPressCommandAttack);
        surrenderButton.onClick.AddListener(OnPressCommandAttack);

        attackButton.gameObject.SetActive(true);
        healButton.gameObject.SetActive(true);
        surrenderButton.gameObject.SetActive(true);
    }

    private void OnPressCommandAttack()
    {
        OnPlayerUsingCommand?.Invoke(PlayerCommand.Attack);
        EndTurn().Forget();
    }

    private async UniTaskVoid EndTurn()
    {
        DisableCommandButton();
        await UniTask.Delay(1000);
        BattleManager.Instance.SetBattleState(BattleState.EnemyTurn);
        
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
