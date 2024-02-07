using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;



public class ColorChange : MonoBehaviour
{
    private Outline outlineScript;
    private XRGrabInteractable xrGrab;

    private void Start()
    {
        outlineScript = GetComponent<Outline>();
        xrGrab = GetComponent<XRGrabInteractable>();
        xrGrab.onSelectEntered.AddListener(OnGrab);
    }

    public void OnGrab(XRBaseInteractor interactor)
    {
        //Debug.Log("LALLA");
        ChangeOutlineColorToBlack();
    }

    public void ChangeOutlineColorToBlack()
    {
        if (outlineScript != null)
        {
            outlineScript.OutlineColor = Color.black;
        }
    }
}
