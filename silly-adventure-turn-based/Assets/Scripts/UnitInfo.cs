using UnityEngine;

[CreateAssetMenu(fileName ="NewUnitInfo", menuName = "ScriptableObjects/NewUnitInfo")]
public class UnitInfo : ScriptableObject
{
    public string UnitName;
    public int Hp;
    public int Atk;

    public GameObject UnitPrefab;
}
