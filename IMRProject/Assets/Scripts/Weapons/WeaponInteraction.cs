using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponInteraction : XRGrabInteractable
{
    private IWeapon weapon;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        //Debug.Log("Grabbed");
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        //Debug.Log("Dropped");
    }
}
