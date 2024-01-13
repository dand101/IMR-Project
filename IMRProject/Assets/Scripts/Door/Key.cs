using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Key : MonoBehaviour
{
    public int keyNumber;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;


    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        

        if (grabInteractable == null)
        {
            //Debug.LogError("XRGrabInteractable component not found on the key object.");
        }
        else
        {
            grabInteractable.onSelectEnter.AddListener(OnGrab);
            grabInteractable.onSelectExit.AddListener(OnRelease);
        }
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        //Debug.Log("Key grabbed");

        if (transform.parent != null)
        {
            //Debug.Log("YES");
            transform.parent = null;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            //Debug.Log("haha");
            rb.isKinematic = false;
            rb.WakeUp();

            //rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

    }

    void OnRelease(XRBaseInteractor interactor)
    {
        //Debug.Log("Key released");
        if (transform.parent != null)
        {
            //Debug.Log("YES");
            transform.parent = null;
        }

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.WakeUp();
        }
    }

}