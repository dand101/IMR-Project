using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public TextMeshPro objectiveTextMeshPro;
    private bool animationPlayed = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Teleport") && !animationPlayed)
        {
            Animator textMeshProAnimator = objectiveTextMeshPro.GetComponent<Animator>();
            if (textMeshProAnimator != null)
            {
                //Debug.Log("SETTTTTTT AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
                textMeshProAnimator.SetTrigger("PlayAnimation");
                animationPlayed = true;
            }
            else
            {
                Debug.Log("Animator component not found on the TextMeshPro GameObject.");
            }
        }
    }
}
