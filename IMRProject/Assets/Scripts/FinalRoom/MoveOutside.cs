using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOutside : MonoBehaviour
{
    public string outsideSceneName = "OutsideScene";

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);

        if (other.CompareTag("Teleport") || other.CompareTag("Weapon"))
        {
            TeleportToOutsideScene();
        }
    }

    private void TeleportToOutsideScene()
    {
        //SceneManager.SetActiveScene(outsideSceneName);
        SceneManager.LoadScene(outsideSceneName);
        
    }
}
