using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    private static BattleSetup _instance;
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
        _instance = this;
        if (_instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void BeginBattle(UnitInfo[] enemyInfos)
    {

    }


}
