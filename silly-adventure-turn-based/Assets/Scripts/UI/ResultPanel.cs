using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : BasePanel
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button exitButton;
    public void Initialize(BattleState state)
    {
        resultText.text = state.ToString();
    }
}
