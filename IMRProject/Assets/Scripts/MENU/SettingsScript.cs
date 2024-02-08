using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class SettingsScript : XRBaseInteractable
{
    public GameObject sliderGameObject;
    public GameObject objectToDisable;



    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log("Interactor type: " + interactor.GetType());

        if (interactor is XRController || interactor is XRRayInteractor)
        {
            ShowDifficultySlider();
        }
    }

    private void ShowDifficultySlider()
    {
        if (sliderGameObject != null)
        {
            sliderGameObject.SetActive(!sliderGameObject.activeSelf);
            objectToDisable.SetActive(!objectToDisable.activeSelf);
            Debug.Log("3213121");
        }
        else
        {
            Debug.LogError("Slider GameObject not assigned.");
        }
    }
}
