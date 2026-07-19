using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSetup : MonoBehaviour
{
    private static BattleSetup _instance;
    public UnitInfo EnemyUnit { get; private set;  }
    public UnitInfo PlayerUnit { get; private set;  }
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

    public void BeginBattle(UnitInfo playerInfo, UnitInfo enemyInfo)
    {
        PlayerUnit = playerInfo;
        EnemyUnit = enemyInfo;
        SceneController.LoadBattleScene();
    }

    public void BeginBattle(UnitInfo[] enemyInfos)
    {

    }


}
