using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{

    public GameObject detachedLimbPref;
    public GameObject spawnPositionReference;
    public GameObject bloodPrefab;
    private bool hasBeenHit = false;
    public float bloodScale = 0.5f;

    public event Action OnHitByWeapon;

    public void Hit()
    {
        //transform.localScale = Vector3.zero;
        if (!hasBeenHit)
        {
            GameObject detachedLimb = Instantiate(detachedLimbPref, spawnPositionReference.transform.position, spawnPositionReference.transform.rotation);
            OnHitByWeapon?.Invoke();


            Rigidbody detachedLimbRigidbody = detachedLimb.AddComponent<Rigidbody>();
            //detachedLimb.AddComponent<BoxCollider>(); 
            if (detachedLimbRigidbody != null)
            {
                //detachedLimbRigidbody.AddForce(Vector3.forward * 1.5f, ForceMode.Impulse);
                detachedLimbRigidbody.useGravity = true;
            }

            if (bloodPrefab != null)
            {
                GameObject bloodEffect = Instantiate(bloodPrefab, spawnPositionReference.transform.position, Quaternion.identity);

                var mainModule = bloodEffect.GetComponent<ParticleSystem>().main;

                mainModule.startSizeMultiplier *= bloodScale;
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
