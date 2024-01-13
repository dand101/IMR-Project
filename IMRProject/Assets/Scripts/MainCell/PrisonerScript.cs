using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    private bool ragdollActivated = false;


    void Start()
    {
        animator = GetComponent<Animator>();

        Limb[] limbs = GetComponentsInChildren<Limb>();
        foreach (Limb limb in limbs)
        {
            limb.OnHitByWeapon += OnLimbHitByWeapon;
        }
    }

    void OnLimbHitByWeapon()
    {
        if (ragdollActivated == false)
        {
            ActivateRagdoll();
            ragdollActivated = true;
        }

    }

    void ActivateRagdoll()
    {
        ragdollActivated = true;

        DisableCharacterComponents();

        EnableRagdollComponents(transform);

        animator.enabled = false;

        Rigidbody[] ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        }
    }

    void DisableCharacterComponents()
    {
        if (characterController != null)
        {
            characterController.enabled = false;
        }

    }

    void EnableRagdollComponents(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            Collider col = child.GetComponent<Collider>();

            if (rb != null)
            {
                rb.isKinematic = false;
            }

            if (col != null)
            {
                col.enabled = true;
            }

            EnableRagdollComponents(child);
        }
    }

    void Update()
    {
        
    }
}
