using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Warhammer : MonoBehaviour
{
    public WeaponData warhammerData;

    public int WeaponID => warhammerData.weaponID;
    public float Weight => CalculateWeight();
    public float Damage => warhammerData.damage;

    private float CalculateWeight()
    {
        //calc weight based on how many hands are on obj
        return warhammerData.weight; 
    }
}
