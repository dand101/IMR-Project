using UnityEngine;

public interface IWeapon
{
    int WeaponID { get; }
    float Weight { get; }
    float Damage { get; }

    Transform[] AttachmentPoints { get; }
}
