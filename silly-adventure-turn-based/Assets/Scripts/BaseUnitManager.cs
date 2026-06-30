using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseUnitManager : MonoBehaviour
{
    public BattleManager BattleManager => BattleManager.Instance;
    public event Action<float, float> HealthChanged;

    public string UnitName { get; set; }
    public float MaxHp { get; set; }
    public float Hp { get; set; }
    public float Atk { get; set; }

    public virtual void Initialize(UnitInfo unitInfo)
    {
        UnitName = unitInfo.name;
        MaxHp = unitInfo.Hp;
        Atk = unitInfo.Atk;

        Hp = MaxHp;
    }

    public abstract void BattleManager_OnBattleStateChanged(BattleState state);    

    public virtual void DoDamage(BaseUnitManager unit)
    {
        unit.TakeDamage(Atk);
    }

    public virtual void TakeDamage(float receivedDamage)
    {
        Hp -= receivedDamage;
        HealthChanged?.Invoke(Hp, MaxHp);
    }

    public virtual void OnEnable()
    {
        Debug.Log($"OnEnable called on {gameObject.name}", gameObject);
        BattleManager.OnBattleStateChanged += BattleManager_OnBattleStateChanged;
    }

    public virtual void OnDisable()
    {
        BattleManager.OnBattleStateChanged -= BattleManager_OnBattleStateChanged;
    }


}
