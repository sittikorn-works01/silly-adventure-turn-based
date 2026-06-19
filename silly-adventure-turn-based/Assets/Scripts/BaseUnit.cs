using System;
using UnityEngine;

public class BaseUnit: MonoBehaviour
{
    public UnitInfo unitInfo;
    public GameManager GameManager => GameManager.Instance;
    public event Action<float, float> HealthChanged;

    public float hp;
    public float atk;

    public virtual void Initialize()
    {
        hp = unitInfo.hp;
        atk = unitInfo.atk;
    }

    public virtual void DoDamage(BaseUnit unit)
    {
        unit.TakeDamage(atk);
    }

    public virtual void TakeDamage(float receivedDamage)
    {
        hp -= receivedDamage;
        HealthChanged?.Invoke(hp, unitInfo.hp);
    }
}
