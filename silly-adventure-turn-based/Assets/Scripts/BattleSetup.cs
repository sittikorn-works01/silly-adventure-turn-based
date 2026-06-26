using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSetup : MonoBehaviour
{
    private static BattleSetup _instance;
    public UnitInfo EnemyToFight { get; private set;  }
    public static BattleSetup Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<BattleSetup>();
            }
            return _instance;
        }        
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void BeginBattle(UnitInfo unitInfo)
    {
        EnemyToFight = unitInfo;
        SceneController.LoadBattleScene();
    }

    public void BeginBattle(UnitInfo[] enemyInfos)
    {

    }


}
