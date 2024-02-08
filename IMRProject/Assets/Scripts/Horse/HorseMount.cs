using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HorseMount : XRBaseInteractable
{
    public GameObject player;
    public Transform mountPoint;
    public GameObject horse;
    public float distanceBelowCamera = 30.0f;
    public GameObject playermount;

    private bool isMounted = false;
    private CharacterController playerController;
    private Animator horseAnim;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if (!isMounted && (interactor is XRController || interactor is XRRayInteractor))
        {
            MountPlayer(interactor.transform);
        }
    }

    private void MountPlayer(Transform interactorTransform)
    {
        player.transform.position = mountPoint.position;
        player.transform.rotation = mountPoint.rotation;

        horse.transform.SetParent(playermount.transform, false);
        horse.transform.localPosition = new Vector3(0f, -distanceBelowCamera, 0f);

        Vector3 highPosition = mountPoint.position + Vector3.up * 0.1f; 
        player.transform.position = highPosition;

        // Disable gravity and vertical movement for the player
        playerController = player.GetComponent<CharacterController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.speedMultiplier= 1.5f;
        }

        horseAnim = horse.GetComponent<Animator>();
        horseAnim.SetBool("run", true);

    isMounted = true;
    }

}
