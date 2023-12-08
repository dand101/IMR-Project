using UnityEngine;

public class Dagger : MonoBehaviour
{
    public WeaponData daggerData;

    public Transform attachmentPoint;

    public int WeaponID => daggerData.weaponID;
    public float Weight => daggerData.weight;
    public float Damage => daggerData.damage;
    public Transform[] AttachmentPoints => new Transform[] { transform };


}