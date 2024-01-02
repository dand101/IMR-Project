using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{

    public GameObject detachedLimbPref;
    public GameObject spawnPositionReference;
    private bool hasBeenHit = false;

    public event Action OnHitByWeapon;

    public void Hit()
    {
        //transform.localScale = Vector3.zero;
        if (!hasBeenHit)
        {
            GameObject detachedLimb = Instantiate(detachedLimbPref, spawnPositionReference.transform.position, spawnPositionReference.transform.rotation);
            OnHitByWeapon?.Invoke();


            Rigidbody detachedLimbRigidbody = detachedLimb.AddComponent<Rigidbody>();
            detachedLimb.AddComponent<BoxCollider>(); 
            if (detachedLimbRigidbody != null)
            {
                //detachedLimbRigidbody.AddForce(Vector3.forward * 1.5f, ForceMode.Impulse);

                detachedLimbRigidbody.useGravity = true;
            }

            // gameObject.SetActive(false);
            transform.localScale = Vector3.zero;
            //Debug.Log("LOL");

 
            hasBeenHit = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Hit();
        }
    }
}
