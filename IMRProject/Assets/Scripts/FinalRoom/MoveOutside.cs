using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOutside : MonoBehaviour
{
    public string outsideSceneName = "OutsideScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            TeleportToOutsideScene();
        }
    }

    private void TeleportToOutsideScene()
    {
        SceneManager.LoadScene(outsideSceneName);
    }
}
