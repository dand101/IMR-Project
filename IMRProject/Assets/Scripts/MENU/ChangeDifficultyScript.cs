using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class ChangeDifficultyScript : XRBaseInteractable
{
    public string difficultyText = "Normal";
    public TextMeshPro myText;


    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log("Interactor type: " + interactor.GetType());

        if (interactor is XRController || interactor is XRRayInteractor)
        {
            ChangeDifficulty();
        }
    }

    private void ChangeDifficulty()
    {
            myText.text = difficultyText;
            Debug.Log(difficultyText);
    }
}
