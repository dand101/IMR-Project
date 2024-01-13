using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject doorToDestroy;
    public GameObject chain1;
    public GameObject chain2;
    public int requiredChainHits = 2;

    private int chainHits = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            if (other.gameObject == chain1 || other.gameObject == chain2)
            {
                Destroy(other.gameObject);

                chainHits++;
                if (chainHits >= requiredChainHits)
                {
                    DestDoor();
                }
            }
        }
    }

    void DestDoor()
    {
        if (doorToDestroy != null)
        {
            Destroy(doorToDestroy);
        }
        else
        {
            Debug.LogError("Door reference not set in the script!");
        }
    }
}
