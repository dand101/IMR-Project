using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChestInteraction : XRBaseInteractable
{
    public string dungeonSceneName = "DungeonScene";

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log("Interactor type: " + interactor.GetType());

        // Check if the interactor is an XRController or XRRayInteractor
        if (interactor is XRController || interactor is XRRayInteractor)
        {
            TeleportToDungeonScene();
        }
    }

    private void TeleportToDungeonScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(dungeonSceneName);
    }
}
