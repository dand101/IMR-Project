using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CrossbowController : MonoBehaviour
{
    public InputActionProperty triggerAction;
    private WeaponInteraction weaponInteraction;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Animator animator;

    private float lastShotTime = 0f;
    public float shotDelay = 1f;

    void Start()
    {
        weaponInteraction = GetComponent<WeaponInteraction>();

        if (weaponInteraction == null)
        {
            Debug.LogError("Weapon Interaction component not found!");
        }
        else
        {
            weaponInteraction.onSelectEntered.AddListener(OnGrab);
            weaponInteraction.onSelectExited.AddListener(OnRelease);
        }
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        //Debug.Log("Crossbow grabbed");
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        //Debug.Log("Crossbow released");
    }

    void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();

        if (weaponInteraction.isSelected && Time.time - lastShotTime > shotDelay && triggerValue > 0.5f)
        {
            lastShotTime = Time.time;
            StartCoroutine(ShootWithAnimation());
            //animator.ResetTrigger("TriggerRelease");
        }
    }

    IEnumerator ShootWithAnimation()
    {
        animator.SetTrigger("TriggerRelease");

        yield return new WaitForSeconds(1f);

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        if (projectileRb != null)
        {
            projectileRb.AddForce(shootPoint.forward * 10f, ForceMode.Impulse);
        }
    }
}
