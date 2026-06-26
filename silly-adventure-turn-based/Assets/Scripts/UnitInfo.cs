using UnityEngine;

[CreateAssetMenu(fileName ="NewUnitInfo", menuName = "ScriptableObjects/NewUnitInfo")]
public class UnitInfo : ScriptableObject
{
    public string unitName;
    public int hp;
    public int atk;
    public GameObject unitPrefab;
}
