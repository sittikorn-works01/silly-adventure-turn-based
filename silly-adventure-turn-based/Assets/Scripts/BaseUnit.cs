using UnityEngine;

public class BaseUnit: MonoBehaviour
{
    public UnitInfo unitInfo;
    public GameManager GameManager => GameManager.Instance;

    public float hp;
    public float atk;

    public virtual void Initialize()
    {
        hp = unitInfo.hp;
        atk = unitInfo.atk;

        print($"{unitInfo.name} : {hp}");
    }

    public virtual void DoDamage(BaseUnit unit)
    {
        print($"{unitInfo.name} attack : {atk}");
        unit.TakeDamage(atk);
    }

    public virtual void TakeDamage(float receivedDamage)
    {
        hp -= receivedDamage;
        print($"{unitInfo.name} received : {atk} damage");
        print($"{unitInfo.name} has hp left : {hp}");
    }
}
