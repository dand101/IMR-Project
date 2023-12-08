using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Custom/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int weaponID;
    public float weight;
    public float damage;
}
