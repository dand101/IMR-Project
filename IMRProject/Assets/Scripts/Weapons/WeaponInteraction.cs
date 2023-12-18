using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponInteraction : XRGrabInteractable
{
    private IWeapon weapon;
    public Transform rightAttach;
    public Transform leftAttach;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (args.interactor.transform.CompareTag("RightHand"))
        {
            attachTransform = rightAttach;
        }
        else if (args.interactor.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttach;
        }

        base.OnSelectEntering(args);

        //Debug.Log("Attach Transform Set: " + attachTransform.position);
    }

    //protected override void OnSelectExited(XRBaseInteractor interactor)
    //{
    //    base.OnSelectExited(interactor);

    //    //Debug.Log("Dropped");
    //}
}
